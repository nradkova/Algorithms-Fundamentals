using System;
using System.Collections.Generic;

namespace _01._040720
{
    class Program
    {
        private static Dictionary<string, ulong> memo;
        static void Main(string[] args)
        {
            int n =int.Parse(Console.ReadLine());
            int k =int.Parse(Console.ReadLine());

            memo = new Dictionary<string, ulong>();
            var result = NChooseK(n, k);
            Console.WriteLine(result);
        }

        private static ulong NChooseK(int n, int k)
        {
            var str = $"{n} {k}";
            if (memo.ContainsKey(str))
            {
                return memo[str];
            }
            if (n<=1||k==0||k==n)
            {
                return 1;
            }
            var result = NChooseK(n - 1, k - 1) + NChooseK(n - 1, k);
            memo[str] = result;
            return result;
        }
    }
}
