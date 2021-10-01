using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8QueensProblem
{
    internal class TreeNode
    {
        internal ChessBoard State { get; private set; }
        private int queen;
        public TreeNode(ChessBoard board, int queen = 0)
        {
            State = board;  
            this.queen = queen;
        }
        public List<TreeNode> Expand()
        {
            List<TreeNode> childs = new();
            if (queen == 8) return childs;

            for (int i = 0; i < State.Size; i++)
            {
                State.Board[queen] = i;

                ChessBoard temp = new();
                ChessBoard.Copy(State, temp);
                childs.Add(new TreeNode(temp, queen + 1));
            }
            queen++;
            return childs;  
        }

    }
}
