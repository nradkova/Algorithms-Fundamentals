using System;

namespace _05.CombinationWithoutRepetition
{
    class Program
    {
        private static string[] set;
        private static string[] combinations;

        static void Main(string[] args)
        {
            set = Console.ReadLine().Split();
            int k =int.Parse(Console.ReadLine());
            combinations = new string[k];
            FindCombinations(0, 0);
        }

        private static void FindCombinations(int setInd, int combInd)
        {
            if (combInd>=combinations.Length)
            {
                Console.WriteLine(string.Join(" ",combinations));
                return;
            }

            for (int i = setInd; i < set.Length; i++)
            {
                combinations[combInd] = set[i];
                FindCombinations(i + 1, combInd + 1);
            }
        }
    }
}
