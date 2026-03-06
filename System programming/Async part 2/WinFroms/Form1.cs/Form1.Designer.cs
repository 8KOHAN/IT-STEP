namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxPath = new TextBox();
            buttonStart = new Button();
            listBoxLog = new ListBox();
            labelStats = new Label();
            SuspendLayout();
            // 
            // textBoxPath
            // 
            textBoxPath.Location = new Point(12, 11);
            textBoxPath.Name = "textBoxPath";
            textBoxPath.Size = new Size(536, 27);
            textBoxPath.TabIndex = 0;
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(576, 7);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(83, 31);
            buttonStart.TabIndex = 1;
            buttonStart.Text = "Start";
            buttonStart.UseVisualStyleBackColor = true;
            // 
            // listBoxLog
            // 
            listBoxLog.FormattingEnabled = true;
            listBoxLog.Location = new Point(12, 67);
            listBoxLog.Name = "listBoxLog";
            listBoxLog.Size = new Size(995, 184);
            listBoxLog.TabIndex = 2;
            // 
            // labelStats
            // 
            labelStats.AutoSize = true;
            labelStats.Location = new Point(665, 12);
            labelStats.Name = "labelStats";
            labelStats.Size = new Size(67, 20);
            labelStats.TabIndex = 3;
            labelStats.Text = "Statistics";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1046, 476);
            Controls.Add(labelStats);
            Controls.Add(listBoxLog);
            Controls.Add(buttonStart);
            Controls.Add(textBoxPath);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxPath;
        private Button buttonStart;
        private ListBox listBoxLog;
        private Label labelStats;
    }
}
