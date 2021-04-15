using System;

namespace _07.NChooseKCount
{
    class Program
    {
        static void Main(string[] args)
        {
            int row =int.Parse(Console.ReadLine());
            int col =int.Parse(Console.ReadLine());
            Console.WriteLine(FindBinom(row,col));
        }

        private static int FindBinom(int row, int col)
        {
            if (row<=1|col==0||col==row)
            {
                return 1;
            }
            return FindBinom(row - 1, col) + FindBinom(row - 1, col - 1);
        }
    }
}
