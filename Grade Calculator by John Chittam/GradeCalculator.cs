using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PC2_A1;

namespace Grade_Calculator_by_John_Chittam
{
    public partial class GradeCalculator : Form
    {
        public GradeCalculator()
        {
            InitializeComponent();

            this.assignmentsGradeTable.DataModified += this.OnDataModified;

            this.quizzesGradeTable.DataModified += this.OnDataModified;

            this.examsGradeTable.DataModified += this.OnDataModified;
        }

        private void OnDataModified(object sender, string e)
        {
            var numCategories = this.categoriesTabControl.TabPages.Count;
            var weights = new int[numCategories];
            var allGrades = new List<double>[numCategories];
            var summaries = string.Empty;

            for (var i = 0; i < numCategories; i++)
            {
                var page = this.categoriesTabControl.TabPages[i];
                var gradeTable = (GradeTableUserControl) page.Controls[0];
                if (allGrades[i] == null)
                {
                    allGrades[i] = new List<double>();
                }
                weights[i] = gradeTable.Weight;
                var categorySummary = string.Empty;
                foreach (DataGridViewRow row in gradeTable.GradesDataGridViewRows)
                {
                    if (this.RowShouldBeIncluded(row))
                    {
                        allGrades[i].Add(double.Parse(row.Cells[1].Value.ToString()));
                        categorySummary += $"{row.Cells[1].Value}: {row.Cells[2].Value}{Environment.NewLine}";
                    }
                }

                summaries += allGrades[i] != null && allGrades[i].Count > 0 ? $"{Environment.NewLine + page.Text} average: {Math.Round(allGrades[i].Average(), 2)} Weight: {weights[i]}" +
                                                                            Environment.NewLine + categorySummary : "";
            }

            if (summaries != string.Empty)
            {
                var errorText = weights.Sum() == 100
                    ? string.Empty
                    : $"WARNING: Weights must add up to 100{Environment.NewLine + Environment.NewLine}";

                for (var i = 0; i < allGrades.Length; i++)
                {
                    var gradesList = allGrades[i];
                    if (gradesList == null || gradesList.Count == 0)
                    {
                        weights[i] = 0;
                    }
                }

                var weightedGrades = new double[numCategories];

                for (var i = 0; i < weightedGrades.Length; i++)
                {
                    if (allGrades[i].Count > 0)
                    {
                        var average = allGrades[i].Average();
                        var weight = weights[i];
                        weightedGrades[i] = average * weight / 100;
                    }
                }

                var overallGrade = Math.Round(weightedGrades.Sum() / weights.Sum() * 100, 2);

                this.gradeSummaryTextBox.Text = $@"{errorText}Overall grade: {overallGrade + Environment.NewLine + summaries}";
            }
        }

        private bool RowShouldBeIncluded(DataGridViewRow row)
        {
            if (row.Cells[0].Value == null || row.Cells[1].Value == null || row.Cells[2].Value == null)
            {
                return false;
            }

            bool inc = false;
            if (!(bool.TryParse(row.Cells[0].Value.ToString(), out inc)) || !inc)
            {
                return false;
            }

            double grade = -1;
            if (!(double.TryParse(row.Cells[1].Value.ToString(), out grade)) || grade < 0 || grade > 100)
            {
                return false;
            }

            if (row.Cells[2].Value.ToString().Trim() == string.Empty)
            {
                return false;
            }

            return true;
        }
    }
}
