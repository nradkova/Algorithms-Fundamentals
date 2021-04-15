using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._040720
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] first = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] second = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var table = new int[first.Length + 1, second.Length + 1];
            for (int r = 1; r < table.GetLength(0); r++)
            {
                for (int c = 1; c < table.GetLength(1); c++)
                {
                    if (first[r - 1] == second[c - 1])
                    {
                        table[r, c] = table[r - 1, c - 1]+1;
                    }
                    else
                    {
                        table[r, c] = Math.Max(table[r, c - 1], table[r - 1, c]);
                    }
                }
            }

            int row = first.Length;
            int col = second.Length;
            Stack<int> path = new Stack<int>();
            while (row>0&&col>0)
            {
                if (first[row - 1] == second[col - 1])
                {
                    row--;
                    col--;
                    path.Push(first[row]);
                }
                else if (table[row-1,col]>table[row,col-1])
                {
                    row--;
                }
                else
                {
                    col--;
                }
            }
            Console.WriteLine(string.Join(" ",path));
            Console.WriteLine(path.Count);
        }
    }
}
