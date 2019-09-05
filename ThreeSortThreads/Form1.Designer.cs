namespace ThreeSortThreads
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.comboBoxCount = new System.Windows.Forms.ComboBox();
            this.buttonStartSort = new System.Windows.Forms.Button();
            this.labelBubbleSort = new System.Windows.Forms.Label();
            this.labelShellSort = new System.Windows.Forms.Label();
            this.labelQuickSort = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonGenerate
            // 
            resources.ApplyResources(this.buttonGenerate, "buttonGenerate");
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.ButtonGenerate_Click);
            // 
            // comboBoxCount
            // 
            this.comboBoxCount.FormattingEnabled = true;
            this.comboBoxCount.Items.AddRange(new object[] {
            resources.GetString("comboBoxCount.Items"),
            resources.GetString("comboBoxCount.Items1"),
            resources.GetString("comboBoxCount.Items2"),
            resources.GetString("comboBoxCount.Items3")});
            resources.ApplyResources(this.comboBoxCount, "comboBoxCount");
            this.comboBoxCount.Name = "comboBoxCount";
            // 
            // buttonStartSort
            // 
            resources.ApplyResources(this.buttonStartSort, "buttonStartSort");
            this.buttonStartSort.Name = "buttonStartSort";
            this.buttonStartSort.UseVisualStyleBackColor = true;
            this.buttonStartSort.Click += new System.EventHandler(this.ButtonStartSort_Click);
            // 
            // labelBubbleSort
            // 
            resources.ApplyResources(this.labelBubbleSort, "labelBubbleSort");
            this.labelBubbleSort.Name = "labelBubbleSort";
            // 
            // labelShellSort
            // 
            resources.ApplyResources(this.labelShellSort, "labelShellSort");
            this.labelShellSort.Name = "labelShellSort";
            // 
            // labelQuickSort
            // 
            resources.ApplyResources(this.labelQuickSort, "labelQuickSort");
            this.labelQuickSort.Name = "labelQuickSort";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelQuickSort);
            this.Controls.Add(this.labelShellSort);
            this.Controls.Add(this.labelBubbleSort);
            this.Controls.Add(this.buttonStartSort);
            this.Controls.Add(this.comboBoxCount);
            this.Controls.Add(this.buttonGenerate);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.ComboBox comboBoxCount;
        private System.Windows.Forms.Button buttonStartSort;
        private System.Windows.Forms.Label labelBubbleSort;
        private System.Windows.Forms.Label labelShellSort;
        private System.Windows.Forms.Label labelQuickSort;
    }
}

