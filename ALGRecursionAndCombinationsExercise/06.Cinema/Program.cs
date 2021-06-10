using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Cinema
{
    class Program
    {
        private static HashSet<int> reservedPlaces;
        private static string[] orderedSet;
        private static List<string> names;

        static void Main(string[] args)
        {
            names = Console.ReadLine()
                .Split(", ").ToList();
            orderedSet = new string[names.Count];
            reservedPlaces = new HashSet<int>();

            while (true)
            {
                string input =Console.ReadLine();
                if (input=="generate")
                {
                    break;
                }
                string name = input.Split(" - ")[0];
                int place = int.Parse(input.Split(" - ")[1]);
                orderedSet[place-1] = name;
                reservedPlaces.Add(place-1);
                names.Remove(name);
            }

            FindPossibleOrder(0);
        }

        private static void FindPossibleOrder(int index)
        {
           
            if (index>=names.Count)
            {
                int place = 0;
                for (int i = 0; i < orderedSet.Length; i++)
                {
                    if (!reservedPlaces.Contains(i))
                    {
                        orderedSet[i] = names[place];
                        place++;
                    }
                }
             
                Console.WriteLine(string.Join(" ",orderedSet));
                return;
            }

            FindPossibleOrder(index + 1);

            for (int i =index+1; i < names.Count; i++)
            {
                Swap(index, i);
                FindPossibleOrder(index + 1);
                Swap(index, i);
            }
        }

        private static void Swap(int first, int second)
        {
            string temp = names[first];
            names[first] = names[second];
            names[second] = temp;
        }
    }
}
