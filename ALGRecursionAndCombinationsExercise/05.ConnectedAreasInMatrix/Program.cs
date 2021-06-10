using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.ConnectedAreasInMatrix
{
    class Program
    {
        public class Area
        {
            public int Row { get; set; }
            public int Col { get; set; }
            public int Size { get; set; }

        }
        private static List<Area> areas;

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            char[,] matrix = new char[rows, cols];
            ReadMatrix(matrix, rows, cols);
            areas = new List<Area>();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row,col]=='*'|| matrix[row,col]=='v')
                    {
                        continue;
                    }

                    Area area = new Area() { Row = row, Col = col };
                    area.Size=FindAreas(matrix,row, col);
                    areas.Add(area);
                }
            }
            Console.WriteLine($"Total areas found: {areas.Count}");
            int place = 1;
            foreach (var area in areas
                .OrderByDescending(x=>x.Size)
                .ThenBy(x=>x.Row)
                .ThenBy(x=>x.Col))
            {
                Console.WriteLine($"Area #{place} at ({area.Row}" +
                    $", {area.Col}), size: {area.Size}");
                place++;
            }
        }

        private static int FindAreas(char[,] matrix, int row, int col)
        {
            if (IsInvalid(matrix, row, col))
            {
                return 0;
            }
            matrix[row, col] = 'v';
            return 1 + FindAreas(matrix, row, col + 1)
                + FindAreas(matrix, row, col - 1)
                + FindAreas(matrix, row + 1, col)
                + FindAreas(matrix, row - 1, col);
        }

        private static bool IsInvalid(char[,] matrix, int row, int col)
        {
            return row < 0 || row >= matrix.GetLength(0)
                || col < 0 || col >= matrix.GetLength(1)
                || matrix[row, col] == '*'
                || matrix[row, col] == 'v';
        }

        private static void ReadMatrix(char[,] matrix, int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = line[col];
                }
            }
        }
    }
}
