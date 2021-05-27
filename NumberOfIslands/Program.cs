using System;
using System.Collections.Generic;

// Reference: https://leetcode.com/problems/number-of-islands/

namespace NumberOfIslands
{
    class Program
    {
        static void Main(string[] args)
        {
            char[][] grid = new char[][]
            {
                new char[] { '0','1' },
                new char[] { '1','0' },
            };

            NumIslands(grid);
        }

        public static int NumIslands(char[][] grid)
        {
            HashSet<(int, int)> islands = new HashSet<(int, int)>();
            int numIslands = 0;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    char c = grid[i][j];
                    if (!IsIsland(c) || islands.Contains((i,j)))
                    {
                        continue;
                    } else if(IsIsland(c))
                    {
                        numIslands++;
                        CheckAndMarkEntireIsland(i, j);
                    }
                }
            }

            return numIslands;

            void CheckAndMarkEntireIsland(int i, int j)
            {
                if (i < 0 || i >= grid.Length)
                    return;

                if (j < 0 || j >= grid[i].Length)
                    return;

                if (IsIsland(grid[i][j]) && !islands.Contains((i,j)))
                {
                    islands.Add((i, j));
                    CheckAndMarkEntireIsland(i + 1, j);
                    CheckAndMarkEntireIsland(i - 1, j);
                    CheckAndMarkEntireIsland(i, j + 1);
                    CheckAndMarkEntireIsland(i, j - 1);
                }
            }

            bool IsIsland(char c)
            {
                return c == '1' ? true : false;
            }
        }
    }
}
