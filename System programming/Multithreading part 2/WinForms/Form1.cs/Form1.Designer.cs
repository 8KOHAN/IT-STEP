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
            buttonOpen = new Button();
            buttonEncrypt = new Button();
            buttonCancel = new Button();
            textPath = new TextBox();
            numericKey = new NumericUpDown();
            labelStatus = new Label();
            openFileDialog1 = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)numericKey).BeginInit();
            SuspendLayout();
            // 
            // buttonOpen
            // 
            buttonOpen.Location = new Point(308, 40);
            buttonOpen.Name = "buttonOpen";
            buttonOpen.Size = new Size(101, 38);
            buttonOpen.TabIndex = 0;
            buttonOpen.Text = "Open";
            buttonOpen.UseVisualStyleBackColor = true;
            // 
            // buttonEncrypt
            // 
            buttonEncrypt.Location = new Point(269, 84);
            buttonEncrypt.Name = "buttonEncrypt";
            buttonEncrypt.Size = new Size(91, 32);
            buttonEncrypt.TabIndex = 1;
            buttonEncrypt.Text = "Encrypt";
            buttonEncrypt.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(366, 84);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(94, 32);
            buttonCancel.TabIndex = 2;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // textPath
            // 
            textPath.Location = new Point(203, 146);
            textPath.Name = "textPath";
            textPath.Size = new Size(305, 27);
            textPath.TabIndex = 3;
            // 
            // numericKey
            // 
            numericKey.Location = new Point(516, 12);
            numericKey.Name = "numericKey";
            numericKey.Size = new Size(132, 27);
            numericKey.TabIndex = 4;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(121, 58);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(50, 20);
            labelStatus.TabIndex = 5;
            labelStatus.Text = "Ready";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelStatus);
            Controls.Add(numericKey);
            Controls.Add(textPath);
            Controls.Add(buttonCancel);
            Controls.Add(buttonEncrypt);
            Controls.Add(buttonOpen);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numericKey).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonOpen;
        private Button buttonEncrypt;
        private Button buttonCancel;
        private TextBox textPath;
        private NumericUpDown numericKey;
        private Label labelStatus;
        private OpenFileDialog openFileDialog1;
    }
}
