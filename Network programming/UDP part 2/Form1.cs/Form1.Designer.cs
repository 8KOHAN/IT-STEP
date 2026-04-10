namespace WinFormsChat
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
            txtMessage = new TextBox();
            btnAddChat = new Button();
            btnSend = new Button();
            tabChats = new TabControl();
            txtUsername = new TextBox();
            txtColor = new TextBox();
            SuspendLayout();
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(8, 411);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(401, 27);
            txtMessage.TabIndex = 1;
            // 
            // btnAddChat
            // 
            btnAddChat.Location = new Point(326, 368);
            btnAddChat.Name = "btnAddChat";
            btnAddChat.Size = new Size(83, 37);
            btnAddChat.TabIndex = 2;
            btnAddChat.Text = "New Chat";
            btnAddChat.UseVisualStyleBackColor = true;
            btnAddChat.Click += btnAddChat_Click;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(237, 366);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(83, 39);
            btnSend.TabIndex = 4;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // tabChats
            // 
            tabChats.Location = new Point(12, 12);
            tabChats.Name = "tabChats";
            tabChats.SelectedIndex = 0;
            tabChats.Size = new Size(623, 348);
            tabChats.TabIndex = 0;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(12, 372);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(219, 27);
            txtUsername.TabIndex = 6;
            // 
            // txtColor
            // 
            txtColor.Location = new Point(416, 373);
            txtColor.Name = "txtColor";
            txtColor.Size = new Size(219, 27);
            txtColor.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(764, 450);
            Controls.Add(txtColor);
            Controls.Add(txtUsername);
            Controls.Add(btnSend);
            Controls.Add(btnAddChat);
            Controls.Add(txtMessage);
            Controls.Add(tabChats);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtMessage;
        private Button btnAddChat;
        private Button btnSend;
        private TabControl tabChats;
        private TextBox txtUsername;
        private TextBox txtColor;
    }
}
