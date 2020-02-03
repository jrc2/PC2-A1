using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace Grade_Table_User_Control
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
        public int Weight
        {
            get => decimal.ToInt32(this.gradeNumericUpDown.Value);
            private set => this.gradeNumericUpDown.Value = value;
        }

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

            using (var writer = XmlWriter.Create($"{filePath}\\{this.TableName}.xml"))
            {
                writer.WriteStartElement(this.TableName);
                writer.WriteElementString("Weight", this.Weight.ToString());
                this.gradesTable.WriteXml(writer);
            }
        }

        /// <summary>
        ///     Loads the gradesTable from XML.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        public void LoadDataFromXml(string filePath)
        {
            this.gradesTable.TableName = this.TableName;
            var fullFilePath = $"{filePath}\\{this.TableName}.xml";
            if (File.Exists(fullFilePath))
            {
                using (var reader = XmlReader.Create(fullFilePath))
                {
                    reader.ReadStartElement(this.TableName);
                    this.Weight = int.Parse(reader.ReadElementString("Weight"));
                    this.gradesTable.ReadXml(reader);
                }
            }
        }

        private void GradesDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                this.OnDataModified(null, null);
            }
        }

        private void GradesDataGridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                this.GradesDataGridView.EndEdit();
            }
        }

        #endregion
    }
}