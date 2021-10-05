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
                while (value != "0" && value != "1" && value != "2")
                {
                    Console.Write("\nOnly 0 or 1 is acceptable!\nChoice: ");
                }
                algorytm = value;
            }
        }

        private ChessBoard problem, resultBFS, resultA_Star;

        public Stopwatch timeBFS = new(), timeA_Star = new();
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
            Console.WriteLine("[2] - both");
            Console.Write("Choice: ");
            Algorytm = Console.ReadLine();
        }

        public void Start()
        {
            if (algorytm == "0")
            {
                timeBFS.Start();
                bfs = new BFS(problem);
                bfs.Start();
                resultBFS = bfs.ResultBoard;
                timeBFS.Stop();

            }
            else if (algorytm == "1")
            { 
                timeA_Star.Start();
                a_star = new A_Star(problem);
                a_star.Start();
                resultA_Star = a_star.ResultBoard;
                timeA_Star.Stop();
            }
            else
            {
                timeBFS.Start();
                bfs = new BFS(problem);
                bfs.Start();
                resultBFS = bfs.ResultBoard;
                timeBFS.Stop();

                timeA_Star.Start();
                a_star = new A_Star(problem);
                a_star.Start();
                resultA_Star = a_star.ResultBoard;
                timeA_Star.Stop();
            }
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
            if (algorytm == "0")
            {
                Console.WriteLine("Result board:");
                var data = bfs.GetInfo();
                resultBFS.PrintBoard();
                PrintStatistics(data.iterations, data.states, data.statesInMemory);
                Console.WriteLine("Time: {0:0} ms", timeBFS.Elapsed.TotalMilliseconds);
            }
            else if (algorytm == "1")
            {
                Console.WriteLine("Result board:");
                var data = a_star.GetInfo();
                resultA_Star.PrintBoard();
                PrintStatistics(data.iterations, data.states, data.statesInMemory);
                Console.WriteLine("Time: {0:0} ms", timeA_Star.Elapsed.TotalMilliseconds);
            }
            else
            {
                Console.WriteLine("Result for A*: ");
                resultA_Star.PrintBoard();
                var data1 = a_star.GetInfo();
                PrintStatistics(data1.iterations, data1.states, data1.statesInMemory);
                Console.WriteLine("Time: {0:0} ms", timeA_Star.Elapsed.TotalMilliseconds);

                Console.WriteLine("\nResult for BFS: ");
                resultBFS.PrintBoard();
                var data2 = bfs.GetInfo();
                PrintStatistics(data2.iterations, data2.states, data2.statesInMemory);
                Console.WriteLine("Time: {0:0} ms", timeBFS.Elapsed.TotalMilliseconds);
            }
        }
        public void PrintStatistics(int iterations, int states, int statesInMemory)
        {
            Console.WriteLine("\nIterations: {0}", iterations);
            Console.WriteLine("States: {0}", states);
            Console.WriteLine("States in memory: {0}", statesInMemory);           
        }
    }
}
