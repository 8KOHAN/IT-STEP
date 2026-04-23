namespace Client
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
            label1 = new Label();
            btnConnect = new Button();
            textBox1 = new TextBox();
            label2 = new Label();
            txtMessage = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(221, 15);
            label1.TabIndex = 0;
            label1.Text = "Monitored types (separated by commas)";
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(12, 100);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(428, 44);
            btnConnect.TabIndex = 1;
            btnConnect.Text = "Connect to server";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 27);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(428, 23);
            textBox1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 53);
            label2.Name = "label2";
            label2.Size = new Size(100, 15);
            label2.TabIndex = 3;
            label2.Text = "Message received";
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(12, 71);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(428, 23);
            txtMessage.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(452, 156);
            Controls.Add(txtMessage);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(btnConnect);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnConnect;
        private TextBox textBox1;
        private Label label2;
        private TextBox txtMessage;
    }
}
