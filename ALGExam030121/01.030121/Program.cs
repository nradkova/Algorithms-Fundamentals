using System;
using System.Collections.Generic;
using System.Linq;

namespace _01
{
    class Program
    {
        private static char[,] matrix;
        static void Main(string[] args)
        {
            int rows =int.Parse(Console.ReadLine());
            int cols =int.Parse(Console.ReadLine());
            matrix = new char[rows, cols];
            ReadMatrix(matrix);
            int count = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row,col]=='t')
                    {
                        FindArea(row, col);
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
        }

        private static void FindArea(int row, int col)
        {
            if (isInvalid(row,col))
            {
                return;
            }

            matrix[row, col] = 'v';

            FindArea(row + 1, col);
            FindArea(row - 1, col);
            FindArea(row, col + 1);
            FindArea(row, col - 1);
            FindArea(row + 1, col + 1);
            FindArea(row -1, col -1);
            FindArea(row - 1, col + 1);
            FindArea(row +1, col - 1);
        }

        private static bool isInvalid(int row, int col)
        {
            if (row<0||row>=matrix.GetLength(0))
            {
                return true;
            }
            if (col<0||col>=matrix.GetLength(1))
            {
                return true;
            }
            if (matrix[row,col]!='t')
            {
                return true;
            }
            return false;
        }

        private static void ReadMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string line =Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];
                }
            }
        }
    }
}
