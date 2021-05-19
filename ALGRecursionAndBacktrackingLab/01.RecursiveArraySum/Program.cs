using System;
using System.Linq;

namespace _01.RecursiveArraySum
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int sum = CalculateSum(array, 0);
            Console.WriteLine(sum);
        }

        private static int CalculateSum(int[] array, int index)
        {
            if (index == array.Length)
            {
                return 0;
            }
            return array[index] + CalculateSum(array, index + 1);
        }
    }
}
