﻿using System;
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
             * Быстрый костыль, что бы не париться с взаимодействием потоков
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
            progressBar1.Value = 0;
            progressBar2.Value = 0;
            progressBar3.Value = 0;
            labelBubbleSort.Text = "";
            labelShellSort.Text = "";
            labelQuickSort.Text = "";
        }

        private void ButtonStartSort_Click(object sender, EventArgs e)
        {
            bubbleSort BS = new bubbleSort();
            BS.bs_progressBar += changeProgressBarBubble;
            BS.bs_finished += bs_finished;
            Thread threadBubble = new Thread(() => BS.startSorting(unsortedArray));

            shellSort SS = new shellSort();
            SS.ss_progressBar += changeProgressBarShell;
            SS.ss_finished += ss_finished;
            Thread threadShell = new Thread(() => SS.startSorting(unsortedArray));            

            quickSort QS = new quickSort();
            QS.qs_progressBar += changeProgressBarQuick;
            QS.qs_finished += qs_finished;
            Thread threadQuick = new Thread(() => QS.startSorting(unsortedArray));        

            threadShell.Start();
            threadBubble.Start();
            threadQuick.Start();

            //Thread threadBubbleSort = new Thread(new ParameterizedThreadStart(bubbleSort));
            //Thread threadShellSort = new Thread(new ParameterizedThreadStart(shellSort));
            //Thread threadQuickSort = new Thread(new ParameterizedThreadStart(quickSort));
            //threadBubbleSort.Start(unsortedArray);
            //threadShellSort.Start(unsortedArray);
            //threadQuickSort.Start(unsortedArray);
        }

        private void bubbleSort(object unsortedArray)
        {
            //var Sort = new bubbleSort();
            //Sort.bs_progressBar += changeProgressBar;
            //var result = Sort.startSorting((int[])unsortedArray);
            //labelBubbleSort.Text = "Bubble sort:" +
            //                        System.Environment.NewLine +
            //                        "Iterations: " + Sort.countIteration +
            //                        System.Environment.NewLine +
            //                        "Changes: " + Sort.countChanges +
            //                        System.Environment.NewLine +
            //                        "Total ticks: " + Sort.stopWatch.ElapsedTicks;
        }

        private void shellSort(object unsortedArray)
        {
            var Sort = new shellSort();
            Sort.startSorting((int[])unsortedArray);
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
            Sort.startSorting((int[])unsortedArray);
            labelQuickSort.Text = "Quick sort:" +
                                    System.Environment.NewLine +
                                    "Iterations: " + Sort.countIteration +
                                    System.Environment.NewLine +
                                    "Changes: " + Sort.countChanges +
                                    System.Environment.NewLine +
                                    "Total ticks: " + Sort.stopWatch.ElapsedTicks;
        }

        private void changeProgressBarBubble(int progress)
        {
            Action action = () => { progressBar1.Value = progress; };
            Invoke(action);
        }
        private void bs_finished(string info)
        {
            Action action = () => { labelBubbleSort.Text = info; };
            Invoke(action);
        }

        private void changeProgressBarShell(int progress)
        {
            Action action = () => { progressBar2.Value = progress; };
            Invoke(action);
        }
        private void ss_finished(string info)
        {
            Action action = () => { labelShellSort.Text = info; };
            Invoke(action);
        }

        private void changeProgressBarQuick(int progress)
        {
            Action action = () => { progressBar3.Value = progress; };
            Invoke(action);
        }
        private void qs_finished(string info)
        {
            Action action = () => { labelQuickSort.Text = info; };
            Invoke(action);
        }
    }
}
