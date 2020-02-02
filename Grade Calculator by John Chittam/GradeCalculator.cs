using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PC2_A1;

namespace Grade_Calculator_by_John_Chittam
{
    public partial class GradeCalculator : Form
    {
        #region Data members

        private readonly int[] weights;
        private readonly List<double>[] allGrades;

        #endregion

        #region Properties

        private int NumCategories => this.categoriesTabControl.TabPages.Count;

        #endregion

        #region Constructors

        public GradeCalculator()
        {
            this.InitializeComponent();

            this.assignmentsGradeTable.DataModified += this.OnDataModified;
            this.quizzesGradeTable.DataModified += this.OnDataModified;
            this.examsGradeTable.DataModified += this.OnDataModified;

            this.weights = new int[this.NumCategories];
            this.allGrades = new List<double>[this.NumCategories];
        }

        #endregion

        #region Methods

        private void OnDataModified(object sender, string e)
        {
            this.GenerateGradeSummaries();
        }

        private void GenerateGradeSummaries()
        {
            //TODO fix weird rounding issue (overall gets closer and closer to being right as you edit things
            var summaries = string.Empty;

            for (var currCategory = 0; currCategory < this.NumCategories; currCategory++)
            {
                summaries += this.GenerateCategorySummary(currCategory);
            }

            var errorText = this.weights.Sum() == 100
                ? string.Empty
                : $"WARNING: Weights must add up to 100{Environment.NewLine + Environment.NewLine}";

            this.RemoveUnusedCategoriesFromCalculation();

            var overallGrade = this.GenerateOverallGrade();

            this.gradeSummaryTextBox.Text =
                $@"{errorText}Overall grade: {overallGrade + Environment.NewLine + summaries}";
        }

        private void RemoveUnusedCategoriesFromCalculation()
        {
            for (var i = 0; i < this.allGrades.Length; i++)
            {
                var gradesList = this.allGrades[i];
                if (gradesList == null || gradesList.Count == 0)
                {
                    this.weights[i] = 0;
                }
            }
        }

        private double GenerateOverallGrade()
        {
            var weightedGrades = new double[this.NumCategories];

            for (var i = 0; i < weightedGrades.Length; i++)
            {
                if (this.allGrades[i].Count > 0)
                {
                    weightedGrades[i] = this.allGrades[i].Average() * this.weights[i];
                }
            }

            var overallGrade = Math.Round(weightedGrades.Sum() / this.weights.Sum(), 2);
            return overallGrade;
        }

        private string GenerateCategorySummary(int currCategory)
        {
            var page = this.categoriesTabControl.TabPages[currCategory];
            var gradeTable = (GradeTableUserControl) page.Controls[0];
            if (this.allGrades[currCategory] == null)
            {
                this.allGrades[currCategory] = new List<double>();
            }

            this.weights[currCategory] = gradeTable.Weight;
            var categorySummary = string.Empty;
            foreach (DataGridViewRow row in gradeTable.GradesDataGridViewRows)
            {
                if (this.RowShouldBeIncluded(row))
                {
                    this.allGrades[currCategory].Add(double.Parse(row.Cells[1].Value.ToString()));
                    categorySummary += $"{row.Cells[1].Value}: {row.Cells[2].Value}{Environment.NewLine}";
                }
            }

            return this.allGrades[currCategory] != null && this.allGrades[currCategory].Count > 0
                ? $"{Environment.NewLine + page.Text} average: {Math.Round(this.allGrades[currCategory].Average(), 2)} Weight: {this.weights[currCategory]}" +
                  Environment.NewLine + categorySummary
                : "";
        }

        private bool RowShouldBeIncluded(DataGridViewRow row)
        {
            if (row.Cells[0].Value == null || row.Cells[1].Value == null || row.Cells[2].Value == null)
            {
                return false;
            }

            var inc = false;
            if (!bool.TryParse(row.Cells[0].Value.ToString(), out inc) || !inc)
            {
                return false;
            }

            double grade = -1;
            if (!double.TryParse(row.Cells[1].Value.ToString(), out grade) || grade < 0 || grade > 100)
            {
                return false;
            }

            if (row.Cells[2].Value.ToString().Trim() == string.Empty)
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}