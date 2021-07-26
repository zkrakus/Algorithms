using System;
using System.Collections.Generic;

namespace AmazonQuestion2
{
    class Program
    {
        static void Main(string[] args) {
            countAnalogousArrays(new List<int> { -2,-1,0,1,2}, -2, 12);
        }

        public static int countAnalogousArrays(List<int> consecutiveDifference, int lowerBound, int upperBound) {
            var length = consecutiveDifference.Count;
            var analogousArr = new int[length];

            int accumulator = lowerBound;
            int localUpperBound = int.MinValue;
            int localLowerBound = int.MaxValue;
            for (int i = 0; i < length; i++) {
                analogousArr[i] = accumulator + consecutiveDifference[i];
                localUpperBound = Math.Max(consecutiveDifference[i], localUpperBound);
                localLowerBound = Math.Min(consecutiveDifference[i], localLowerBound);
            }

            int analogs = 0, lower = localLowerBound, upper = localUpperBound;
            for(int i = localLowerBound; i <= upperBound; i++) {
                if (lower >= lowerBound && upper <= upperBound)
                    analogs++;
                lower++; upper++;
            }
            
            return analogs;
        }
    }
}
