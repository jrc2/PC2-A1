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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Assignments = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.userControl11 = new PC2_A1.GradeTableUserControl();
            this.userControl12 = new PC2_A1.GradeTableUserControl();
            this.userControl13 = new PC2_A1.GradeTableUserControl();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.gradeSummaryLabel = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.Assignments.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Assignments);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(15, 33);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(356, 318);
            this.tabControl1.TabIndex = 0;
            // 
            // Assignments
            // 
            this.Assignments.Controls.Add(this.userControl11);
            this.Assignments.Location = new System.Drawing.Point(4, 25);
            this.Assignments.Name = "Assignments";
            this.Assignments.Padding = new System.Windows.Forms.Padding(3);
            this.Assignments.Size = new System.Drawing.Size(348, 289);
            this.Assignments.TabIndex = 0;
            this.Assignments.Text = "Assignments";
            this.Assignments.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.userControl12);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(348, 289);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Quizzes";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.userControl13);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(348, 289);
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
            // userControl11
            // 
            this.userControl11.Location = new System.Drawing.Point(3, 3);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(339, 283);
            this.userControl11.TabIndex = 0;
            // 
            // userControl12
            // 
            this.userControl12.Location = new System.Drawing.Point(0, 0);
            this.userControl12.Name = "userControl12";
            this.userControl12.Size = new System.Drawing.Size(345, 283);
            this.userControl12.TabIndex = 0;
            // 
            // userControl13
            // 
            this.userControl13.Location = new System.Drawing.Point(6, 0);
            this.userControl13.Name = "userControl13";
            this.userControl13.Size = new System.Drawing.Size(342, 286);
            this.userControl13.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(15, 387);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(352, 261);
            this.textBox1.TabIndex = 2;
            // 
            // gradeSummaryLabel
            // 
            this.gradeSummaryLabel.AutoSize = true;
            this.gradeSummaryLabel.Location = new System.Drawing.Point(16, 367);
            this.gradeSummaryLabel.Name = "gradeSummaryLabel";
            this.gradeSummaryLabel.Size = new System.Drawing.Size(139, 21);
            this.gradeSummaryLabel.TabIndex = 3;
            this.gradeSummaryLabel.Text = "Grade Summary";
            // 
            // GradeCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 676);
            this.Controls.Add(this.gradeSummaryLabel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Name = "GradeCalculator";
            this.Text = "Grade Calculator by John Chittam";
            this.tabControl1.ResumeLayout(false);
            this.Assignments.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Assignments;
        private PC2_A1.GradeTableUserControl userControl11;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label1;
        private PC2_A1.GradeTableUserControl userControl12;
        private PC2_A1.GradeTableUserControl userControl13;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label gradeSummaryLabel;
    }
}

