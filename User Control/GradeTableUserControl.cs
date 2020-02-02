using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PC2_A1
{
    /// <summary>
    ///     The grade table user control
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public partial class GradeTableUserControl : UserControl
    {
        #region Data members

        private readonly DataTable gradesTable;

        #endregion

        #region Properties

        /// <summary>
        ///     Gets the grades gradesTable grid view rows.
        /// </summary>
        /// <value>
        ///     The grades gradesTable grid view rows.
        /// </value>
        public DataGridViewRowCollection GradesDataGridViewRows => this.GradesDataGridView.Rows;

        /// <summary>
        ///     Gets the weight.
        /// </summary>
        /// <value>
        ///     The weight.
        /// </value>
        public int Weight => decimal.ToInt32(this.gradeNumericUpDown.Value);

        /// <summary>
        ///     Gets or sets the name of the table.
        /// </summary>
        /// <value>
        ///     The name of the table.
        /// </value>
        public string TableName { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="GradeTableUserControl" /> class.
        /// </summary>
        public GradeTableUserControl()
        {
            this.InitializeComponent();

            this.gradesTable = new DataTable();
            this.gradesTable.Columns.Add("Include", typeof(bool));
            this.gradesTable.Columns.Add("Grade", typeof(double));
            this.gradesTable.Columns.Add("Description", typeof(string));
            this.GradesDataGridView.DataSource = this.gradesTable;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Occurs when [gradesTable modified].
        /// </summary>
        public event EventHandler<string> DataModified;

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
                this.OnDataModified(null, null);
            }
        }

        private void UncheckAllGradesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.GradesDataGridView.Rows)
            {
                var checkbox = row.Cells[0];
                checkbox.Selected = false;
                checkbox.Value = 0;
                this.OnDataModified(null, null);
            }
        }

        private void OnDataModified(object sender, EventArgs e)
        {
            this.DataModified?.Invoke(this, "");
        }

        /// <summary>
        ///     Writes the gradesTable to XML.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        public void WriteDataToXml(string filePath)
        {
            this.gradesTable.TableName = this.TableName;
            this.gradesTable.WriteXml($@"{filePath}\{this.TableName}.xml");
        }

        /// <summary>
        ///     Loads the gradesTable from XML.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        public void LoadDataFromXml(string filePath)
        {
            this.gradesTable.TableName = this.TableName;
            this.gradesTable.ReadXml($@"{filePath}\{this.TableName}.xml");
        }

        #endregion
    }
}