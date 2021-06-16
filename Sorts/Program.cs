using System;

namespace Sorts
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 10, 8, 1 , 4 , 5 , 3 };
            MergeSort(arr);
            Console.WriteLine("Hello World!");
        }

        public static void MergeSort(int[] arr)
        {
            if (arr == null || arr.Length == 1)
                return;

            Merge(0, arr.Length / 2 - 1, arr.Length / 2, arr.Length - 1, arr);
        }

        private static void Merge(int i, int j, int k, int m, int[] arr)
        {
            if (j - i > 0)
            {
                Merge(i, j / 2, j / 2 + 1, j, arr);
            }

            if (m - k > 0)
            {
                Merge(k, j + m / 2, j + m / 2 + 1, m, arr);
            }

            int n = i;
            while (i <= j && k <= m)
            {
                if (arr[k] < arr[n])
                {
                    swap(n, k, arr);
                    i++;
                }
                else
                {
                    swap(n, i, arr);
                    k++;
                }

                n++;
            }

            while (i < j)
            {
                if (arr[n] < arr[i])
                    swap(n, i, arr);

                i++;
                n++;
            }

            while (k < m)
            {
                if (arr[n] < arr[k])
                    swap(n, k, arr);

                k++;
                n++;
            }
        }

        private static void swap(int i, int j, int[] arr)
        {
            int tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
        }
    }
}
