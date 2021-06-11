using System;
using System.Linq;

namespace _02.SelectionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            SelectionSort(numbers);
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void SelectionSort(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                int minInd = i;
                for (int j = i+1; j < numbers.Length; j++)
                {
                    if (numbers[j]<numbers[minInd])
                    {
                        minInd = j;
                    }
                }
                Swap(numbers, i, minInd);
            }
        }

        private static void Swap(int[] numbers, int i, int minInd)
        {
            int temp = numbers[i];
            numbers[i] = numbers[minInd];
            numbers[minInd] = temp;
        }
    }
}
