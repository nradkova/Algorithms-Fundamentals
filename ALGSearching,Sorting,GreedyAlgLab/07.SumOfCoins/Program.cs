using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.SumOfCoins
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] coins = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .OrderBy(x => x)
                .ToArray();
            int sum = int.Parse(Console.ReadLine());
            List<string> output = new List<string>();
            int coinsInd = coins.Length - 1;
            int counter = 0;
            int allCoins = 0;

            while (sum>0&&coinsInd>=0)
            {
                if (sum >= coins[coinsInd])
                {
                    counter = sum / coins[coinsInd];
                    sum -= counter * coins[coinsInd];
                    string result = $"{counter} coin(s) with value {coins[coinsInd]}";
                    output.Add(result);
                    allCoins += counter;
                    counter = 0;
                }
                if (sum >0 && coinsInd==0)
                {
                    Console.WriteLine("Error");
                    return;
                }
                coinsInd--;
            }

            Console.WriteLine($"Number of coins to take: {allCoins}");
            foreach (var result in output)
            {
                Console.WriteLine(result);
            }
        }
    }
}
