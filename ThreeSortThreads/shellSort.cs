using System.Diagnostics;
namespace ThreeSortThreads
{
    class shellSort
    {
        public ulong countIteration = 0;
        public ulong countChanges = 0;
        public Stopwatch stopWatch = new Stopwatch();
        public int[] startSorting(int[] unsortedArray)
        {
            stopWatch.Start();
            int[] sortedArray = new int[unsortedArray.Length];
            unsortedArray.CopyTo(sortedArray, 0);
            int i, j, pos, temp;
            pos = 3;
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
                else if (pos == 1)
                    pos = 0;
                else
                    pos = 1;
            }
            stopWatch.Stop();
            return sortedArray;
        }
    }
}

