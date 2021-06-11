using System;
using System.Linq;

namespace _03.BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            BubbleSort(numbers);
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void BubbleSort(int[] numbers)
        {
            bool isSorted = false;
            int sortingCounter = 0;
            while (!isSorted)
            {
                isSorted = true;
                for (int i = 1; i < numbers.Length; i++)
                {
                    if (numbers[i - 1] > numbers[i])
                    {
                        Swap(numbers, i, i - 1);
                        isSorted = false;
                    }
                }
                sortingCounter++;
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
