using System;
using System.Collections.Generic;

namespace _08.EightQueens
{
    class Program
    {
        private static HashSet< int> queenRow = new HashSet<int>();
        private static HashSet<int> queenCol = new HashSet<int>();
        private static HashSet<int> leftDiagonal=new HashSet<int>();
        private static HashSet<int> rightDiagonal = new HashSet<int>();


        static void Main(string[] args)
        {
            char[,] board = new char[8, 8];
            for (int row = 0; row <= 7; row++)
            {
                for (int col = 0; col <= 7; col++)
                {
                    board[row, col] = '-';
                }
            }
            FindQueen(board, 0);
        }

        private static void FindQueen(char[,] board, int row)
        {
            if (row == 8)
            {
                PrintBoard(board);
                return;
            }
            for (int col = 0; col < board.GetLength(1); col++)
            {
                if (IsInvalid(board, row, col))
                {
                    continue;
                }

                board[row, col] = '*';
                leftDiagonal.Add(col-row);
                rightDiagonal.Add(row + col);
                queenRow.Add(row);
                queenCol .Add(col);

                FindQueen(board, row + 1);

                board[row, col] = '-';
                leftDiagonal.Remove(col - row);
                rightDiagonal.Remove(row + col);
                queenRow.Remove(row);
                queenCol.Remove(col);
            }
        }

        private static void PrintBoard(char[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    Console.Write(board[row, col] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static bool IsInvalid(char[,] board, int row, int col)
        {
            if (row < 0 && row >= board.GetLength(0)
               || col < 0 && col >= board.GetLength(1))
            {
                return true;
            }
            if (board[row, col] == '*')
            {
                return true;
            }
            if (leftDiagonal.Contains( col-row))
            {
                return true;
            }
            if (rightDiagonal.Contains(col + row))
            {
                return true;
            }
            if (queenRow.Contains(row)||queenCol.Contains(col))
            {
                return true;
            }
            return false;
        }
    }
}
