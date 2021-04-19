using System;
using System.Linq;

namespace _06.ConnectingCables
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] first = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] second = first.OrderBy(x => x).ToArray();


            var table = new int[first.Length + 1, second.Length + 1];

            for (int row = 1; row < table.GetLength(0); row++)
            {
                for (int col = 1; col < table.GetLength(1); col++)
                {
                    if (first[row - 1] == second[col - 1])
                    {
                        table[row, col] = table[row - 1, col - 1] + 1;
                    }
                    else
                    {
                        table[row, col] = Math.Max(table[row, col - 1], table[row - 1, col]);
                    }
                }
            }
            Console.WriteLine($"Maximum pairs connected: {table[first.Length, second.Length]}");
        }
    }
}
