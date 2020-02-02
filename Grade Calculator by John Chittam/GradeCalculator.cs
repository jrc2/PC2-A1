using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
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

            this.weights = new int[this.NumCategories];
            this.allGrades = new List<double>[this.NumCategories];

            for (var i = 0; i < this.categoriesTabControl.TabPages.Count; i++)
            {
                var gradeTable = (GradeTableUserControl) this.categoriesTabControl.TabPages[i].Controls[0];
                gradeTable.TableName = this.categoriesTabControl.TabPages[i].Text;
                gradeTable.LoadDataFromXml(Application.UserAppDataPath);
                gradeTable.DataModified += this.OnDataModified;
            }

            this.GenerateGradeSummaries();
        }

        #endregion

        #region Methods

        private void OnDataModified(object sender, string e)
        {
            this.GenerateGradeSummaries();
        }

        private void GenerateGradeSummaries()
        {
            var summaries = string.Empty;

            for (var currCategory = 0; currCategory < this.NumCategories; currCategory++)
            {
                summaries += this.GenerateCategorySummary(currCategory);
            }

            this.gradeSummaryTextBox.Text = this.weights.Sum() == 100
                ? string.Empty
                : $"WARNING: Weights must add up to 100{Environment.NewLine + Environment.NewLine}";

            this.RemoveUnusedCategoriesFromCalculation();

            var overallGrade = this.GenerateOverallGrade();

            if (overallGrade != null)
            {
                this.gradeSummaryTextBox.Text +=
                    $@"Overall grade: {overallGrade + Environment.NewLine}";
            }

            this.gradeSummaryTextBox.Text += summaries;
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

        private double? GenerateOverallGrade()
        {
            var weightedGrades = new double[this.NumCategories];

            for (var i = 0; i < weightedGrades.Length; i++)
            {
                if (this.allGrades[i].Count > 0)
                {
                    weightedGrades[i] = this.allGrades[i].Average() * this.weights[i];
                }
            }

            if (this.weights.Sum() <= 0)
            {
                return null;
            }

            return Math.Round(weightedGrades.Sum() / this.weights.Sum(), 2);
        }

        private string GenerateCategorySummary(int currCategory)
        {
            var page = this.categoriesTabControl.TabPages[currCategory];
            var gradeTable = (GradeTableUserControl) page.Controls[0];
            this.allGrades[currCategory] = new List<double>();
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

        private void GradeCalculator_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (TabPage page in this.categoriesTabControl.TabPages)
            {
                ((GradeTableUserControl)page.Controls[0]).WriteDataToXml(Application.UserAppDataPath);
            }
        }
    }
}