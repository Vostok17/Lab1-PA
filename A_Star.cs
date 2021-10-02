using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8QueensProblem
{
    internal class A_Star
    {
        private ChessBoard initialBoard;
        public ChessBoard ResultBoard { get; private set; }

        private PriorityQueue<TreeNode, int> open = new();
        private List<TreeNode> closed = new();

        private int iterations, states;
        public A_Star(ChessBoard problem)
        {
            initialBoard = problem;
            ResultBoard = null;
        }

        public void Start()
        {
            TreeNode curr = new TreeNode(initialBoard);
            open.Enqueue(curr, F2(curr.State));
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
                List<TreeNode> childs = curr.Expand();
                foreach (TreeNode child in childs)
                {
                    states++;
                    if (!IsVisited(child))
                    {
                        open.Enqueue(child, F2(child.State));
                    }
                }
            } while (open.Count != 0);
        }


        private int F2(ChessBoard board)
        {
            int conflicts = 0;

            for (int i = 0; i < board.Size - 1; i++)
            {
                for (int j = i + 1; j < board.Size; j++)
                {
                    if (board.Board[j] == board.Board[i] || Math.Abs(board.Board[j] - board.Board[i]) == Math.Abs(j - i)) // horizontal and diagonals
                    {
                        conflicts++;
                    }
                }
            }
            return conflicts;
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
