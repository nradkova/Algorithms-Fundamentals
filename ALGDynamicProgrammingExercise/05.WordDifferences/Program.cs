using System;
using System.Linq;

namespace _05.WordDifferences
{
    class Program
    {
        static void Main(string[] args)
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();

            var table = new int[first.Length + 1, second.Length + 1];
            for (int row = 1; row < table.GetLength(0); row++)
            {
                table[row, 0] = row;
            }
            for (int col = 1; col < table.GetLength(1); col++)
            {
                table[0, col] = col;
            }

            for (int row = 1; row < table.GetLength(0); row++)
            {
                for (int col = 1; col < table.GetLength(1); col++)
                {
                    if (first[row - 1] == second[col - 1])
                    {
                        table[row, col] = table[row - 1, col - 1];
                    }
                    else
                    {
                        table[row, col] = Math.Min
                            (table[row, col - 1]+1,
                            table[row - 1, col] + 1);
                    }
                }
            }
            Console.WriteLine($"Deletions and Insertions: {table[first.Length, second.Length]}");
        }
    }
}
