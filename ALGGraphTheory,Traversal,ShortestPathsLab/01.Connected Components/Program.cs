using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Connected_Components
{
    class Program
    {
        private static Dictionary<int, List<int>> graph;
        private static HashSet<int> visited;
        private static Queue<int> components;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            graph = ReadGraph(n);
            visited = new HashSet<int>();
            foreach (var node in graph.Keys)
            {
                components = new Queue<int>();
                DFS(node);
                if (components.Count > 0)
                {
                    Console.WriteLine($"Connected component: " +
                        $"{string.Join(" ", components)}");
                }
            }
        }

        private static void DFS(int node)
        {
            if (visited.Contains(node))
            {
                return;
            }
            visited.Add(node);
            foreach (var child in graph[node])
            {
                DFS(child);
            }
            components.Enqueue(node);
        }

        private static Dictionary<int, List<int>> ReadGraph(int n)
        {
            graph = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                var node = i;
                graph.Add(node, new List<int>());
                if (!String.IsNullOrEmpty(input))
                {
                    graph[node] = input.Split()
                        .Select(int.Parse)
                        .ToList();
                }
            }
            return graph;
        }
    }
}
