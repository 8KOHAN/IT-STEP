namespace WinFormsApp4
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
            txtWords = new TextBox();
            txtOutput = new TextBox();
            btnResume = new Button();
            btnLoadWords = new Button();
            btnStop = new Button();
            btnPause = new Button();
            btnStart = new Button();
            progressBar1 = new ProgressBar();
            listBox1 = new ListBox();
            SuspendLayout();
            // 
            // txtWords
            // 
            txtWords.Location = new Point(12, 12);
            txtWords.Name = "txtWords";
            txtWords.Size = new Size(268, 27);
            txtWords.TabIndex = 0;
            // 
            // txtOutput
            // 
            txtOutput.Location = new Point(286, 12);
            txtOutput.Name = "txtOutput";
            txtOutput.Size = new Size(392, 27);
            txtOutput.TabIndex = 2;
            // 
            // btnResume
            // 
            btnResume.Location = new Point(165, 342);
            btnResume.Name = "btnResume";
            btnResume.Size = new Size(149, 37);
            btnResume.TabIndex = 3;
            btnResume.Text = "Resume";
            btnResume.UseVisualStyleBackColor = true;
            // 
            // btnLoadWords
            // 
            btnLoadWords.Location = new Point(350, 299);
            btnLoadWords.Name = "btnLoadWords";
            btnLoadWords.Size = new Size(123, 80);
            btnLoadWords.TabIndex = 5;
            btnLoadWords.Text = "Load Words";
            btnLoadWords.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(12, 342);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(147, 37);
            btnStop.TabIndex = 7;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            // 
            // btnPause
            // 
            btnPause.Location = new Point(165, 299);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(149, 37);
            btnPause.TabIndex = 9;
            btnPause.Text = "Pause";
            btnPause.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(12, 299);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(147, 37);
            btnStart.TabIndex = 11;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(751, 495);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(491, 37);
            progressBar1.TabIndex = 12;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(751, 12);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(491, 464);
            listBox1.TabIndex = 13;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1254, 544);
            Controls.Add(listBox1);
            Controls.Add(progressBar1);
            Controls.Add(btnStart);
            Controls.Add(btnPause);
            Controls.Add(btnStop);
            Controls.Add(btnLoadWords);
            Controls.Add(btnResume);
            Controls.Add(txtOutput);
            Controls.Add(txtWords);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtWords;
        private TextBox txtOutput;
        private Button btnResume;
        private Button btnLoadWords;
        private Button btnStop;
        private Button btnPause;
        private Button btnStart;
        private ProgressBar progressBar1;
        private ListBox listBox1;
    }
}
