using System;
using System.Collections.Generic;

namespace _8QueensProblem
{
    class Program
    {
        static void Main(string[] args)
        {

            ChessBoard problem = new();
            problem.ReadBoard();

            //A_Star a_star = new A_Star(problem);
            //a_star.Start();

            BFS bfs = new BFS(problem);
            bfs.Start();

            Console.WriteLine("Result: ");
            //a_star.ResultBoard.PrintBoard();
            bfs.ResultBoard.PrintBoard();

            Console.ReadKey();
        }
    }
}
