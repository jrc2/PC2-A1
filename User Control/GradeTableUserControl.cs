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
    /// <summary>
    /// The grade table user control
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public partial class GradeTableUserControl: UserControl
    {

        /// <summary>
        /// Occurs when [data modified].
        /// </summary>
        public event EventHandler<string> DataModified;

        /// <summary>
        /// Gets the grades data grid view rows.
        /// </summary>
        /// <value>
        /// The grades data grid view rows.
        /// </value>
        public DataGridViewRowCollection GradesDataGridViewRows => this.GradesDataGridView.Rows;
        /// <summary>
        /// Gets the weight.
        /// </summary>
        /// <value>
        /// The weight.
        /// </value>
        public int Weight => decimal.ToInt32(this.gradeNumericUpDown.Value);
        /// <summary>
        /// Gets or sets the name of the table.
        /// </summary>
        /// <value>
        /// The name of the table.
        /// </value>
        public string TableName { get; set; }

        /// <summary>
        /// The data
        /// </summary>
        private readonly DataTable data;

        /// <summary>
        /// Initializes a new instance of the <see cref="GradeTableUserControl"/> class.
        /// </summary>
        public GradeTableUserControl()
        {
            InitializeComponent();

            this.data = new DataTable();
            this.data.Columns.Add("Include", typeof(bool));
            this.data.Columns.Add("Grade", typeof(double));
            this.data.Columns.Add("Description", typeof(string));
            this.GradesDataGridView.DataSource = this.data;
        }

        /// <summary>
        /// Handles the MouseDown event of the GradesDataGridView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void GradesDataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.GradeSelectionContextMenuStrip.Show(this, new Point(e.X, e.Y));
            }
        }

        /// <summary>
        /// Handles the Click event of the CheckAllGradesToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CheckAllGradesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.GradesDataGridView.Rows)
            {
                var checkbox = row.Cells[0];
                checkbox.Selected = false;
                checkbox.Value = 1;
                this.OnDataModified("");
            }
        }

        /// <summary>
        /// Handles the Click event of the UncheckAllGradesToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void UncheckAllGradesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.GradesDataGridView.Rows)
            {
                var checkbox = row.Cells[0];
                checkbox.Selected = false;
                checkbox.Value = 0;
                this.OnDataModified("");
            }
        }

        /// <summary>
        /// Called when [data modified].
        /// </summary>
        /// <param name="e">The e.</param>
        protected virtual void OnDataModified(string e)
        {
            this.DataModified?.Invoke(this, e);
        }

        /// <summary>
        /// Handles the CellEndEdit event of the GradesDataGridView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewCellEventArgs"/> instance containing the event data.</param>
        private void GradesDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.OnDataModified("");
        }

        /// <summary>
        /// Handles the ValueChanged event of the NumericUpDown1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            this.OnDataModified("");
        }

        /// <summary>
        /// Writes the data to XML.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        public void WriteDataToXml(string filePath)
        {
            this.data.TableName = this.TableName;
            this.data.WriteXml($@"{filePath}\{this.TableName}.xml");
        }

        /// <summary>
        /// Loads the data from XML.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        public void LoadDataFromXml(string filePath)
        {
            this.data.TableName = this.TableName;
            this.data.ReadXml($@"{filePath}\{this.TableName}.xml");
        }
    }
}
