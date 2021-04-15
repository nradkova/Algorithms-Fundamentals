using System;

namespace _01.PermutationWithoutRepetition
{
    class Program
    {
        private static string[] set;

        static void Main(string[] args)
        {
            set = Console.ReadLine().Split();
            FindPermutations(0);
        }

        private static void FindPermutations(int index)
        {
            if (index >= set.Length)
            {
                Console.WriteLine(string.Join(" ", set));
                return;
            }
            FindPermutations(index + 1);
            for (int i = index + 1; i < set.Length; i++)
            {
                SwapElements(index, i);
                FindPermutations(index + 1);
                SwapElements(index, i);
            }
        }

        private static void SwapElements(int index, int i)
        {
            string temp = set[index];
            set[index] = set[i];
            set[i] = temp;
        }
    }
}
