using System;

namespace _04.CombinationsWithoutRepetition
{
    class Program
    {
        private static int[] combinations;
        private static int n;
        private static int k;

        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            k = int.Parse(Console.ReadLine());

            combinations = new int[k];
            FindCombinations(0, 1);
        }

        private static void FindCombinations(int index, int elemInd)
        {
            if (index >= combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int i = elemInd; i <= n; i++)
            {
                combinations[index] = i;
                FindCombinations(index + 1, i+1);
            }
        }
    }
}
