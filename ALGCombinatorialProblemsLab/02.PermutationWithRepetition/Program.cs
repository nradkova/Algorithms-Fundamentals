using System;
using System.Collections.Generic;

namespace _02.PermutationWithRepetition
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
           var swapped = new HashSet<string>() { set[index] };
            for (int i = index + 1; i < set.Length; i++)
            {
                if (!swapped.Contains(set[i]))
                {
                    SwapElements(index, i);
                    FindPermutations(index + 1);
                    SwapElements(index, i);
                    swapped.Add(set[i]);
                }
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
