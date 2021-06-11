using System;
using System.Linq;

namespace _06.MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var sorted = MergeSort(numbers);
            Console.WriteLine(string.Join(" ", sorted));
        }

        private static int[] MergeSort(int[] numbers)
        {
            if (numbers.Length == 1)
            {
                return numbers;
            }
            int[] leftArr = numbers.Take(numbers.Length / 2).ToArray();
            int[] rightArr = numbers.Skip(numbers.Length / 2).ToArray();
            return Merge(MergeSort(leftArr), MergeSort(rightArr));
        }

        private static int[] Merge(int[] leftArr, int[] rightArr)
        {
            int[] mergedArr = new int[leftArr.Length + rightArr.Length];
            int mergedInd = 0;
            int leftInd = 0;
            int rightInd = 0;
            while (leftInd < leftArr.Length
                && rightInd < rightArr.Length)
            {
                if (leftArr[leftInd] < rightArr[rightInd])
                {
                    mergedArr[mergedInd] = leftArr[leftInd];
                    leftInd++;
                }
                else
                {
                    mergedArr[mergedInd] = rightArr[rightInd];
                    rightInd++;
                }
                mergedInd++;
            }
            while (leftInd < leftArr.Length)
            {
                mergedArr[mergedInd] = leftArr[leftInd];
                leftInd++;
                mergedInd++;
            }
            while (rightInd < rightArr.Length)
            {
                mergedArr[mergedInd] = rightArr[rightInd];
                rightInd++;
                mergedInd++;
            }
            return mergedArr;
        }
    }
}
