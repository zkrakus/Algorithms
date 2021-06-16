using System;
using System.Collections.Generic;
using System.Linq;

namespace MergeIntervals
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static int[][] Merge(int[][] intervals)
        {
            if (intervals == null || intervals.Length == 0)
                return Array.Empty<int[]>();

            if (intervals.Length == 1)
                return new int[][] { (int[])intervals[0].Clone() };

            // sort intervals
            // Maybe go over a sorting algorithm

            var mergedIntervals = new List<int[]>();
            int i = 0;
            while(i < intervals.Length)
            {
                int mergedStart = intervals[i][0], mergedEnd = intervals[i][1];
                int j = i + 1;
                while (j < intervals.Length && intervals[j][0] <= mergedEnd) {
                    mergedEnd = intervals[j][1];
                    j++;
                }

                mergedIntervals.Add(new int[] { mergedStart, mergedEnd });
                i = j;
            }

            return mergedIntervals.ToArray();
        }
    }
}
