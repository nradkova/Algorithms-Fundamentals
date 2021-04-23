using System;

namespace _03.LCS
{
    class Program
    {
        static void Main(string[] args)
        {
            string first =Console.ReadLine();
            string second =Console.ReadLine();
            int[,] matrix = new int[first.Length + 1, second.Length + 1];
            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    if (first[row-1]==second[col-1])
                    {
                        matrix[row, col] = matrix[row - 1, col - 1] + 1;
                    }
                    else
                    {
                        matrix[row, col] =
                            Math.Max(matrix[row - 1, col], matrix[row, col - 1]);
                    }
                }
            }
            Console.WriteLine(matrix[first.Length,second.Length]);
        }
    }
}
