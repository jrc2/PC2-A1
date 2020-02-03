using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace PC2_A1
{
    /// <summary>
    ///     The grade table user control
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public partial class GradeTableUserControl : UserControl
    {
        #region Data members

        #endregion

        #region Properties

        /// <summary>
        ///     Gets the grades GradesTable grid view rows.
        /// </summary>
        /// <value>
        ///     The grades GradesTable grid view rows.
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
            set => this.gradeNumericUpDown.Value = value;
        }

        /// <summary>
        /// Gets or sets the grades table.
        /// </summary>
        /// <value>
        /// The grades table.
        /// </value>
        public DataTable GradesTable { get; set; }

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

            this.GradesTable = new DataTable();
            this.GradesTable.Columns.Add("Include", typeof(bool));
            this.GradesTable.Columns.Add("Grade", typeof(double));
            this.GradesTable.Columns.Add("Description", typeof(string));
            this.GradesDataGridView.DataSource = this.GradesTable;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Occurs when [GradesTable modified].
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
        ///     Writes the GradesTable to XML.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        public void WriteDataToXml(string filePath)
        {
            this.GradesTable.TableName = this.TableName;
//            this.GradesTable.WriteXml($@"{filePath}\{this.TableName}.xml");
            //            var data = new CategoryData(this.GradesTable, this.Weight);
            //            Serializer.Serialize(data, this.TableName + "2");

            using (var writer = XmlWriter.Create($@"{filePath}\{this.TableName}.xml"))
            {
                writer.WriteStartElement(this.TableName);
                writer.WriteElementString("Weight", this.Weight.ToString());
                this.GradesTable.WriteXml(writer);
            }
        }

        /// <summary>
        ///     Loads the GradesTable from XML.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        public void LoadDataFromXml(string filePath)
        {
            this.GradesTable.TableName = this.TableName;
            try
            {
                using (var reader = XmlReader.Create($@"{filePath}\{this.TableName}.xml"))
                {
                    reader.ReadStartElement(this.TableName);
                    this.Weight = int.Parse(reader.ReadElementString("Weight"));
                    this.GradesTable.ReadXml(reader);
                }
            }
            catch
            {
                return;
            }
            
//            var data = Serializer.Deserialize(this.TableName + "2");
//            if (data != null)
//            {
//                this.Weight = data.Weight;
//                this.GradesTable = data.Grades;
//            }
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