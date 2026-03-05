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
            components = new System.ComponentModel.Container();
            dataGridView1 = new DataGridView();
            buttonStart = new Button();
            buttonKill = new Button();
            buttonNotepad = new Button();
            buttonCalc = new Button();
            buttonPaint = new Button();
            buttonCustom = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            numericInterval = new NumericUpDown();
            textStartTime = new TextBox();
            textThreads = new TextBox();
            textCopies = new TextBox();
            textCPU = new TextBox();
            textPID = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericInterval).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2 });
            dataGridView1.Location = new Point(12, 240);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 45;
            dataGridView1.Size = new Size(268, 276);
            dataGridView1.TabIndex = 0;
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(12, 67);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(178, 46);
            buttonStart.TabIndex = 1;
            buttonStart.Text = "Start update";
            buttonStart.UseVisualStyleBackColor = true;
            // 
            // buttonKill
            // 
            buttonKill.Location = new Point(380, 15);
            buttonKill.Name = "buttonKill";
            buttonKill.Size = new Size(127, 46);
            buttonKill.TabIndex = 2;
            buttonKill.Text = "Kill process";
            buttonKill.UseVisualStyleBackColor = true;
            // 
            // buttonNotepad
            // 
            buttonNotepad.Location = new Point(513, 15);
            buttonNotepad.Name = "buttonNotepad";
            buttonNotepad.Size = new Size(159, 46);
            buttonNotepad.TabIndex = 3;
            buttonNotepad.Text = "Open Notepad";
            buttonNotepad.UseVisualStyleBackColor = true;
            // 
            // buttonCalc
            // 
            buttonCalc.Location = new Point(513, 67);
            buttonCalc.Name = "buttonCalc";
            buttonCalc.Size = new Size(159, 46);
            buttonCalc.TabIndex = 4;
            buttonCalc.Text = "Open Calculator";
            buttonCalc.UseVisualStyleBackColor = true;
            // 
            // buttonPaint
            // 
            buttonPaint.Location = new Point(513, 119);
            buttonPaint.Name = "buttonPaint";
            buttonPaint.Size = new Size(159, 43);
            buttonPaint.TabIndex = 5;
            buttonPaint.Text = "Open Paint";
            buttonPaint.UseVisualStyleBackColor = true;
            // 
            // buttonCustom
            // 
            buttonCustom.Location = new Point(513, 168);
            buttonCustom.Name = "buttonCustom";
            buttonCustom.Size = new Size(159, 40);
            buttonCustom.TabIndex = 6;
            buttonCustom.Text = "Open Program";
            buttonCustom.UseVisualStyleBackColor = true;
            // 
            // Column1
            // 
            Column1.HeaderText = "ProcessName";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Width = 110;
            // 
            // Column2
            // 
            Column2.HeaderText = "PID";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.Width = 110;
            // 
            // numericInterval
            // 
            numericInterval.Location = new Point(338, 352);
            numericInterval.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            numericInterval.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericInterval.Name = "numericInterval";
            numericInterval.Size = new Size(159, 27);
            numericInterval.TabIndex = 7;
            numericInterval.Value = new decimal(new int[] { 5, 0, 0, 0 });
            numericInterval.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // textStartTime
            // 
            textStartTime.Location = new Point(31, 175);
            textStartTime.Name = "textStartTime";
            textStartTime.Size = new Size(148, 27);
            textStartTime.TabIndex = 8;
            // 
            // textThreads
            // 
            textThreads.Location = new Point(207, 175);
            textThreads.Name = "textThreads";
            textThreads.Size = new Size(135, 27);
            textThreads.TabIndex = 10;
            // 
            // textCopies
            // 
            textCopies.Location = new Point(348, 156);
            textCopies.Name = "textCopies";
            textCopies.Size = new Size(119, 27);
            textCopies.TabIndex = 12;
            // 
            // textCPU
            // 
            textCPU.Location = new Point(207, 135);
            textCPU.Name = "textCPU";
            textCPU.Size = new Size(135, 27);
            textCPU.TabIndex = 14;
            // 
            // textPID
            // 
            textPID.Location = new Point(31, 135);
            textPID.Name = "textPID";
            textPID.Size = new Size(148, 27);
            textPID.TabIndex = 16;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1025, 519);
            Controls.Add(textPID);
            Controls.Add(textCPU);
            Controls.Add(textCopies);
            Controls.Add(textThreads);
            Controls.Add(textStartTime);
            Controls.Add(numericInterval);
            Controls.Add(buttonCustom);
            Controls.Add(buttonPaint);
            Controls.Add(buttonCalc);
            Controls.Add(buttonNotepad);
            Controls.Add(buttonKill);
            Controls.Add(buttonStart);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericInterval).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button buttonStart;
        private Button buttonKill;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private Button buttonNotepad;
        private Button buttonCalc;
        private Button buttonPaint;
        private Button buttonCustom;
        private System.Windows.Forms.Timer timer1;
        private NumericUpDown numericInterval;
        private TextBox textStartTime;
        private TextBox textThreads;
        private TextBox textCopies;
        private TextBox textCPU;
        private TextBox textPID;
    }
}
