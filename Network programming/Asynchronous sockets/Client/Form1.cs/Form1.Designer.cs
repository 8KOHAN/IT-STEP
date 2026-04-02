namespace WinFormsApp5
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
            btnConnect = new Button();
            btnDisconnect = new Button();
            btnSend = new Button();
            btnRefresh = new Button();
            txtChat = new TextBox();
            txtMessage = new TextBox();
            txtUsername = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(228, 39);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(121, 29);
            btnConnect.TabIndex = 0;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Location = new Point(355, 41);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(121, 27);
            btnDisconnect.TabIndex = 2;
            btnDisconnect.Text = "Disconnect";
            btnDisconnect.UseVisualStyleBackColor = true;
            btnDisconnect.Click += btnDisconnect_Click;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(228, 103);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(121, 27);
            btnSend.TabIndex = 4;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(355, 105);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(121, 25);
            btnRefresh.TabIndex = 6;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // txtChat
            // 
            txtChat.Location = new Point(12, 190);
            txtChat.Multiline = true;
            txtChat.Name = "txtChat";
            txtChat.ReadOnly = true;
            txtChat.Size = new Size(464, 328);
            txtChat.TabIndex = 7;
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(12, 103);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(210, 27);
            txtMessage.TabIndex = 9;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(12, 39);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(210, 27);
            txtUsername.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 16);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 12;
            label1.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 80);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 13;
            label2.Text = "Message";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 158);
            label3.Name = "label3";
            label3.Size = new Size(39, 20);
            label3.TabIndex = 14;
            label3.Text = "Chat";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(488, 530);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtUsername);
            Controls.Add(txtMessage);
            Controls.Add(txtChat);
            Controls.Add(btnRefresh);
            Controls.Add(btnSend);
            Controls.Add(btnDisconnect);
            Controls.Add(btnConnect);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnConnect;
        private Button btnDisconnect;
        private Button btnSend;
        private Button btnRefresh;
        private TextBox txtChat;
        private TextBox txtMessage;
        private TextBox txtUsername;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}
