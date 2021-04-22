using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.MoveDownRight
{
    class Program
    {
        private static int[,] matrix;
        private static int[,] sums;
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            matrix = ReadMatrix(rows, cols);
            sums = FillSumsMatrix();

            int row = rows - 1;
            int col = cols - 1;
            Stack<string> path = new Stack<string>();
            path.Push($"[{row}, {col}]");

            while (row > 0 && col > 0)
            {
                var upperCell = sums[row - 1, col];
                var leftCell = sums[row, col - 1];
                if (upperCell > leftCell)
                {
                    row--;
                }
                else
                {
                    col--;
                }
                path.Push($"[{row}, {col}]");
            }

            while (row > 0)
            {
                row--;
                path.Push($"[{row}, {col}]");
            }

            while (col > 0)
            {
                col--;
                path.Push($"[{row}, {col}]");
            }

            Console.WriteLine(string.Join(" ", path));
        }

        private static int[,] FillSumsMatrix()
        {
            int[,] result = new int[matrix.GetLength(0), matrix.GetLength(1)];
            result[0, 0] = matrix[0, 0];

            for (int row = 1; row < result.GetLength(0); row++)
            {
                result[row, 0] = result[row - 1, 0] + matrix[row, 0];
            }
            for (int col = 1; col < result.GetLength(1); col++)
            {
                result[0, col] = result[0, col - 1] + matrix[0, col];
            }

            for (int row = 1; row < result.GetLength(0); row++)
            {
                for (int col = 1; col < result.GetLength(1); col++)
                {
                    var upper = result[row - 1, col];
                    var left = result[row, col - 1];

                    result[row, col] = Math.Max(upper, left) + matrix[row, col];
                }
            }

            return result;
        }

        private static int[,] ReadMatrix(int rows, int cols)
        {
            int[,] result = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                int[] input = Console.ReadLine()
                     .Split()
                     .Select(int.Parse)
                     .ToArray();
                for (int col = 0; col < cols; col++)
                {
                    result[row, col] = input[col];
                }
            }
            return result;
        }
    }
}
