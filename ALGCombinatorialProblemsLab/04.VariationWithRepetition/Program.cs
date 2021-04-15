using System;

namespace _04.VariationWithRepetition
{
    class Program
    {
        private static string[] set;
        private static string[] variations;
        static void Main(string[] args)
        {
            set = Console.ReadLine().Split();
            int k =int.Parse(Console.ReadLine());
            variations = new string[k];
            FindVariations(0);
        }

        private static void FindVariations(int index)
        {
            if (index>=variations.Length)
            {
                Console.WriteLine(string.Join(" ",variations));
                return;
            }

            for (int i = 0; i < set.Length; i++)
            {
                variations[index] = set[i];
                FindVariations(index + 1);
            }
        }
    }
}
