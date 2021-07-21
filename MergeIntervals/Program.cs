using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MergeIntervals
{
    class Program
    {
        static void Main(string[] args) {
            int[][] arr = new int[][] { new int[] { 2, 3 }, new int[] { 4, 5 }, new int[] { 6, 7 }, new int[] { 8, 9 }, new int[] {1,10} };

            Merge(arr);
        }

        public static int[][] Merge(int[][] intervals) {
            if (intervals == null || intervals.Length == 0)
                return Array.Empty<int[]>();

            if (intervals.Length == 1)
                return new int[][] { (int[])intervals[0].Clone() };

            Array.Sort(intervals, (x, y) => x[0].CompareTo(y[0]));

            var mergedIntervals = new List<int[]>();
            int i = 0;
            while (i < intervals.Length) {
                int mergedStart = intervals[i][0];
                int mergedEnd = intervals[i][1];

                int j = i + 1;
                while (j < intervals.Length && (mergedEnd >=  intervals[j][1] || mergedEnd >= intervals[j][0])) {
                    mergedEnd = (mergedEnd >= intervals[j][1]) ? mergedEnd : intervals[j][1];

                    j++;
                }

                mergedIntervals.Add(new int[] { mergedStart, mergedEnd });
                i = j;
            }

            return mergedIntervals.ToArray();
        }

        private class SortIntervalStart : IComparer
        {
            public int Compare(object x, object y) {
                int[] a = (int[])x;
                int[] b = (int[])y;

                if (a[0] > b[0])
                    return 1;
                else if (a[0] < b[0])
                    return -1;
                else
                    return 0;
            }
        }

        // Given an array of characters return an array of lengths that partions the given array such that each of the returned lengths are of minimum size and contain all the characters of its type. Optimize for fewest possible arrays using this criteria.
        // The intermediary subarrays are for demonstrations only and are not mandatory
        // e.g. [a,b,c] => [a],[b],[c] => [1],[1],[1]
        // abc => [a,b,c,a] => [4]
        // abcdaefge => [a,b,c,d,a],[e,f,g,e] => [5],[4]
        // abcdadefgeg => [a,b,c,d,a],[e,f,g,e,g] => [5],[5]
        // abcdefeggsfppkfpplogs => [abcde], [gsfpkfplogk]  => [5],[11]
        public static int[] FineSceneLength(char[] arr) {
            if (arr == null || arr.Length == 0)
                return new int[] { };

            if (arr.Length == 1)
                return new int[] { 1 };

            int[][] segments = ScenesToSegments(arr);

            Array.Sort(segments, (x, y) => x[0].CompareTo(y[0]));
            var mergedIntervals = new List<int[]>();
            int i = 0;
            while (i < segments.Length) {
                int mergedStart = segments[i][0];
                int mergedEnd = segments[i][1];

                int j = i + 1;
                while (j < segments.Length && (mergedEnd >= segments[j][1] || mergedEnd >= segments[j][0])) {
                    mergedEnd = (mergedEnd >= segments[j][1]) ? mergedEnd : segments[j][1];

                    j++;
                }

                mergedIntervals.Add(new int[] { mergedStart, mergedEnd });
                i = j;
            }

            var sceneLengths = new int[mergedIntervals.Count];
            for (int j = 0; j < sceneLengths.Length; j++) {
                sceneLengths[j] = mergedIntervals[j][1] - mergedIntervals[j][0] + 1;
            }

            return sceneLengths;
        }

        public static int[][] ScenesToSegments(char[] arr) {
            // Building lookup
            Dictionary<char, int[]> elementSet = new Dictionary<char, int[]>();
            for (int i = 0; i < arr.Length; i++) {
                char element = arr[i];

                if (!elementSet.TryGetValue(element, out int[] value))
                    elementSet.Add(element, new int[] { i, i });
                else
                    value[1] = i;
            }

            var segments = new List<int[]>();
            foreach (var item in elementSet.Values) {
                segments.Add(item);
            }

            return segments.ToArray();
        }
    }
}
