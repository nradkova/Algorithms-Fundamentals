using System;
using System.Collections.Generic;
using System.Linq;

namespace _03
{
    public class Edge
    {
        public int Start { get; set; }
        public int End { get; set; }
    }
    class Program
    {
        private static Dictionary<int, List<int>> graph;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            graph = new Dictionary<int, List<int>>();
            ReadGraph(n);
            int p = int.Parse(Console.ReadLine());
            Dictionary<int, List<Edge>> paths = new Dictionary<int, List<Edge>>();
            for (int i = 0; i < p; i++)
            {
                paths.Add(i, new List<Edge>());
                int[] input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < input.Length - 1; j++)
                {
                    paths[i].Add(new Edge{ Start = input[j], End = input[j + 1] });
                }
            }
            foreach (var path in paths)
            {
                bool hasPath = true;
                foreach (var edge in path.Value)
                {
                    int start = edge.Start;
                    int end = edge.End;

                    if (!BFS(start, end))
                    {
                        hasPath = false;
                        break;
                    }
                }

                if (hasPath)
                {
                    Console.WriteLine("yes");
                }
                else
                {
                    Console.WriteLine("no");
                }
            }
        }

        private static bool BFS(int start, int end)
        {
            var queue = new Queue<int>();
            var visited = new HashSet<int>();
            if (start==end)
            {
                return false;
            }
            queue.Enqueue(start);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (node == end)
                {
                    return true;
                }
                visited.Add(node);
                foreach (var child in graph[node])
                {
                    if (!visited.Contains(child))
                    {
                        queue.Enqueue(child);
                        visited.Add(child);
                    }
                }
            }

            return false;
        }

        private static void ReadGraph( int n)
        {
            for (int i = 0; i < n; i++)
            {
                graph.Add(i, new List<int>());
                string input = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(input))
                {
                    continue;
                }
                var children = input
                    .Split()
                    .Select(int.Parse)
                    .ToList();
                graph[i].AddRange(children);
            }
        }
    }
}
