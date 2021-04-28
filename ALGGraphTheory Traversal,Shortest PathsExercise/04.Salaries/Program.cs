using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Salaries
{
    class Program
    {
        private static List<int>[] graph;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            graph = ReadGraph(n);

            int totalSalary = 0;
            for (int i = 0; i < graph.Length; i++)
            {
                var node = i;
                int salary = DFS(node);
                totalSalary += salary;
            }
            Console.WriteLine(totalSalary);
        }
        private static int DFS(int node)
        {
            int salary = 0;

            if (graph[node].Count == 0)
            {
                return 1;
            }

            foreach (var child in graph[node])
            {
                salary += DFS(child);
            }
            return salary;
        }
        private static List<int>[] ReadGraph(int n)
        {
            var result = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                result[i] = new List<int>();
                string line = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    if (line[j] == 'Y')
                    {
                        result[i].Add(j);
                    }
                }
            }
            return result;
        }
    }
}
