namespace WinFormsApp10
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
            btnSend = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtMessage = new TextBox();
            txtSubject = new TextBox();
            txtPassword = new TextBox();
            txtTo = new TextBox();
            txtFrom = new TextBox();
            btnAttach = new Button();
            txtFile = new TextBox();
            label6 = new Label();
            SuspendLayout();
            // 
            // btnSend
            // 
            btnSend.Location = new Point(12, 362);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(644, 38);
            btnSend.TabIndex = 0;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 7);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 1;
            label1.Text = "From:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 60);
            label2.Name = "label2";
            label2.Size = new Size(28, 20);
            label2.TabIndex = 3;
            label2.Text = "To:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 114);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 5;
            label3.Text = "Password:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 167);
            label4.Name = "label4";
            label4.Size = new Size(61, 20);
            label4.TabIndex = 7;
            label4.Text = "Subject:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(408, 7);
            label5.Name = "label5";
            label5.Size = new Size(70, 20);
            label5.TabIndex = 9;
            label5.Text = "Message:";
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(408, 30);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.ScrollBars = ScrollBars.Horizontal;
            txtMessage.Size = new Size(248, 300);
            txtMessage.TabIndex = 10;
            // 
            // txtSubject
            // 
            txtSubject.Location = new Point(12, 190);
            txtSubject.Name = "txtSubject";
            txtSubject.Size = new Size(390, 27);
            txtSubject.TabIndex = 12;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(12, 137);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(390, 27);
            txtPassword.TabIndex = 14;
            // 
            // txtTo
            // 
            txtTo.Location = new Point(12, 83);
            txtTo.Name = "txtTo";
            txtTo.Size = new Size(390, 27);
            txtTo.TabIndex = 16;
            // 
            // txtFrom
            // 
            txtFrom.Location = new Point(12, 30);
            txtFrom.Name = "txtFrom";
            txtFrom.Size = new Size(390, 27);
            txtFrom.TabIndex = 18;
            // 
            // btnAttach
            // 
            btnAttach.Location = new Point(12, 299);
            btnAttach.Name = "btnAttach";
            btnAttach.Size = new Size(390, 31);
            btnAttach.TabIndex = 19;
            btnAttach.Text = "Attach file";
            btnAttach.UseVisualStyleBackColor = true;
            btnAttach.Click += btnAttach_Click;
            // 
            // txtFile
            // 
            txtFile.Location = new Point(12, 266);
            txtFile.Name = "txtFile";
            txtFile.ReadOnly = true;
            txtFile.Size = new Size(390, 27);
            txtFile.TabIndex = 20;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 243);
            label6.Name = "label6";
            label6.Size = new Size(97, 20);
            label6.TabIndex = 21;
            label6.Text = "Attached file:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(668, 412);
            Controls.Add(label6);
            Controls.Add(txtFile);
            Controls.Add(btnAttach);
            Controls.Add(txtFrom);
            Controls.Add(txtTo);
            Controls.Add(txtPassword);
            Controls.Add(txtSubject);
            Controls.Add(txtMessage);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnSend);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSend;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtMessage;
        private TextBox txtSubject;
        private TextBox txtPassword;
        private TextBox txtTo;
        private TextBox txtFrom;
        private Button btnAttach;
        private TextBox txtFile;
        private Label label6;
    }
}
