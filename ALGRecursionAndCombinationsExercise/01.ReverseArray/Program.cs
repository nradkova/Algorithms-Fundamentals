using System;

namespace _01.ReverseArray
{
    class Program
    {
        private static string[] set;

        static void Main(string[] args)
        {
            set = Console.ReadLine().Split();
            ReverseArray(0, set.Length - 1);

        }

        private static void ReverseArray(int start, int end)
        {
            if (start >= end)
            {
                Console.WriteLine(string.Join(" ", set));
                return;
            }
            string temp = set[start];
            set[start] = set[end];
            set[end] = temp;
            ReverseArray(start + 1, end - 1);

        }
    }
}
