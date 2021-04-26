using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AreasInMatrix
{
    public class Node
    {
        public int Row { get; set; }
        public int Col { get; set; }

    }
    class Program
    {
        private static char[,] matrix;
        private static Dictionary<char, int> areas;
        private static bool[,] visited;
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            matrix = ReadMatrix(rows, cols);
            visited = new bool[rows, cols];
            areas = DefineAreasKeys();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (visited[row, col])
                    {
                        continue;
                    }
                    DFS(row, col);
                    var node = matrix[row, col];
                    areas[node]++;
                }
            }
            Console.WriteLine($"Areas: {areas.Sum(x=>x.Value)}");
            foreach (var area in areas
                .OrderBy(x=>x.Key))
            {
                Console.WriteLine($"Letter '{area.Key}' -> {area.Value}");
            }
        }

        private static void DFS(int row, int col)
        {
            var parent = new Node() { Row = row, Col = col };

            visited[row, col] = true;
            var children = FindChildren(parent);
            foreach (var child in children)
            {
                DFS(child.Row, child.Col);
            }
        }

        private static List<Node> FindChildren(Node parent)
        {
            var children = new List<Node>();
            int row = parent.Row;
            int col = parent.Col;
            if (IsChild(row + 1, col, parent))
            {
                var child = new Node() { Row = row + 1, Col = col };
                children.Add(child);
            }
            if (IsChild(row - 1, col, parent))
            {
                var child = new Node() { Row = row - 1, Col = col };
                children.Add(child);
            }
            if (IsChild(row, col + 1, parent))
            {
                var child = new Node() { Row = row, Col = col + 1 };
                children.Add(child);
            }
            if (IsChild(row, col - 1, parent))
            {
                var child = new Node() { Row = row, Col = col - 1 };
                children.Add(child);
            }
            return children;
        }

        private static bool IsChild(int row, int col, Node parent)
        {
            if (row < 0 || row >= matrix.GetLength(0))
            {
                return false;
            }
            if (col < 0 || col >= matrix.GetLength(1))
            {
                return false;
            }
            if (matrix[row, col] != matrix[parent.Row, parent.Col])
            {
                return false;
            }
            if (visited[row, col])
            {
                return false;
            }
            return true;
        }

        private static Dictionary<char, int> DefineAreasKeys()
        {
            Dictionary<char, int> areas = new Dictionary<char, int>();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    char node = matrix[row, col];
                    if (!areas.ContainsKey(node))
                    {
                        areas[node] = 0;
                    }
                }
            }
            return areas;
        }

        private static char[,] ReadMatrix(int rows, int cols)
        {
            char[,] matrix = new char[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = line[col];
                }
            }
            return matrix;
        }
    }
}
