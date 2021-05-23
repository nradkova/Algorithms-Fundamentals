using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.PathsInLabyrinth
{
    class Program
    {
        public static Queue<char> path = new Queue<char>();

        static void Main(string[] args)
        {
            int rows =int.Parse(Console.ReadLine());
            int cols =int.Parse(Console.ReadLine());

            var labyrinth = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var colElements = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    labyrinth[row, col] = colElements[col];
                }
            }
            
            FindPath(labyrinth, 0, 0,'\0');
        }

        private static void FindPath
            (char[,] labyrinth, int row, int col,char direction)
        {
            if (IsInvalid(labyrinth,row,col))
            {
                return;
            }
            labyrinth[row, col] = 'v';
            path.Enqueue(direction);

            if (labyrinth[row,col]=='e')
            {
                Console.WriteLine(string.Join("",path));
                return;
            }
            FindPath(labyrinth, row, col + 1, 'R');
            FindPath(labyrinth, row, col -1, 'L');
            FindPath(labyrinth, row-1, col, 'D');
            FindPath(labyrinth, row+1, col, 'U');

            labyrinth[row, col] = '-';
            path.Dequeue();
        }

        private static bool IsInvalid(char[,] labyrinth, int row, int col)
        {
            if (row<0||row>=labyrinth.GetLength(0)
                ||col<0||col>=labyrinth.GetLength(1)
                ||labyrinth[row,col]=='*'
                || labyrinth[row, col] == 'v')
            {
                return true;
            }
            return false;
        }
    }
}
