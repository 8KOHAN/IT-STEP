namespace WinFormsApp3
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
            btnRunAway = new Button();
            txtLog = new TextBox();
            btnToggleLog = new Button();
            SuspendLayout();
            // 
            // btnRunAway
            // 
            btnRunAway.Location = new Point(602, 233);
            btnRunAway.Name = "btnRunAway";
            btnRunAway.Size = new Size(96, 40);
            btnRunAway.TabIndex = 0;
            btnRunAway.Text = "catch me";
            btnRunAway.UseVisualStyleBackColor = true;
            // 
            // txtLog
            // 
            txtLog.Location = new Point(12, 12);
            txtLog.Name = "txtLog";
            txtLog.Size = new Size(369, 27);
            txtLog.TabIndex = 1;
            txtLog.Text = "For visual testing of the keyboard";
            // 
            // btnToggleLog
            // 
            btnToggleLog.Location = new Point(12, 413);
            btnToggleLog.Name = "btnToggleLog";
            btnToggleLog.Size = new Size(369, 61);
            btnToggleLog.TabIndex = 2;
            btnToggleLog.Text = "Start/Stop logging";
            btnToggleLog.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1393, 486);
            Controls.Add(btnToggleLog);
            Controls.Add(txtLog);
            Controls.Add(btnRunAway);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRunAway;
        private TextBox txtLog;
        private Button btnToggleLog;
    }
}
