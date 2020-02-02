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
            string newSummaryOutput = "";

            IList<double> assignmentGrades = new List<double>();
            string assignmentsSummary = "";
            foreach (DataGridViewRow row in this.assignmentsGradeTable.GradesDataGridViewRows)
            {
                if (this.RowShouldBeIncluded(row))
                {
                    assignmentGrades.Add(double.Parse(row.Cells[1].Value.ToString()));
                    assignmentsSummary += $"{row.Cells[1].Value}: {row.Cells[2].Value}" + Environment.NewLine;
                }
            }

            if (assignmentGrades.Count > 0)
            {
                newSummaryOutput += $"Assignments average: {Math.Truncate(assignmentGrades.Average())} Weight: {this.assignmentsGradeTable.Weight}" +
                                    Environment.NewLine + assignmentsSummary;
            }

            this.gradeSummaryTextBox.Text = newSummaryOutput;
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
