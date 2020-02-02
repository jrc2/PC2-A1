using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PC2_A1
{
    public partial class GradeTableUserControl: UserControl
    {

        public event EventHandler<string> DataModified; 

        public DataGridViewRowCollection GradesDataGridViewRows => this.GradesDataGridView.Rows;
        public int Weight => decimal.ToInt32(this.gradeNumericUpDown.Value);

        public GradeTableUserControl()
        {
            InitializeComponent();
        }

        private void GradesDataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.GradeSelectionContextMenuStrip.Show(this, new Point(e.X, e.Y));
            }
        }

        private void CheckAllGradesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.GradesDataGridView.Rows)
            {
                var checkbox = row.Cells[0];
                checkbox.Selected = false;
                checkbox.Value = 1;
            }
        }

        private void UncheckAllGradesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.GradesDataGridView.Rows)
            {
                var checkbox = row.Cells[0];
                checkbox.Selected = false;
                checkbox.Value = 0;
            }
        }

        protected virtual void OnDataModified(string e)
        {
            this.DataModified?.Invoke(this, e);
        }

        private void GradesDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.OnDataModified("");
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            this.OnDataModified("");
        }

    }
}
