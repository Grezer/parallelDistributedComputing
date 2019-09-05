using System.Diagnostics;
namespace ThreeSortThreads
{
    public class bubbleSort
    {
        public ulong countIteration = 0;
        public ulong countChanges = 0;
        public Stopwatch stopWatch = new Stopwatch();
        public int[] startSorting(int[] unsortedArray)
        {
            stopWatch.Start();
            int[] sortedArray = new int[unsortedArray.Length];
            unsortedArray.CopyTo(sortedArray, 0);
            int temp = 0;
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
            }
            stopWatch.Stop();
            return sortedArray;
        }
    }
}
