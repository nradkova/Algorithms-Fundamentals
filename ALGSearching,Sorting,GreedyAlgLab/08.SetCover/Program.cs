using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.SetCover
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> universeSet = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToList();
            int n =int.Parse(Console.ReadLine());
            List<int[]> sets = new List<int[]>();
            List<int[]> selectedSets = new List<int[]>();

            for (int i = 0; i < n; i++)
            {
                int[] set = Console.ReadLine()
               .Split(", ")
               .Select(int.Parse)
               .ToArray();
                sets.Add(set);
            }
           
            while (universeSet.Count>0)
            {
                var currentSet = sets
                    .OrderByDescending(set => set.Count(num => universeSet.Contains(num)))
                    .FirstOrDefault();
                selectedSets.Add(currentSet);
                sets.Remove(currentSet);
                universeSet = universeSet.Where(x => !currentSet.Contains(x)).ToList();
            }
            Console.WriteLine($"Sets to take ({selectedSets.Count}):");
            foreach (var set in selectedSets)
            {
                Console.WriteLine(string.Join(", ",set));
            }
        }
    }
}
