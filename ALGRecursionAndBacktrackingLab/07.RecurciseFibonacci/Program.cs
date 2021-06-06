using System;

namespace _07.RecurciseFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            if (n>=1&&n<=49)
            {
            Console.WriteLine(GetFibonacci(n));
            }

        }

        private static int GetFibonacci(int n)
        {
            if (n<=1)
            {
                return 1;
            }
           return GetFibonacci(n - 1) + GetFibonacci(n - 2);
        }
    }
}
