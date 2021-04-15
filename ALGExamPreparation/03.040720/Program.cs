using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._040720
{
    class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static Dictionary<string, int> dependencies;
        static void Main(string[] args)
        {
            graph = new Dictionary<string, List<string>>();
            dependencies = new Dictionary<string, int>();
            graph = ReadGraph();
            dependencies = DefineDependencies();
           dependencies= dependencies.Reverse().ToDictionary(x=>x.Key,x=>x.Value);
            var sorted = SearchGraph();
            if (sorted != null)
            {
            Console.WriteLine(string.Join(" ", sorted));
            }
        }

        private static List<string> SearchGraph()
        {
            var sorted = new List<string>();
            while (dependencies.Count > 0)
            {
                var nodeToRemove = dependencies
                    .FirstOrDefault(x => x.Value == 0).Key;
                if (nodeToRemove == null)
                {
                    break;
                }
                sorted.Add(nodeToRemove);
                foreach (var child in graph[nodeToRemove])
                {
                    dependencies[child]-=1;
                }
                dependencies.Remove(nodeToRemove);
            }
            if (dependencies.Count > 0)
            {
                return null;
            }
            return sorted;
        }
        private static Dictionary<string, int> DefineDependencies()
        {
            foreach (var node in graph)
            {
                if (!dependencies.ContainsKey(node.Key))
                {
                    dependencies.Add(node.Key, 0);
                }
                foreach (var child in node.Value)
                {
                    if (!dependencies.ContainsKey(child))
                    {
                        dependencies.Add(child, 0);
                    }
                    dependencies[child]++;
                }
            }
            return dependencies;
        }


        private static Dictionary<string, List<string>> ReadGraph()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                var tokens = input.Split(" ->");
                var node = tokens[0];
                if (!graph.ContainsKey(node))
                {
                    graph.Add(node, new List<string>());
                }
                if (tokens.Length > 1)
                {
                    var children = tokens[1]
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                    graph[node].AddRange(children);
                }
            }
            return graph;
        }
    }
}
