using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.DividingPresents
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int totalSum = numbers.Sum();
            int targetSum = totalSum / 2;

            Dictionary<int, int> sums = new Dictionary<int, int>();
            sums = GetFirstSums(numbers);
           
            int firstSum = sums
                .OrderByDescending(x => x.Key)
                .FirstOrDefault(x => x.Key <= targetSum).Key;
            int secondSum = totalSum - firstSum;

            List<int> firtsPresents = new List<int>();
            int firstTargetSum = firstSum;
            while (firstTargetSum!=0)
            {
                var number = sums[firstTargetSum];
                firstTargetSum -= number;
                firtsPresents.Add(number);
            }
            Console.WriteLine($"Difference: {Math.Abs(firstSum-secondSum)}");
            Console.WriteLine($"Alan:{firstSum} Bob:{secondSum}");
            Console.WriteLine($"Alan takes: {string.Join(" ",firtsPresents)}");
            Console.WriteLine("Bob takes the rest.");
        }

        private static Dictionary<int, int> GetFirstSums(int[] numbers)
        {
            Dictionary<int, int> result = new Dictionary<int, int>() { { 0,0} };
            foreach (var num in numbers)
            {
                var currentSums = result.Keys.ToArray();
                foreach (var sum in currentSums)
                {
                    var newSum = num + sum;
                    if (!result.ContainsKey(newSum))
                    {
                        result[newSum] = num;
                    }
                }
            }
            return result;
        }
    }
}
