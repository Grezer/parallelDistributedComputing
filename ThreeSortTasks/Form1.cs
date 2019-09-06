using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreeSortTasks
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

            /*
                Можно запихнуть тело метода прямо в deligate, но тогда это будет не читаемый кошмар
                Поэтому сделал так
            */
            Action<object> bubbleSortDel = bubbleSort;
            Action<object> shellSortDel = shellSort;
            Action<object> quickSortDel = quickSort;
            bubbleSortDel.BeginInvoke(unsortedArray, bubbleSortDel.EndInvoke, unsortedArray);
            shellSortDel.BeginInvoke(unsortedArray, shellSortDel.EndInvoke, unsortedArray);
            quickSortDel.BeginInvoke(unsortedArray, quickSortDel.EndInvoke, unsortedArray);

            /*
                Вариант через Task
                Все три метода должны возвращать string
            */            
            //var taskBubble = Task<string>.Factory.StartNew(() => bubbleSort(unsortedArray));            
            //var taskShell = Task<string>.Factory.StartNew(() => shellSort(unsortedArray));
            //var taskQuick = Task<string>.Factory.StartNew(() => quickSort(unsortedArray));
            //taskBubble.ContinueWith(x => labelBubbleSort.Text = taskBubble.Result);
            //taskShell.ContinueWith(x => labelShellSort.Text = taskShell.Result);
            //taskQuick.ContinueWith(x => labelQuickSort.Text = taskQuick.Result);
        }
        private void bubbleSort(object unsortedArray)
        {
            var Sort = new bubbleSort();
            Sort.startSorting((int[])unsortedArray);
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
    }
}