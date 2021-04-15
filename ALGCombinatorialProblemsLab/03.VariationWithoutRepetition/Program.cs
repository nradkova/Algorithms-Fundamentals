using System;

namespace _03.VariationWithoutRepetition
{
    class Program
    {
        private static string[] set;
        private static string[] variations;
        private static bool[] used;

        static void Main(string[] args)
        {
            set = Console.ReadLine().Split();
            int k=int.Parse(Console.ReadLine());
            variations = new string[k];
            used = new bool[set.Length];
            FindVariations(0);
        }

        private static void FindVariations(int index)
        {
            if (index>=variations.Length)
            {
                Console.WriteLine(string.Join(" ",variations));
                return;
            }

            for (int i =0; i < set.Length; i++)
            {
                if (!used[i])
                {
                    variations[index] = set[i];
                    used[i] = true;
                    FindVariations(index + 1);
                    used[i] = false;
                }

            }
        }
    }
}
