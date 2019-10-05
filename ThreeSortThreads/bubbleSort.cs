using System;
using System.Diagnostics;
namespace ThreeSortThreads
{
    public class bubbleSort
    {
        public event Action<int> bs_progressBar;
        public event Action<string> bs_finished;

        public ulong countIteration = 0;
        public ulong countChanges = 0;
        public Stopwatch stopWatch = new Stopwatch();
        public void startSorting(int[] unsortedArray)
        {
            stopWatch.Start();
            int[] sortedArray = new int[unsortedArray.Length];
            unsortedArray.CopyTo(sortedArray, 0);
            int temp = 0;
            int iteratorFor = 0;
            for (int write = 0; write < sortedArray.Length; write++)
            {
                for (int sort = 0; sort < sortedArray.Length - 1; sort++)
                {
                    if (sortedArray[sort] > sortedArray[sort + 1])
                    {
                        temp = sortedArray[sort + 1];
                        sortedArray[sort + 1] = sortedArray[sort];
                        sortedArray[sort] = temp;
                        countChanges++;
                    }
                    countIteration++;
                }
                bs_progressBar((int)(100 * (iteratorFor++ / ((double)sortedArray.Length - 1))));
            }
            stopWatch.Stop();
            bs_finished("Bubble sort: " +
                                    System.Environment.NewLine +
                                    "Iterations: " + countIteration +
                                    System.Environment.NewLine +
                                    "Changes: " + countChanges +
                                    System.Environment.NewLine +
                                    "Total ticks: " + stopWatch.ElapsedTicks);
        }
    }
}
