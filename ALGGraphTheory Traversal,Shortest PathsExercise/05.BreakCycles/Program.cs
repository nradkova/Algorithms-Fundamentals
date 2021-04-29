using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BreakCycles
{
    public class Edge
    {
        public Edge(string start, string end)
        {
            Start = start;
            End = end;
        }
        public string Start { get; set; }
        public string End { get; set; }
    }

    class Program
    {
        private static Dictionary<string, List<string>> graph;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            graph = ReadGraph(n);
            List<Edge> edges = GetEdges();
            List<Edge> removedEdges = new List<Edge>();
            foreach (var edge in edges)
            {
                var source = edge.Start;
                var destination = edge.End;
                graph[source].Remove(destination);
                graph[destination].Remove(source);

                if (HasPath(source, destination))
                {
                    removedEdges.Add(edge);
                }
            }
            Console.WriteLine($"Edges to remove: {removedEdges.Count}");
            foreach (var removed in removedEdges)
            {
                Console.WriteLine($"{removed.Start} - {removed.End}");
            }
        }

        private static bool HasPath(string source, string destination)
        {
            var queue = new Queue<string>();
            var visited = new HashSet<string>();
            queue.Enqueue(source);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                visited.Add(node);
                if (node == destination)
                {
                    return true;
                }
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

        private static List<Edge> GetEdges()
        {
            var result = new List<Edge>();
            foreach (var node in graph)
            {
                foreach (var child in node.Value)
                {
                    result.Add(new Edge(node.Key, child));
                }
            }
            result = result.OrderBy(x => x.Start).ThenBy(x => x.End).ToList();
            return result;
        }

        private static Dictionary<string, List<string>> ReadGraph(int n)
        {
            var result = new Dictionary<string, List<string>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ");
                var node = input[0];
                var children = input[1].Split().ToList();
                if (!result.ContainsKey(node))
                {
                    result.Add(node, new List<string>());
                }
                foreach (var child in children)
                {
                    result[node].Add(child);
                }
            }
            return result;
        }
    }
}
