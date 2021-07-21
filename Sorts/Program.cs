using System;

namespace Sorts
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            var sortedArr = MergeSort(arr);
            Console.WriteLine("Hello World!");
        }

        public static int[] MergeSort(int[] arr)
        {
            if (arr == null || arr.Length == 1)
                return arr;

            var sortedArr = SplitRec(arr);

            return sortedArr;
        }

        private static int[] SplitRec(int[] arr) {
            int[] leftArray, rightArray;

            if (arr.Length == 1)
                return arr;

            if (IsEven(arr.Length)) {
                leftArray = new int[arr.Length / 2];
                Array.Copy(arr, 0, leftArray, 0, arr.Length / 2);

                rightArray = new int[arr.Length / 2];
                Array.Copy(arr, arr.Length / 2, rightArray, 0, arr.Length / 2);
            } else {
                leftArray = new int[arr.Length / 2];
                Array.Copy(arr, 0, leftArray, 0, arr.Length / 2);

                rightArray = new int[arr.Length / 2 + 1];
                Array.Copy(arr, arr.Length / 2, rightArray, 0, arr.Length / 2 + 1);
            }

            int[] sortedLeftArray = SplitRec(leftArray); // Arrays of length 1 are considered sorted
            int[] sortedRightArray = SplitRec(rightArray); // Arrays of length 1 are considered sorted

            return Merge(sortedLeftArray, sortedRightArray);
        }

        private static int[] Merge(int[] leftSortedArray, int[] rightSortedArray) {
            int i = 0, j = 0, n = 0;
            int k = leftSortedArray.Length;
            int m = rightSortedArray.Length;

            int[] sortedArray = new int[k + m];

            while(i < k && j < m) {
                int a = leftSortedArray[i];
                int b = rightSortedArray[j];

                if(a <= b) {
                    sortedArray[n] = a;
                    n++;
                    i++;
                }

                if(a > b) {
                    sortedArray[n] = b;
                    n++;
                    j++;
                }
            }

            while(i < k) {
                sortedArray[n] = leftSortedArray[i];
                i++;
                n++;
            }

            while(j < m) {
                sortedArray[n] = rightSortedArray[j];
                j++;
                n++;
            }

            return sortedArray;
        }

        private static bool IsEven(int num) => num % 2 == 0 ? true : false;
    }
}
