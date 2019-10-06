using System;
using System.Diagnostics;
namespace ThreeSortThreads
{
    class shellSort
    {
        public event Action<int> ss_progressBar;
        public event Action<string> ss_finished;

        public ulong countIteration = 0;
        public ulong countChanges = 0;
        public Stopwatch stopWatch = new Stopwatch();
        public void startSorting(int[] unsortedArray)
        {
            stopWatch.Start();
            int[] sortedArray = new int[unsortedArray.Length];
            unsortedArray.CopyTo(sortedArray, 0);
            int i, j, pos, temp;
            pos = sortedArray.Length / 2;
            while (pos > 0)
            {
                for (i = 0; i < sortedArray.Length; i++)
                {
                    j = i;
                    temp = sortedArray[i];
                    while ((j >= pos) && (sortedArray[j - pos] > temp))
                    {
                        sortedArray[j] = sortedArray[j - pos];
                        j = j - pos;
                        countIteration++; 
                    }
                    sortedArray[j] = temp;
                    countChanges++;
                }
                if (pos / 2 != 0)
                    pos = pos / 2;
                else
                    pos = pos == 1 ? 0 : 1;
                ss_progressBar((0 - pos + (sortedArray.Length / 2)) / (sortedArray.Length / 2) * 100);
            }
            stopWatch.Stop();
            ss_finished("Shell sort: " +
                                    System.Environment.NewLine +
                                    "Iterations: " + countIteration +
                                    System.Environment.NewLine +
                                    "Changes: " + countChanges +
                                    System.Environment.NewLine +
                                    "Total ticks: " + stopWatch.ElapsedTicks);
        }
    }
}

