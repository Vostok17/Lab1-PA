using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                readOption = value;
            }
        }

        string algorytm;
        string Algorytm
        {
            get { return algorytm; }
            set
            {
                while (value != "0" && value != "1")
                {
                    Console.Write("\nOnly 0 or 1 is acceptable!\nChoice: ");
                    //throw new ArgumentException("Only 0 or 1 is acceptable");
                }
                algorytm = value;
            }
        }

        private ChessBoard problem, result;

        public Stopwatch time = new();
        private BFS bfs;
        private A_Star a_star;

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
            time.Start();
            if (algorytm == "0")
            {
                bfs = new BFS(problem);
                bfs.Start();
                result = bfs.ResultBoard;

            }
            else
            {
                a_star = new A_Star(problem);
                a_star.Start();
                result = a_star.ResultBoard;
            }
            time.Stop();
        }

        public void InitializeBoard()
        {
            problem = new();

            if (readOption == "0") problem.RandBoard();
            else problem.ReadBoard();

            Console.WriteLine("\nInitial board:");
            problem.PrintBoard();

            Console.Write("\n\n");
        }

        public void ShowResult()
        {
            Console.WriteLine("Result board:");
            result.PrintBoard();

            if (algorytm == "0")
            {
                var data = bfs.GetInfo();
                PrintStatistics(data.iterations, data.states, data.statesInMemory);
            }
            else
            {
                var data = a_star.GetInfo();
                PrintStatistics(data.iterations, data.states, data.statesInMemory);
            }
        }
        public void PrintStatistics(int iterations, int states, int statesInMemory)
        {
            Console.WriteLine("\nIterations: {0}", iterations);
            Console.WriteLine("States: {0}", states);
            Console.WriteLine("States in memory: {0}", statesInMemory);
            Console.WriteLine("Time: {0:0.000}", time.Elapsed.TotalSeconds);
        }
    }
}
