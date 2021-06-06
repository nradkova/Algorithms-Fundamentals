using System;

namespace _07._2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n =int.Parse(Console.ReadLine());
            Console.WriteLine(GetFibonacci(n));
        }

        private static ulong GetFibonacci(int n)
        {
            ulong first = 0;
            ulong second = 1;
            ulong result = 0;
            for (int i = 1; i <= n; i++)
            {
                result = first + second;
                first = second;
                second = result;
            }
            return result;
        }
    }
}
