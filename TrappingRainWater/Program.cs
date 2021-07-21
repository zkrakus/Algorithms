using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace TrappingRainWater
{
    class Program
    {
        static void Main(string[] args) {
            Trap(new int[] { 0, 1, 2, 3, 2, 3, 2, 1, 0, 5 });
        }

        public static int Trap1(int[] height) {
            if (height == null || height.Length < 3)
                return 0;

            int total = 0;

            // iteratre through the entire array 
            for(int i = 0; i < height.Length; i++) {
                int leftMax = 0, rightMax = 0;

                // find the max on the left
                for (int j = i; j >= 0; j--)
                    leftMax = Math.Max(height[j], leftMax);

                // find the max on the right
                for (int j = i; j < height.Length; j++)
                    rightMax = Math.Max(height[j], rightMax);

                // Find the total by finding the lowest edge of the current water basin and remove the loss of volume due to the current height repeadetly.
                total += Math.Min(rightMax, leftMax) - height[i];
            }

            return total;
        }

        public static int Trap(int[] height) {
            if (height == null || height.Length < 3)
                return 0;

            int total = 0;
            int length = height.Length;
            int[] leftMax = new int[length], rightMax = new int[length];

            leftMax[0] = height[0];
            for (int i = 1; i < length; i++)
                leftMax[i] = Math.Max(height[i], leftMax[i - 1]);

            rightMax[length - 1] = height[length - 1];
            for (int i = length - 2; i >= 0; i--)
                rightMax[i] = Math.Max(height[i], rightMax[i + 1]);

            for (int i = 0; i < length - 1; i++)
                total += Math.Min(leftMax[i], rightMax[i]) - height[i];

            return total;
        }
    }
}