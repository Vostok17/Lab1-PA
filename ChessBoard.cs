using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8QueensProblem
{
    internal class ChessBoard
    {
        /*
        
          a b c d e f g h 
        0 - - - - - - - - 
        1 - - - - - - - -
        2 - - - - - - - -
        3 - - # - - - - -
        4 - - - - - - - -
        5 - - - - # - - -
        6 - - - - - - - -
        7 - - - - - - - -

        index = letter
        value = number
        */

        // board[2] = 3
        // c3

        // board[4] = 5
        // e5

        //public int[] Board { get; private set; }
        public int[] Board { get; set; }
        public int Size { get; }

        /// <summary>
        /// board[0] = 3 represents A3;
        /// board[2] = 0 represents C0
        /// </summary>
        /// <param name="size"></param>
        public ChessBoard(int size = 8)
        {
            Size = size;
            Board = new int[size];
        }

        public void RandBoard()
        {
            Random random = new Random();
            for (int i = 0; i < Size; i++)
            {
                Board[i] = random.Next(Size);
            }
        }

        public void PrintBoard()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (Board[j] == i) Console.Write("#");
                    else Console.Write("-");
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        public void WriteBoard(string path = @"C:\Users\Artem\source\repos\8QueensProblem\write.txt")
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < Size; i++)
                {
                    for (int j = 0; j < Size; j++)
                    {
                        if (Board[j] == i) sw.Write("#");
                        else sw.Write("-");
                        sw.Write(" ");
                    }
                    sw.WriteLine();
                }
            }
        }

        public void ReadBoard(string path = @"C:\Users\Artem\source\repos\8QueensProblem\read.txt")
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                int boardPtr = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    line = line.Trim();
                    String[] arr = line.Split(' ');

                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (arr[i] == "#")
                        {
                            Board[i] = boardPtr;
                        }
                    }
                    boardPtr++;
                }
            }
        }

        public bool IsSolved()
        {
            for (int i = 0; i < Size - 1; i++)
            {
                for (int j = i + 1; j < Size; j++)
                {
                    if (Board[j] == Board[i] || Math.Abs(Board[j] - Board[i]) == Math.Abs(j - i)) // horizontal and diagonals
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static void Copy(ChessBoard from,ChessBoard to)
        {
            for (int i = 0; i < from.Size; i++)
            {
                to.Board[i] = from.Board[i];
            }
        }

        public static bool IsEqual(ChessBoard a, ChessBoard b)
        {
            for (int i = 0; i < a.Size; i++)
            {
                if (a.Board[i] != b.Board[i]) 
                    return false;
            }
            return true;
        }
    }
}
