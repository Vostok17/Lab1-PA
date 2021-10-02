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
        private List<TreeNode> closed = new();
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
            states++;
            do
            {
                iterations++;
                curr = open.Dequeue();
                closed.Add(curr);
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
                        if (!IsVisited(child))
                        {
                            open.Enqueue(child);
                        }
                    }
                }
            } while (open.Count != 0);
        }

        private bool IsVisited(TreeNode child)
        {
            foreach (var node in closed)
            {
                if (ChessBoard.IsEqual(child.State, node.State))
                {
                    return true;
                }
            }
            return false;
        }

        public (int iterations, int states, int statesInMemory) GetInfo()
        {
            return (iterations, states, open.Count + closed.Count);
        }
    }
}