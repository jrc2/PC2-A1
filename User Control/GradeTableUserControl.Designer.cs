namespace PC2_A1
{
    partial class GradeTableUserControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.GradesDataGridView = new System.Windows.Forms.DataGridView();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.GradeSelectionContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectAllGradesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uncheckAllGradesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Include = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Grade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GradesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.GradeSelectionContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Assessed items";
            // 
            // GradesDataGridView
            // 
            this.GradesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GradesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Include,
            this.Grade,
            this.Description});
            this.GradesDataGridView.Location = new System.Drawing.Point(0, 20);
            this.GradesDataGridView.Name = "GradesDataGridView";
            this.GradesDataGridView.RowHeadersVisible = false;
            this.GradesDataGridView.RowHeadersWidth = 51;
            this.GradesDataGridView.RowTemplate.Height = 24;
            this.GradesDataGridView.Size = new System.Drawing.Size(304, 234);
            this.GradesDataGridView.TabIndex = 1;
            this.GradesDataGridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GradesDataGridView_MouseDown);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(173, 255);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(53, 22);
            this.numericUpDown1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 257);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Percent of overall grade:";
            // 
            // GradeSelectionContextMenuStrip
            // 
            this.GradeSelectionContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.GradeSelectionContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllGradesToolStripMenuItem,
            this.uncheckAllGradesToolStripMenuItem});
            this.GradeSelectionContextMenuStrip.Name = "GradeSelectionContextMenuStrip";
            this.GradeSelectionContextMenuStrip.Size = new System.Drawing.Size(203, 52);
            // 
            // selectAllGradesToolStripMenuItem
            // 
            this.selectAllGradesToolStripMenuItem.Name = "selectAllGradesToolStripMenuItem";
            this.selectAllGradesToolStripMenuItem.Size = new System.Drawing.Size(202, 24);
            this.selectAllGradesToolStripMenuItem.Text = "Check all grades";
            this.selectAllGradesToolStripMenuItem.Click += new System.EventHandler(this.CheckAllGradesToolStripMenuItem_Click);
            // 
            // uncheckAllGradesToolStripMenuItem
            // 
            this.uncheckAllGradesToolStripMenuItem.Name = "uncheckAllGradesToolStripMenuItem";
            this.uncheckAllGradesToolStripMenuItem.Size = new System.Drawing.Size(202, 24);
            this.uncheckAllGradesToolStripMenuItem.Text = "Uncheck all grades";
            this.uncheckAllGradesToolStripMenuItem.Click += new System.EventHandler(this.UncheckAllGradesToolStripMenuItem_Click);
            // 
            // Include
            // 
            this.Include.HeaderText = "Inc.";
            this.Include.MinimumWidth = 30;
            this.Include.Name = "Include";
            this.Include.Width = 40;
            // 
            // Grade
            // 
            this.Grade.HeaderText = "Grade";
            this.Grade.MinimumWidth = 6;
            this.Grade.Name = "Grade";
            this.Grade.Width = 60;
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.MinimumWidth = 6;
            this.Description.Name = "Description";
            // 
            // GradeTableUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.GradesDataGridView);
            this.Controls.Add(this.label1);
            this.Name = "GradeTableUserControl";
            this.Size = new System.Drawing.Size(672, 514);
            ((System.ComponentModel.ISupportInitialize)(this.GradesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.GradeSelectionContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView GradesDataGridView;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip GradeSelectionContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem selectAllGradesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uncheckAllGradesToolStripMenuItem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Include;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
    }
}
