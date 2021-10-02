using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8QueensProblem
{
    internal class UserInterface
    {
        string readOption;
        string ReadOption 
        {
            get { return readOption; }
            set
            {
                while (value != "0" && value != "1")
                {
                    Console.Write("\nOnly 0 or 1 is acceptable!\nChoice: ");
                    value = Console.ReadLine();
                    //throw new ArgumentException("Only 0 or 1 is acceptable");
                }
            }
        }

        string algorytm;
        string Algorytm
        {
            get { return algorytm; }
            set
            {
                if (value != "0" && value != "1")
                {
                    Console.Write("\nOnly 0 or 1 is acceptable!\nChoice: ");
                    //throw new ArgumentException("Only 0 or 1 is acceptable");
                }
            }
        }

        ChessBoard problem, result;
        public void GetInfo()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("[0] - Generate random chessboard");
            Console.WriteLine("[1] - Read from file");
            Console.Write("Choice: ");
            ReadOption = Console.ReadLine();

            Console.WriteLine("\nChoose an algorytm:");
            Console.WriteLine("[0] - BFS");
            Console.WriteLine("[1] - A*");
            Console.Write("Choice: ");
            Algorytm = Console.ReadLine();
        }

        public void Start()
        {
            if (Algorytm == "0")
            {
                BFS bfs = new BFS(problem);
                bfs.Start();
                result = bfs.ResultBoard;
            }
            else
            {
                A_Star a_star = new A_Star(problem);
                a_star.Start();
                result = a_star.ResultBoard;
            }
        }

        public void InitializeBoard()
        {
            problem = new();

            if (ReadOption == "0") problem.RandBoard();
            else problem.ReadBoard();

            Console.WriteLine("\nInitial board:");
            problem.PrintBoard();

            Console.Write("\n\n");
        }

        public void ShowResult()
        {
            Console.WriteLine("Result board:");
            result.PrintBoard();
        }
    }
}
