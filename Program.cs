using System;
using System.Collections.Generic;

namespace _8QueensProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInterface ui = new();

            ui.GetInfo();

            ui.InitializeBoard();

            ui.Start();

            ui.ShowResult();

            Console.ReadKey();
        }
    }
}
