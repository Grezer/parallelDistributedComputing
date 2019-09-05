using System.Diagnostics;
namespace ThreeSortThreads
{
    class quickSort
    {
        public ulong countIteration = 0;
        public ulong countChanges = 0;
        public Stopwatch stopWatch = new Stopwatch();
        public int[] startSorting(int[] unsortedArray)
        {
            stopWatch.Start();
            int[] sortedArray = new int[unsortedArray.Length];
            unsortedArray.CopyTo(sortedArray, 0);
            int left = 0; int right = sortedArray.Length - 1;
            Quick_Sort(sortedArray, left, right);
            stopWatch.Stop();
            return sortedArray;
        }

        public void Quick_Sort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                countIteration++;
                int pivot = Partition(arr, left, right);
                if (pivot > 1)                
                    Quick_Sort(arr, left, pivot - 1);                
                if (pivot + 1 < right)                
                    Quick_Sort(arr, pivot + 1, right);
                countIteration++;
                countIteration++;
            }
        }

        public int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[left];
            while (true)
            {
                while (arr[left] < pivot)
                {
                    left++;
                    countIteration++;
                }
                while (arr[right] > pivot)
                {
                    right--;
                    countIteration++;
                }
                if (left < right)
                {
                    countIteration++;
                    if (arr[left] == arr[right])
                        return right;
                    countIteration++;
                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                    countChanges++;
                }
                else
                    return right;                
            }
        }
    }
}
