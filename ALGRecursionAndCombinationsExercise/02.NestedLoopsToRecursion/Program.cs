using System;

namespace _02.NestedLoopsToRecursion
{
    class Program
    {
        private static int[] combinations;
        private static int n;
        static void Main(string[] args)
        {
            n =int.Parse(Console.ReadLine());
            combinations = new int[n];
            FindCombinations(0);
        }

        private static void FindCombinations(int index)
        {
            if (index>=combinations.Length)
            {
                Console.WriteLine(string.Join(" ",combinations));
                return;
            }
           
            for (int i = 1; i <= n; i++)
            {
                combinations[index] = i;
                FindCombinations(index + 1);
            }
        }
    }
}
