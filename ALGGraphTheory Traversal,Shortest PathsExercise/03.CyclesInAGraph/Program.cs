using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.CyclesInAGraph
{
    class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static HashSet<string> visited;
        private static HashSet<string> cycles;
        private static bool IsAcyclic;

        static void Main(string[] args)
        {
            graph = new Dictionary<string, List<string>>();
            visited = new HashSet<string>();
            cycles = new HashSet<string>();
            IsAcyclic = true;

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] tokens = input.Split("-");
                var node = tokens[0];
                var child = tokens[1];
                if (!graph.ContainsKey(node))
                {
                    graph.Add(node, new List<string>() { child });
                }
                else
                {
                    graph[node].Add(child);
                }
                if (!graph.ContainsKey(child))
                {
                    graph.Add(child, new List<string>());
                }
                input = Console.ReadLine();
            }
           
            foreach (var node in graph.Keys)
            {
                DFS(node);
                if (!IsAcyclic)
                {
                    Console.WriteLine("Acyclic: No");
                    return;
                }
            }
            Console.WriteLine("Acyclic: Yes");
            
        }

        private static void DFS(string node)
        {
            if (cycles.Contains(node))
            {
                IsAcyclic = false;
                return;
            }
            if (visited.Contains(node))
            {
                return;
            }
            visited.Add(node);
            cycles.Add(node);
            foreach (var child in graph[node])
            {
                DFS(child);
            }
            cycles.Remove(node);
        }
    }
}
