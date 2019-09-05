using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;



namespace ThreeSortThreads
{
    public partial class Form1 : Form
    {
        int[] unsortedArray;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labelBubbleSort.Text = "";
            labelShellSort.Text = "";
            labelQuickSort.Text = "";
            buttonStartSort.Enabled = false;
        }

        private void ButtonGenerate_Click(object sender, EventArgs e)
        {
            /*
             * Быстрый костыль, что бы не париться с sharedMemory
             * Ходят легенды, что за такое руки отрывают ¯\_(ツ)_/¯
            */
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            /* А вот так правильно:
             * Invoke вызывает делегат синхронно, BeginInvoke - асинхронно
             * 
             * delegate void Del(string text);             
             * textBox1.Invoke(new Del((s) => textBox1.Text = s), "newText");             
             * void SetTextSafe(string newText)
             * {
             *      if (textBox1.InvokeRequired) textBox1.Invoke(new Action<string>((s) => textBox1.Text = s), newText);
             *      else textBox1.Text = newText;
             * }
             * Ну или через Task, но это уже совсем другая история :)
             */
            Random rnd = new Random();
            uint sizeArray;
            if (uint.TryParse(comboBoxCount.Text, out sizeArray))
            {
                unsortedArray = Enumerable.Range(0, Convert.ToInt32(sizeArray)).OrderBy(x => rnd.Next()).ToArray();
                buttonStartSort.Enabled = true;
            }
            else
                buttonStartSort.Enabled = false;
            labelBubbleSort.Text = "";
            labelShellSort.Text = "";
            labelQuickSort.Text = "";
        }

        private void ButtonStartSort_Click(object sender, EventArgs e)
        {
            labelBubbleSort.Text = "";
            labelShellSort.Text = "";
            labelQuickSort.Text = "";
            Thread threadBubbleSort = new Thread(new ParameterizedThreadStart(bubbleSort));
            Thread threadShellSort = new Thread(new ParameterizedThreadStart(shellSort));
            Thread threadQuickSort = new Thread(new ParameterizedThreadStart(quickSort));
            threadBubbleSort.Start(unsortedArray);
            threadShellSort.Start(unsortedArray);
            threadQuickSort.Start(unsortedArray);
        }

        private void bubbleSort(object unsortedArray)
        {
            var Sort = new bubbleSort();
            var result = Sort.startSorting((int[])unsortedArray);
            labelBubbleSort.Text = "Bubble sort:" +
                                    System.Environment.NewLine +
                                    "Iterations: " + Sort.countIteration +
                                    System.Environment.NewLine +
                                    "Changes: " + Sort.countChanges +
                                    System.Environment.NewLine +
                                    "Total ticks: " + Sort.stopWatch.ElapsedTicks;
        }

        private void shellSort(object unsortedArray)
        {
            var Sort = new shellSort();
            var result = Sort.startSorting((int[])unsortedArray);
            labelShellSort.Text = "Shell sort:" +
                                    System.Environment.NewLine +
                                    "Iterations: " + Sort.countIteration +
                                    System.Environment.NewLine +
                                    "Changes: " + Sort.countChanges +
                                    System.Environment.NewLine +
                                    "Total ticks: " + Sort.stopWatch.ElapsedTicks;
        }
        private void quickSort(object unsortedArray)
        {
            var Sort = new quickSort();
            var result = Sort.startSorting((int[])unsortedArray);
            labelQuickSort.Text = "Quick sort:" +
                                    System.Environment.NewLine +
                                    "Iterations: " + Sort.countIteration +
                                    System.Environment.NewLine +
                                    "Changes: " + Sort.countChanges +
                                    System.Environment.NewLine +
                                    "Total ticks: " + Sort.stopWatch.ElapsedTicks;
        }
    }
}
