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
            buttonStart = new Button();
            textBoxExtension = new TextBox();
            textBoxPath = new TextBox();
            labelResult = new Label();
            labelSequential = new Label();
            labelParallel = new Label();
            SuspendLayout();
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(278, 164);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(158, 46);
            buttonStart.TabIndex = 0;
            buttonStart.Text = "Start";
            buttonStart.UseVisualStyleBackColor = true;
            // 
            // textBoxExtension
            // 
            textBoxExtension.Location = new Point(594, 111);
            textBoxExtension.Name = "textBoxExtension";
            textBoxExtension.Size = new Size(110, 27);
            textBoxExtension.TabIndex = 1;
            textBoxExtension.Text = "Extension";
            // 
            // textBoxPath
            // 
            textBoxPath.Location = new Point(12, 111);
            textBoxPath.Name = "textBoxPath";
            textBoxPath.Size = new Size(576, 27);
            textBoxPath.TabIndex = 5;
            textBoxPath.Text = "Path";
            // 
            // labelResult
            // 
            labelResult.AutoSize = true;
            labelResult.Location = new Point(76, 283);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(81, 20);
            labelResult.TabIndex = 6;
            labelResult.Text = "Files found";
            // 
            // labelSequential
            // 
            labelSequential.AutoSize = true;
            labelSequential.Location = new Point(76, 335);
            labelSequential.Name = "labelSequential";
            labelSequential.Size = new Size(113, 20);
            labelSequential.TabIndex = 8;
            labelSequential.Text = "Sequential time";
            // 
            // labelParallel
            // 
            labelParallel.AutoSize = true;
            labelParallel.Location = new Point(76, 364);
            labelParallel.Name = "labelParallel";
            labelParallel.Size = new Size(91, 20);
            labelParallel.TabIndex = 10;
            labelParallel.Text = "Parallel time";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(716, 512);
            Controls.Add(labelParallel);
            Controls.Add(labelSequential);
            Controls.Add(labelResult);
            Controls.Add(textBoxPath);
            Controls.Add(textBoxExtension);
            Controls.Add(buttonStart);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonStart;
        private TextBox textBoxExtension;
        private TextBox textBoxPath;
        private Label labelResult;
        private Label labelSequential;
        private Label labelParallel;
    }
}
