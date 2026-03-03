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
            btnStart = new Button();
            lblCoffee = new Label();
            lblEggs = new Label();
            lblBacon = new Label();
            lblToast = new Label();
            lblJuice = new Label();
            progressBar1 = new ProgressBar();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(357, 34);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(83, 25);
            btnStart.TabIndex = 0;
            btnStart.Text = "button1";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // lblCoffee
            // 
            lblCoffee.AutoSize = true;
            lblCoffee.Location = new Point(372, 104);
            lblCoffee.Name = "lblCoffee";
            lblCoffee.Size = new Size(50, 20);
            lblCoffee.TabIndex = 1;
            lblCoffee.Text = "label1";
            // 
            // lblEggs
            // 
            lblEggs.AutoSize = true;
            lblEggs.Location = new Point(229, 152);
            lblEggs.Name = "lblEggs";
            lblEggs.Size = new Size(50, 20);
            lblEggs.TabIndex = 2;
            lblEggs.Text = "label2";
            // 
            // lblBacon
            // 
            lblBacon.AutoSize = true;
            lblBacon.Location = new Point(372, 152);
            lblBacon.Name = "lblBacon";
            lblBacon.Size = new Size(50, 20);
            lblBacon.TabIndex = 3;
            lblBacon.Text = "label3";
            // 
            // lblToast
            // 
            lblToast.AutoSize = true;
            lblToast.Location = new Point(548, 152);
            lblToast.Name = "lblToast";
            lblToast.Size = new Size(50, 20);
            lblToast.TabIndex = 4;
            lblToast.Text = "label4";
            // 
            // lblJuice
            // 
            lblJuice.AutoSize = true;
            lblJuice.Location = new Point(372, 198);
            lblJuice.Name = "lblJuice";
            lblJuice.Size = new Size(50, 20);
            lblJuice.TabIndex = 5;
            lblJuice.Text = "label5";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(341, 264);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(110, 25);
            progressBar1.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(progressBar1);
            Controls.Add(lblJuice);
            Controls.Add(lblToast);
            Controls.Add(lblBacon);
            Controls.Add(lblEggs);
            Controls.Add(lblCoffee);
            Controls.Add(btnStart);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private Label lblCoffee;
        private Label lblEggs;
        private Label lblBacon;
        private Label lblToast;
        private Label lblJuice;
        private ProgressBar progressBar1;
    }
}
