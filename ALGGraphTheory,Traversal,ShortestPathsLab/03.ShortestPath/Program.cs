using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ShortestPath
{
    class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;
        private static int[] parents;
        private static Stack<int> path;

        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());
            graph = ReadGraph(nodes, edges);
            visited = new bool[graph.Length];
            parents = new int[graph.Length];
            Array.Fill(parents, -1);

            var source = int.Parse(Console.ReadLine());
            var destination = int.Parse(Console.ReadLine());
            BFS(source, destination);
            Console.WriteLine($"Shortest path length is: {path.Count-1}");
            Console.WriteLine(string.Join(" ", path));
        }

        private static void BFS(int source, int destination)
        {
            if (visited[source])
            {
                return;
            }
            var queue = new Queue<int>();
            queue.Enqueue(source);
            visited[source] = true;
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (node == destination)
                {
                    path = ReconstructPath(destination);
                }
                foreach (var child in graph[node])
                {
                    if (!visited[child])
                    {
                        parents[child] = node;
                        queue.Enqueue(child);
                        visited[child] = true;
                    }
                }
            }
        }

        private static Stack<int> ReconstructPath(int destination)
        {
            path = new Stack<int>();
            var index = destination;
            while (index != -1)
            {
                path.Push(index);
                index = parents[index];
            }
            return path;
        }

        private static List<int>[] ReadGraph(int nodes, int edges)
        {
            var graph = new List<int>[nodes+1];
            for (int i = 1; i < graph.Length; i++)
            {
                var node = i;
                graph[node] = new List<int>();
            }
            for (int i = 1; i <= edges; i++)
            {
                int[] input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                var node = input[0];
                graph[node].Add(input[1]);
            }
            
            return graph;
        }
    }
}
