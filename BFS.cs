using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8QueensProblem
{
    internal class BFS
    {
        private ChessBoard initialBoard;
        public ChessBoard ResultBoard {  get; private set; }

        public BFS(ChessBoard problem)
        {
            initialBoard = problem;
            ResultBoard = null;
        }

        public void Start()
        {
            TreeNode curr = new TreeNode(initialBoard);
            Queue<TreeNode> nodes = new();
            nodes.Enqueue(curr);
            List<TreeNode> childs = new();
            do
            {
                curr = nodes.Dequeue();
                if (curr.State.IsSolved())
                {
                    ResultBoard = curr.State;
                    return;
                }
                else
                {
                    childs = curr.Expand();
                    foreach (TreeNode child in childs)
                    {
                        nodes.Enqueue(child);                       
                    }
                }
            } while (nodes.Count != 0);
        }
    }
}


/*curr.State.PrintBoard();
                Console.WriteLine();
                Console.WriteLine();*/