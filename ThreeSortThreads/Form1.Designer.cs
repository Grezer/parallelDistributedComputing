﻿namespace ThreeSortThreads
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.progressBar3 = new System.Windows.Forms.ProgressBar();
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
            // progressBar1
            // 
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.Name = "progressBar1";
            // 
            // progressBar2
            // 
            resources.ApplyResources(this.progressBar2, "progressBar2");
            this.progressBar2.Name = "progressBar2";
            // 
            // progressBar3
            // 
            resources.ApplyResources(this.progressBar3, "progressBar3");
            this.progressBar3.Name = "progressBar3";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressBar3);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.progressBar1);
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
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.ProgressBar progressBar3;
    }
}

