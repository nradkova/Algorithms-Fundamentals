using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.EditDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            int replace =int.Parse(Console.ReadLine());
            int insert =int.Parse(Console.ReadLine());
            int delete =int.Parse(Console.ReadLine());
            string first = Console.ReadLine();
            string second = Console.ReadLine();

            var table = new int[first.Length + 1, second.Length + 1];
            for (int row = 1; row < table.GetLength(0); row++)
            {
                table[row, 0] = table[row-1,0]+delete;
            }
            for (int col = 1; col < table.GetLength(1); col++)
            {
                table[0, col] = table[0,col-1] + insert;
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
                        var neighbours= new List<int>() {table[row, col - 1]+insert,
                            table[row - 1, col]+delete, table[row - 1, col - 1]+replace };

                        table[row, col] = neighbours.Min();
                    }
                }
            }
            Console.WriteLine($"Minimum edit distance: {table[first.Length, second.Length]}");
        }
    }
}
