using System;

namespace _04.RecursiveFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int n =int.Parse(Console.ReadLine());
           long f= CalculateFactorial(n);
            Console.WriteLine(f);
        }

        private static long CalculateFactorial(int n)
        {
            if (n==0)
            {
              return  1;
            }
            return n * CalculateFactorial(n - 1);
        }
    }
}
