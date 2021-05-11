using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.TopologicalSorting
{
    class Program
    {
        static void Main(string[] args)
        {
            int n =int.Parse(Console.ReadLine());
           var graph = ReadGraph(n);
            var dependencies = FindDependencies(graph);
            var sorted = TopologicalSorting(graph, dependencies);
            if (sorted==null)
            {
                Console.WriteLine("Invalid topological sorting");
            }
            else
            {
                Console.WriteLine($"Topological sorting: " +
                    $"{string.Join(", ",sorted)}");
            }
        }

        private static List<string> TopologicalSorting
            (Dictionary<string, List<string>> graph,
            Dictionary<string, int> dependencies)
        {
            var sorted = new List<string>();
            while (dependencies.Count>0)
            {
                var nodeToRemove = dependencies
                    .FirstOrDefault(x => x.Value == 0);
                if (nodeToRemove.Key==null)
                {
                    break;
                }
                var node = nodeToRemove.Key;
                var children = graph[node];
                sorted.Add(node);
                foreach (var child in children)
                {
                    dependencies[child]--;
                }
                dependencies.Remove(nodeToRemove.Key);
            }
            if (dependencies.Count>0)
            {
                return null;
            }
            return sorted;
        }

        private static Dictionary<string,int> FindDependencies
            (Dictionary<string, List<string>> graph)
        {
            var dependencies = new Dictionary<string, int>();
            foreach (var node in graph)
            {
                if(!dependencies.ContainsKey(node.Key))
                {
                    dependencies.Add(node.Key, 0);
                }
                foreach (var child in node.Value)
                {
                    if (!dependencies.ContainsKey(child))
                    {
                        dependencies.Add(child, 1);
                    }
                    else
                    {
                        dependencies[child]++;
                    }
                }
            }
            return dependencies;
        }

        private static Dictionary<string, List<string>> ReadGraph(int n)
        {
            var graph = new Dictionary<string, List<string>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ->");
                string node = input[0];
                graph.Add(node, new List<string>());
                if (input.Length > 1)
                {
                    graph[node] = input[1]
                        .Split(new char[] { ' ', ','},StringSplitOptions.RemoveEmptyEntries)
                        .ToList();
                }
            }
            return graph;
        }
    }
}
