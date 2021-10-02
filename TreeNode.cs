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
        public TreeNode(ChessBoard board, int queen = 0)
        {
            State = board;  
        }
        public List<TreeNode> Expand()
        {

            List<TreeNode> children = new();
            for (int column = 0; column < State.Size; column++) // для каждого ферзя
            {
                for (int row = 0; row < State.Size; row++) // проходим по колонке
                {
                    if (State.Board[column] == row) // нашли ферзя в колонке
                    {
                        for (int i = 0; i < State.Size; i++) // делаем детей перемещая ферзь в колонке
                        {
                            if (i != row) // не создаем ребенка для изначальной позиции
                            {
                                ChessBoard boardForChild = new();
                                ChessBoard.Copy(State, boardForChild);
                                boardForChild.Board[column] = i;
                                children.Add(new TreeNode(boardForChild));
                            }
                        }
                    }
                }
            }
            return children;
        }

    }
}
