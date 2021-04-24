using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.DistanceBetweenVertices
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());

            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            ReadGraph(n, graph);
            List<string> pairs = new List<string>();
            ReadPairs(p, pairs);

            foreach (var pair in pairs)
            {
                string[] tokens = pair.Split("-");
                var startNode = int.Parse(tokens[0]);
                var destination = int.Parse(tokens[1]);
                int stepsCount = FindSteps(startNode, destination, graph);
                Console.WriteLine($"{{{startNode}, {destination}}} -> {stepsCount}");
            }
        }

        private static int FindSteps(int startNode, int destination,
            Dictionary<int, List<int>> graph)
        {
            var parents = new Dictionary<int, int>();
            parents.Add(startNode, 0);
            var queue = new Queue<int>();
            queue.Enqueue(startNode);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (parents.Any(x => x.Key == destination))
                {
                    int endNode = parents.FirstOrDefault(x => x.Key == destination).Key;
                    return StepBack(endNode, parents);
                }

                foreach (var child in graph[node])
                {
                    if (!parents.ContainsKey(child))
                    {
                        queue.Enqueue(child);
                        parents.Add(child, node);
                    }
                }
            }
            return -1;
        }

        private static int StepBack(int endNode, Dictionary<int, int> parents)
        {
            int steps = 0;
            var parentNode = parents[endNode];
            while (parentNode != 0)
            {
                steps++;
                parentNode = parents[parentNode];
            }
            return steps;
        }

        private static void ReadPairs(int p, List<string> pairs)
        {
            for (int i = 0; i < p; i++)
            {
                pairs.Add(Console.ReadLine());
            }
        }

        private static void ReadGraph(int n,
            Dictionary<int, List<int>> graph)
        {
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(":");
                int node = int.Parse(input[0]);
                if (!graph.ContainsKey(node))
                {
                    graph.Add(node, new List<int>());
                }
                if (!String.IsNullOrEmpty(input[1]))
                {
                    graph[node] = input[1]
                        .Split()
                        .Select(int.Parse)
                        .ToList();
                }
            }
        }
    }
}
