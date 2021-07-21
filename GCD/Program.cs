using System;

namespace GCD
{
    class Program
    {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
        }

        public static int generalizedGCD(int[] arr) {
            // If null there can be no gcd
            if (arr == null)
                return -1;

            // A number itself is its own gcd
            if (arr.Length == 1)
                return arr[0];

            // 1 is a common divisor to all numbers other than zero.
            int tempGCD = 1;
            int gcd = 1;

            // Iterate through array
            for (int i = 0; i < arr.Length; i++) {
                // Store the gcd by comparing the last to the new
                tempGCD = findGCD(tempGCD, arr[i]);
                if (tempGCD > gcd)
                    gcd = tempGCD;
            }

            return tempGCD;
        }

        // Finding the gcd is based on the Euclidian algorithm. 
        // It's based on the fact that the gcd will not change if we replace the larger number with the difference of the large and smaller number 
        // e.g. 28 - 7 == 21. The gcd of 28 and 7 and 21 are still 7.
        // We can repeat this process untill both numbers are the same.
        private static int findGCD(int a, int b) {
            int c = 0;
            if (a > b) {
                c = a - b;
                return findGCD(c, b);
            } else if (b > a) {
                c = b - a;
                return findGCD(c, a);
            } else
                return a;
        }

        // An optimization of the gcd algorithm involves using the remainder of dividing the large number by the small.
        // An way to think about this to make it intuitive is remember the principles of the unoptimized euclidian algorithm
        // except the modulus operation returns what's left after we subtract the smallest number from the largest the maximum possible amount of times
        // e.g. 28 % 7 = 0. Which is like 28 - 7 x 5 = 0.
        private static int findGCDOptimized(int a, int b) {
            int c = 0;
            if (a > b) {
                c = a % b;
                return findGCDOptimized(c, b);
            } else if (b > a) {
                c = b % a;
                return findGCDOptimized(c, a);
            }
              // Otherwise return the smallest number.
              else if (b % a == 0) {
                if (a < b)
                    return a;
                if (b < a)
                    return b;
            }
            // Couldn't find a gcd.
            return 1;
        }
    }
}
