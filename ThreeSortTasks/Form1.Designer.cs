namespace ThreeSortTasks
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelQuickSort = new System.Windows.Forms.Label();
            this.labelShellSort = new System.Windows.Forms.Label();
            this.labelBubbleSort = new System.Windows.Forms.Label();
            this.buttonStartSort = new System.Windows.Forms.Button();
            this.comboBoxCount = new System.Windows.Forms.ComboBox();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelQuickSort
            // 
            this.labelQuickSort.AutoSize = true;
            this.labelQuickSort.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelQuickSort.Location = new System.Drawing.Point(12, 191);
            this.labelQuickSort.Name = "labelQuickSort";
            this.labelQuickSort.Size = new System.Drawing.Size(35, 13);
            this.labelQuickSort.TabIndex = 11;
            this.labelQuickSort.Text = "Quick";
            // 
            // labelShellSort
            // 
            this.labelShellSort.AutoSize = true;
            this.labelShellSort.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelShellSort.Location = new System.Drawing.Point(12, 131);
            this.labelShellSort.Name = "labelShellSort";
            this.labelShellSort.Size = new System.Drawing.Size(30, 13);
            this.labelShellSort.TabIndex = 10;
            this.labelShellSort.Text = "Shell";
            // 
            // labelBubbleSort
            // 
            this.labelBubbleSort.AutoSize = true;
            this.labelBubbleSort.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelBubbleSort.Location = new System.Drawing.Point(12, 71);
            this.labelBubbleSort.Name = "labelBubbleSort";
            this.labelBubbleSort.Size = new System.Drawing.Size(40, 13);
            this.labelBubbleSort.TabIndex = 9;
            this.labelBubbleSort.Text = "Bubble";
            // 
            // buttonStartSort
            // 
            this.buttonStartSort.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonStartSort.Location = new System.Drawing.Point(12, 39);
            this.buttonStartSort.Name = "buttonStartSort";
            this.buttonStartSort.Size = new System.Drawing.Size(160, 23);
            this.buttonStartSort.TabIndex = 8;
            this.buttonStartSort.Text = "Start sorting";
            this.buttonStartSort.UseVisualStyleBackColor = true;
            // 
            // comboBoxCount
            // 
            this.comboBoxCount.FormattingEnabled = true;
            this.comboBoxCount.Items.AddRange(new object[] {
            "1000",
            "10000",
            "100000",
            "500000"});
            this.comboBoxCount.Location = new System.Drawing.Point(12, 12);
            this.comboBoxCount.Name = "comboBoxCount";
            this.comboBoxCount.Size = new System.Drawing.Size(79, 21);
            this.comboBoxCount.TabIndex = 7;
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonGenerate.Location = new System.Drawing.Point(97, 12);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(75, 23);
            this.buttonGenerate.TabIndex = 6;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.ButtonGenerate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(187, 262);
            this.Controls.Add(this.labelQuickSort);
            this.Controls.Add(this.labelShellSort);
            this.Controls.Add(this.labelBubbleSort);
            this.Controls.Add(this.buttonStartSort);
            this.Controls.Add(this.comboBoxCount);
            this.Controls.Add(this.buttonGenerate);
            this.Name = "Form1";
            this.Text = ":)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelQuickSort;
        private System.Windows.Forms.Label labelShellSort;
        private System.Windows.Forms.Label labelBubbleSort;
        private System.Windows.Forms.Button buttonStartSort;
        private System.Windows.Forms.ComboBox comboBoxCount;
        private System.Windows.Forms.Button buttonGenerate;
    }
}

