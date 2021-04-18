using System;
using System.Linq;

namespace _03.SumWithUnlimitedAmountOfCoins
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int target = int.Parse(Console.ReadLine());
            var sums = new int[target + 1];
            sums[0] = 1;
            foreach (var num in numbers)
            {
                for (int sum = num; sum < sums.Length; sum++)
                {
                    sums[sum] += sums[sum - num];
                }
            }
            int count = sums[target];
            Console.WriteLine(count);
        }
    }
}
