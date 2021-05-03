using System;
using System.Collections.Generic;

namespace _06.RoadReconstruction
{
    public class Edge
    {
        public Edge(int start, int end)
        {
            Start = start;
            End = end;
        }
        public int Start { get; set; }
        public int End { get; set; }

    }
    class Program
    {
        private static List<int>[] graph;
        private static List<Edge> edges;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            graph = new List<int>[n];
            edges = new List<Edge>();
            List<Edge> importantEdges = new List<Edge>();
            ProcessInputData(n, p);
            foreach (var edge in edges)
            {
                var source = edge.Start;
                var destination = edge.End;
                graph[source].Remove(destination);
                graph[destination].Remove(source);
                if (HasPath(source, destination) == false)
                {
                    importantEdges.Add(edge);
                }
                graph[source].Add(destination);
                graph[destination].Add(source);
            }
            Console.WriteLine("Important streets:");
            foreach (var edge in importantEdges)
            {
                if (edge.Start <= edge.End)
                {
                    Console.WriteLine($"{edge.Start} {edge.End}");
                }
                else
                {
                    Console.WriteLine($"{edge.End} {edge.Start}");
                }
            }
        }

        private static bool HasPath(int source, int destination)
        {
            var queue = new Queue<int>();
            var visited = new HashSet<int>();
            queue.Enqueue(source);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (node == destination)
                {
                    return true;
                }
                visited.Add(node);
                foreach (var child in graph[node])
                {
                    if (visited.Contains(child))
                    {
                        continue;
                    }
                    visited.Add(child);
                    queue.Enqueue(child);
                }
            }
            return false;
        }

        private static void ProcessInputData(int n, int p)
        {
            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }
            for (int i = 0; i < p; i++)
            {
                string[] input = Console.ReadLine().Split(" - ");
                var node = int.Parse(input[0]);
                var child = int.Parse(input[1]);
                graph[node].Add(child);
                graph[child].Add(node);
                edges.Add(new Edge(node, child));
            }
        }
    }
}
