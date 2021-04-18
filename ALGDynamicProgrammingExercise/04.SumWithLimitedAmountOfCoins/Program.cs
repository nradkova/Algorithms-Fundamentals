using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.SumWithLimitedAmountOfCoins
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
            var sums = new Dictionary<int, int>() { { 0, 1 } };


            foreach (var num in numbers)
            {
                var allsums = sums.Keys.ToArray();
                foreach (var sum in allsums)
                {
                    var newSum = sum + num;
                    if (!sums.ContainsKey(newSum))
                    {
                        sums.Add(newSum, 1);
                    }
                    else
                    {
                        sums[newSum]++;
                    }
                }
            }

            int count = sums[target];
            Console.WriteLine(count);
        }
    }
}
