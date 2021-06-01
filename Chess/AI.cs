using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public class AI
    {
        public MoveGenerator moveGenerator = new MoveGenerator();
        Random rnd = new Random();
        List<Move> moves;
        Move chosenMove;
        public int value;
        public Board board;

        public AI(Board b)
        {
            board = b;
        }

        public void PlayMove()
        {
            value = 0;
            moves = moveGenerator.GenerateAIMoves();
            foreach(Move m in moves)
            {
                int tempValue = -1;
                m.IsCapture();
                tempValue = getValue(board.squares[m.targetSquare], m.type);
                if (tempValue > value)
                {
                    chosenMove = m;
                    value = tempValue;
                }
            }
            if (value != 0)
                board.PlayMove(ref board.squares, chosenMove, true);
            else
            {
                int random = rnd.Next(0, moves.Count);
                chosenMove = moves[random];
                board.PlayMove(ref board.squares, chosenMove, true);
            }
            board.whiteToMove = !board.whiteToMove;
            board.OpponentColor = board.OpponentColor ^ Piece.colorMask;
            board.ColorToMove = board.ColorToMove ^ Piece.colorMask;
            board.plyCount++;

            board.UpdateGW(chosenMove.startSquare, chosenMove.targetSquare);
        }

        public int getValue(int piece, int type) // 0 = Move; 1 = Capture; 2 = Doublemove; 3 = EP-Capture; 4 = Castle; 5 = Promotion
        {
            piece = piece & Piece.typeMask;
            int res = 0;
            if (type == 1)
            {
                switch (piece)
                {
                    case Piece.Queen:
                        res = 15;
                        break;
                    case Piece.King:
                        res = 16;
                        break;
                    case Piece.Rook:
                        res = 14;
                        break;
                    case Piece.Bishop:
                        res = 13;
                        break;
                    case Piece.Knight:
                        res = 12;
                        break;
                    case Piece.Pawn:
                        res = 10;
                        break;
                }
            }
            else if (type == 5)
                res = 11;
            else if (type == 4)
                res = 9;
            return res;
        }
    }
}
