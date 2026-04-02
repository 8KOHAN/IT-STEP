namespace WinFormsApp2
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
            txtServerIP = new TextBox();
            txtAnswer = new TextBox();
            txtServerPort = new TextBox();
            txtMessage = new TextBox();
            label1 = new Label();
            label2 = new Label();
            Answer = new Label();
            label4 = new Label();
            btnSend = new Button();
            SuspendLayout();
            // 
            // txtServerIP
            // 
            txtServerIP.Location = new Point(12, 68);
            txtServerIP.Name = "txtServerIP";
            txtServerIP.Size = new Size(183, 23);
            txtServerIP.TabIndex = 0;
            // 
            // txtAnswer
            // 
            txtAnswer.Location = new Point(201, 21);
            txtAnswer.Name = "txtAnswer";
            txtAnswer.Size = new Size(183, 23);
            txtAnswer.TabIndex = 2;
            // 
            // txtServerPort
            // 
            txtServerPort.Location = new Point(201, 68);
            txtServerPort.Name = "txtServerPort";
            txtServerPort.Size = new Size(183, 23);
            txtServerPort.TabIndex = 4;
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(12, 21);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(183, 23);
            txtMessage.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(201, 50);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 7;
            label1.Text = "Server port:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 50);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 9;
            label2.Text = "Server IP:";
            // 
            // Answer
            // 
            Answer.AutoSize = true;
            Answer.Location = new Point(201, 3);
            Answer.Name = "Answer";
            Answer.Size = new Size(49, 15);
            Answer.TabIndex = 11;
            Answer.Text = "Answer:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 3);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 13;
            label4.Text = "Message:";
            // 
            // btnSend
            // 
            btnSend.Location = new Point(12, 97);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(372, 37);
            btnSend.TabIndex = 14;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += BtnSend_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(399, 145);
            Controls.Add(btnSend);
            Controls.Add(label4);
            Controls.Add(Answer);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtMessage);
            Controls.Add(txtServerPort);
            Controls.Add(txtAnswer);
            Controls.Add(txtServerIP);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtServerIP;
        private TextBox txtAnswer;
        private TextBox txtServerPort;
        private TextBox txtMessage;
        private Label label1;
        private Label label2;
        private Label Answer;
        private Label label4;
        private Button btnSend;
    }
}
