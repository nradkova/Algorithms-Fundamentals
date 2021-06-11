using System;
using System.Linq;

namespace _01.BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int number =int.Parse(Console.ReadLine());
            int start = 0;
            int end = numbers.Length - 1;
            int result = BinarySearch(numbers,number, start, end);
            Console.WriteLine(result);
        }

        private static int BinarySearch(int[] numbers,int number, int start, int end)
        {
            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (numbers[mid] == number)
                {
                    return mid;
                }
                if (numbers[mid]<number)
                {
                    start = mid + 1;
                }
                if (numbers[mid] > number)
                {
                    end = mid -1;
                }
            }
            return -1;
        }
    }
}
