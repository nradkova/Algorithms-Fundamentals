using System;
using System.Linq;

namespace _05.Quicksort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            QuickSort(numbers,0,numbers.Length-1);
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void QuickSort(int[] numbers,int start,int end)
        {
            if (start >= end)
            {
                return;
            }
            int pivot = start;
            int leftPointer = start + 1;
            int rightPointer = end;
            while (leftPointer<=rightPointer)
            {
                if (numbers[leftPointer]>numbers[pivot]
                    && numbers[rightPointer]<numbers[pivot])
                {
                    Swap(numbers, rightPointer, leftPointer);
                }
                if (numbers[leftPointer]<=numbers[pivot])
                {
                    leftPointer++;
                }
                if (numbers[rightPointer] >= numbers[pivot])
                {
                    rightPointer--;
                }
            }
            Swap(numbers, pivot, rightPointer);
            bool isLeftSubSmaller = rightPointer - start < end - rightPointer;
            if (isLeftSubSmaller)
            {
                QuickSort(numbers, start, rightPointer - 1);
                QuickSort(numbers, rightPointer+1,end);
            }
            else
            {
                QuickSort(numbers, rightPointer + 1, end);
                QuickSort(numbers, start, rightPointer - 1);
            }
        }
        private static void Swap(int[] numbers, int first, int second)
        {
            int temp = numbers[first];
            numbers[first] = numbers[second];
            numbers[second] = temp;
        }
    }
}
