namespace SocketExample
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
            txtResult = new TextBox();
            btnRequest = new Button();
            btnRemoteRequest = new Button();
            txtHTTP = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // txtResult
            // 
            txtResult.BackColor = Color.FromArgb(255, 255, 192);
            txtResult.Location = new Point(12, 12);
            txtResult.Multiline = true;
            txtResult.Name = "txtResult";
            txtResult.Size = new Size(776, 316);
            txtResult.TabIndex = 0;
            // 
            // btnRequest
            // 
            btnRequest.BackColor = Color.FromArgb(255, 224, 192);
            btnRequest.Location = new Point(12, 389);
            btnRequest.Name = "btnRequest";
            btnRequest.Size = new Size(776, 28);
            btnRequest.TabIndex = 1;
            btnRequest.Text = "Send Local Request";
            btnRequest.UseVisualStyleBackColor = false;
            btnRequest.Click += btnRequest_Click;
            // 
            // btnRemoteRequest
            // 
            btnRemoteRequest.BackColor = Color.FromArgb(255, 192, 192);
            btnRemoteRequest.Location = new Point(12, 423);
            btnRemoteRequest.Name = "btnRemoteRequest";
            btnRemoteRequest.Size = new Size(776, 28);
            btnRemoteRequest.TabIndex = 2;
            btnRemoteRequest.Text = "Send Remote Request";
            btnRemoteRequest.UseVisualStyleBackColor = false;
            btnRemoteRequest.Click += btnRemoteRequest_Click;
            // 
            // txtHTTP
            // 
            txtHTTP.Location = new Point(112, 347);
            txtHTTP.Name = "txtHTTP";
            txtHTTP.Size = new Size(583, 23);
            txtHTTP.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(68, 350);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 4;
            label1.Text = "HTTP:";
            label1.Click += label1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 255, 255);
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(txtHTTP);
            Controls.Add(btnRemoteRequest);
            Controls.Add(btnRequest);
            Controls.Add(txtResult);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtResult;
        private Button btnRequest;
        private Button btnRemoteRequest;
        private TextBox txtHTTP;
        private Label label1;
    }
}
