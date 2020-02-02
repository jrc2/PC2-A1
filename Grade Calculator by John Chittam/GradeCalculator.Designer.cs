namespace Grade_Calculator_by_John_Chittam
{
    partial class GradeCalculator
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.categoriesTabControl = new System.Windows.Forms.TabControl();
            this.Assignments = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.gradeSummaryTextBox = new System.Windows.Forms.TextBox();
            this.gradeSummaryLabel = new System.Windows.Forms.Label();
            this.assignmentsGradeTable = new PC2_A1.GradeTableUserControl();
            this.quizzesGradeTable = new PC2_A1.GradeTableUserControl();
            this.examsGradeTable = new PC2_A1.GradeTableUserControl();
            this.categoriesTabControl.SuspendLayout();
            this.Assignments.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // categoriesTabControl
            // 
            this.categoriesTabControl.Controls.Add(this.Assignments);
            this.categoriesTabControl.Controls.Add(this.tabPage2);
            this.categoriesTabControl.Controls.Add(this.tabPage3);
            this.categoriesTabControl.Location = new System.Drawing.Point(15, 33);
            this.categoriesTabControl.Name = "categoriesTabControl";
            this.categoriesTabControl.SelectedIndex = 0;
            this.categoriesTabControl.Size = new System.Drawing.Size(430, 318);
            this.categoriesTabControl.TabIndex = 0;
            // 
            // Assignments
            // 
            this.Assignments.Controls.Add(this.assignmentsGradeTable);
            this.Assignments.Location = new System.Drawing.Point(4, 25);
            this.Assignments.Name = "Assignments";
            this.Assignments.Padding = new System.Windows.Forms.Padding(3);
            this.Assignments.Size = new System.Drawing.Size(422, 289);
            this.Assignments.TabIndex = 0;
            this.Assignments.Text = "Assignments";
            this.Assignments.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.quizzesGradeTable);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(422, 289);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Quizzes";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.examsGradeTable);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(422, 289);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Exams";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Categories";
            // 
            // gradeSummaryTextBox
            // 
            this.gradeSummaryTextBox.Enabled = false;
            this.gradeSummaryTextBox.Location = new System.Drawing.Point(15, 387);
            this.gradeSummaryTextBox.Multiline = true;
            this.gradeSummaryTextBox.Name = "gradeSummaryTextBox";
            this.gradeSummaryTextBox.Size = new System.Drawing.Size(419, 261);
            this.gradeSummaryTextBox.TabIndex = 2;
            // 
            // gradeSummaryLabel
            // 
            this.gradeSummaryLabel.AutoSize = true;
            this.gradeSummaryLabel.Location = new System.Drawing.Point(16, 367);
            this.gradeSummaryLabel.Name = "gradeSummaryLabel";
            this.gradeSummaryLabel.Size = new System.Drawing.Size(111, 17);
            this.gradeSummaryLabel.TabIndex = 3;
            this.gradeSummaryLabel.Text = "Grade Summary";
            // 
            // assignmentsGradeTable
            // 
            this.assignmentsGradeTable.Location = new System.Drawing.Point(3, 3);
            this.assignmentsGradeTable.Name = "assignmentsGradeTable";
            this.assignmentsGradeTable.Size = new System.Drawing.Size(420, 283);
            this.assignmentsGradeTable.TabIndex = 0;
            this.assignmentsGradeTable.TableName = "assignmentsGradeTable";
            // 
            // quizzesGradeTable
            // 
            this.quizzesGradeTable.Location = new System.Drawing.Point(0, 0);
            this.quizzesGradeTable.Name = "quizzesGradeTable";
            this.quizzesGradeTable.Size = new System.Drawing.Size(415, 283);
            this.quizzesGradeTable.TabIndex = 0;
            this.quizzesGradeTable.TableName = "quizzesGradeTable";
            // 
            // examsGradeTable
            // 
            this.examsGradeTable.Location = new System.Drawing.Point(6, 0);
            this.examsGradeTable.Name = "examsGradeTable";
            this.examsGradeTable.Size = new System.Drawing.Size(409, 286);
            this.examsGradeTable.TabIndex = 0;
            this.examsGradeTable.TableName = "examsGradeTable";
            // 
            // GradeCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 676);
            this.Controls.Add(this.gradeSummaryLabel);
            this.Controls.Add(this.gradeSummaryTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.categoriesTabControl);
            this.Name = "GradeCalculator";
            this.Text = "Grade Calculator by John Chittam";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GradeCalculator_FormClosing);
            this.categoriesTabControl.ResumeLayout(false);
            this.Assignments.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl categoriesTabControl;
        private System.Windows.Forms.TabPage Assignments;
        private PC2_A1.GradeTableUserControl assignmentsGradeTable;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label1;
        private PC2_A1.GradeTableUserControl quizzesGradeTable;
        private PC2_A1.GradeTableUserControl examsGradeTable;
        private System.Windows.Forms.TextBox gradeSummaryTextBox;
        private System.Windows.Forms.Label gradeSummaryLabel;
    }
}

