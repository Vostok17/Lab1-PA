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
        public ChessBoard ResultBoard { get; private set; }

        private Queue<TreeNode> open = new();
        private List<TreeNode> childs = new();

        private int states, iterations;

        public BFS(ChessBoard problem)
        {
            initialBoard = problem;
            ResultBoard = null;
        }

        public void Start()
        {
            TreeNode curr = new TreeNode(initialBoard);
            open.Enqueue(curr);
            do
            {
                iterations++;
                curr = open.Dequeue();
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
                        states++;
                        open.Enqueue(child);
                    }
                }
            } while (open.Count != 0);
        }

        public (int iterations, int states, int statesInMemory) GetInfo()
        {
            return (iterations, states, open.Count);
        }
    }
}