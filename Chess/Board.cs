using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public class Board
    {
        public int promotionChoice;

        public int[] squares = new int[64];
        PictureBox[] pbArray = new PictureBox[64];

        public bool whiteToMove;
        public int ColorToMove;
        public int OpponentColor;

        public int[] kingSquares = new int[2];

        public bool WhiteKCastleRights = true;
        public bool BlackKCastleRights = true;
        public bool WhiteQCastleRights = true;
        public bool BlackQCastleRights = true;

        public int plyCount = 0;
        public int epFile;

        AI adversary;

        GameWindow gW;

        LoadedPositionInfo loadedFen;

        MoveGenerator moveGenerator = new MoveGenerator();

        public Board(PictureBox[] pbA, GameWindow gW)
        {
            pbArray = pbA;
            LoadStartFen();
            moveGenerator.AddBoard(this);
            DrawBoard();
            PrecomputedData.ComputeData();
            this.gW = gW;
            int index = 0;
            foreach (int i in squares)
            {
                if (i == (Piece.King | Piece.White))
                    kingSquares[0] = index;
                else if (i == (Piece.King | Piece.Black))
                    kingSquares[1] = index;
                index++;
            }
            adversary = new AI(this);

        }
        public void LoadStartFen()
        {
            loadedFen = FenNotation.PositionFromFen(FenNotation.startFen);
            squares = loadedFen.squares;
            whiteToMove = loadedFen.whiteToMove;
            WhiteKCastleRights = loadedFen.whiteCastleKingside;
            WhiteQCastleRights = loadedFen.whiteCastleQueenside;
            BlackKCastleRights = loadedFen.blackCastleKingside;
            BlackQCastleRights = loadedFen.blackCastleQueenside;
            plyCount = loadedFen.plyCount;
            epFile = loadedFen.epFile;
            ColorToMove = Piece.White;
            OpponentColor = Piece.Black;
            plyCount = loadedFen.plyCount;
        }
        public void UpdatePbArray(PictureBox[] pbArr)
        {
            pbArray = pbArr;
        }

        public void DrawBoard()
        {
            int i = 0;
            foreach (PictureBox pb in pbArray)
            {
                string fileName = squares[i] + ".png";
                string path = Path.Combine(Environment.CurrentDirectory, @"PieceImages\", fileName);
                pb.Image = Image.FromFile(path);
                i++;
            }
        }

        public int MovementInput(int start, int target)
        {
            if (start == target)
                return 1;
            Move move = new Move(start, target, this);
            moveGenerator.GenerateMoves();
            bool contains = false;
            foreach (Move m in moveGenerator.moves)
            {
                if (move.IsIdentical(m))
                {
                    contains = true;
                    move = m;
                    break;
                }
            }
            if (contains)
            {
                move.IsCapture();
                move.IsDoubleMove();
                PlayMove(ref squares, move, true);
                whiteToMove = !whiteToMove;
                OpponentColor = OpponentColor ^ Piece.colorMask;
                ColorToMove = ColorToMove ^ Piece.colorMask;
                plyCount++;

                UpdateGW(start, target);

                if (gW.mode == 1 && ColorToMove == Piece.Black)
                    adversary.PlayMove();

                return 0;
            }
            return 1;
        }
        public void UpdateGW(int start, int target)
        {
            gW.UpdateOther(BoardRepresentation.CoordFromIndex(start), BoardRepresentation.CoordFromIndex(target));
        }
        public void PlayMove(ref int[] board, Move move, bool realMove)
        {
            switch (move.type)
            {
                case 0:
                    ExecuteMovement(move.startSquare, move.targetSquare, board, realMove);
                    break;
                case 1:
                    Capture(move.startSquare, move.targetSquare, board, realMove);
                    break;
                case 2:
                    ExecuteDoubleMovement(move.startSquare, move.targetSquare, board, realMove);
                    break;
                case 3:
                    EPCapture(move.startSquare, move.targetSquare, board, realMove);
                    break;
                case 4:
                    Castle(move.startSquare, move.targetSquare, board, realMove);
                    break;
                case 5:
                    Promote(move.startSquare, move.targetSquare, board, realMove);
                    break;
                case 6:
                    ExecuteMovement(move.startSquare, move.targetSquare, board, realMove);
                    break;
                default:
                    break;
            }
        }

        public void ExecuteMovement(int start, int target, int[] squares, bool realMove)
        {
            if (squares[start] == (Piece.King | Piece.White) && realMove)
            {
                WhiteKCastleRights = false;
                WhiteQCastleRights = false;
                kingSquares[0] = target;
            }
            else if (squares[start] == (Piece.King | Piece.Black) && realMove)
            {
                BlackKCastleRights = false;
                BlackQCastleRights = false;
                kingSquares[1] = target;
            }
            else if (start == 0 && Piece.IsType(squares[start], (Piece.Rook | Piece.White)) && realMove)
                WhiteQCastleRights = false;
            else if (start == 7 && Piece.IsType(squares[start], (Piece.Rook | Piece.White)) && realMove)
                WhiteKCastleRights = false;
            else if (start == 56 && Piece.IsType(squares[start], (Piece.Rook | Piece.Black)) && realMove)
                WhiteQCastleRights = false;
            else if (start == 63 && Piece.IsType(squares[start], (Piece.Rook | Piece.Black)) && realMove)
                WhiteKCastleRights = false;
            squares[target] = squares[start];
            squares[start] = Piece.None;
            epFile = -1;
        }
        public void ExecuteDoubleMovement(int start, int target, int[] squares, bool realMove)
        {
            squares[target] = squares[start];
            squares[start] = Piece.None;
            if (realMove)
                epFile = whiteToMove ? target - 8 : target + 8;
        }
        public void Capture(int start, int target, int[] squares, bool realMove)
        {
            if (whiteToMove && realMove)
            {
                switch (Piece.PieceType(squares[target]))
                {
                    case Piece.Pawn:
                        gW.wPawnsV++;
                        break;
                    case Piece.Knight:
                        gW.wKnightsV++;
                        break;
                    case Piece.Bishop:
                        gW.wBishopsV++;
                        break;
                    case Piece.Rook:
                        gW.wRooksV++;
                        break;
                    case Piece.Queen:
                        gW.wQueensV++;
                        break;
                }
            }
            else if (realMove)
            {
                switch (Piece.PieceType(squares[target]))
                {
                    case Piece.Pawn:
                        gW.bPawnsV++;
                        break;
                    case Piece.Knight:
                        gW.bKnightsV++;
                        break;
                    case Piece.Bishop:
                        gW.bBishopsV++;
                        break;
                    case Piece.Rook:
                        gW.bRooksV++;
                        break;
                    case Piece.Queen:
                        gW.bQueensV++;
                        break;
                }
            }
            if (squares[start] == (Piece.King | Piece.White) && realMove)
            {
                WhiteKCastleRights = false;
                WhiteQCastleRights = false;
                kingSquares[0] = target;
            }
            else if (squares[start] == (Piece.King | Piece.Black) && realMove)
            {
                BlackKCastleRights = false;
                BlackQCastleRights = false;
                kingSquares[1] = target;
            }
            else if (start == 0 && Piece.IsType(squares[start], (Piece.Rook | Piece.White)) && realMove)
                WhiteQCastleRights = false;
            else if (start == 7 && Piece.IsType(squares[start], (Piece.Rook | Piece.White)) && realMove)
                WhiteKCastleRights = false;
            else if (start == 56 && Piece.IsType(squares[start], (Piece.Rook | Piece.Black)) && realMove)
                WhiteQCastleRights = false;
            else if (start == 63 && Piece.IsType(squares[start], (Piece.Rook | Piece.Black)) && realMove)
                WhiteKCastleRights = false;

            gW.UpdateCaptures();
            if (squares[target] == (Piece.King | OpponentColor) && realMove)
            {
                if (whiteToMove)
                    gW.MatchRecap('w');
                else
                    gW.MatchRecap('b');
            }

            squares[target] = squares[start];
            squares[start] = Piece.None;
            epFile = -1;
        }
        public void EPCapture(int start, int target, int[] squares, bool realMove)
        {
            squares[target] = squares[start];
            if (whiteToMove && realMove)
            {
                gW.wPawnsV++;
                squares[target - 8] = Piece.None;
            }
            else if (!whiteToMove && realMove)
            {
                gW.bPawnsV++;
                squares[target + 8] = Piece.None;
            }
            squares[start] = Piece.None;
            epFile = -1;
        }
        public void Castle(int start, int target, int[] squares, bool realMove)
        {
            if (whiteToMove && realMove)
            {
                WhiteKCastleRights = false;
                WhiteQCastleRights = false;
            }
            else if (realMove)
            {
                BlackKCastleRights = false;
                BlackQCastleRights = false;
            }
            switch (target)
            {
                case 2:
                    squares[target] = squares[start];
                    squares[target + 1] = squares[target - 2];
                    squares[target - 2] = Piece.None;
                    squares[start] = Piece.None;
                    break;
                case 6:
                    squares[target] = squares[start];
                    squares[target - 1] = squares[target + 1];
                    squares[target + 1] = Piece.None;
                    squares[start] = Piece.None;
                    break;
                case 58:
                    squares[target] = squares[start];
                    squares[target + 1] = squares[target - 2];
                    squares[target - 2] = Piece.None;
                    squares[start] = Piece.None;
                    break;
                case 62:
                    squares[target] = squares[start];
                    squares[target - 1] = squares[target + 1];
                    squares[target + 1] = Piece.None;
                    squares[start] = Piece.None;
                    break;
            }
            if (realMove)
                epFile = -1;
        }
        public void Promote(int start, int target, int[] squares, bool realMove)
        {
            if (realMove)
            {
                if (gW.mode != 1 || whiteToMove)
                {
                    Form PI = new PromotionInterface(this);
                    PI.ShowDialog();
                    switch (promotionChoice)
                    {
                        case Piece.Queen:
                            squares[target] = Piece.Queen | ColorToMove;
                            break;
                        case Piece.Rook:
                            squares[target] = Piece.Rook | ColorToMove;
                            break;
                        case Piece.Knight:
                            squares[target] = Piece.Knight | ColorToMove;
                            break;
                        case Piece.Bishop:
                            squares[target] = Piece.Bishop | ColorToMove;
                            break;
                    }
                    squares[start] = Piece.None;
                    epFile = -1;
                }
                else
                {
                    squares[target] = Piece.Queen | ColorToMove;
                    squares[start] = Piece.None;
                    epFile = -1;
                }
            }
        }
    }
}
