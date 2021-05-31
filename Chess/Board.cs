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

        public bool WhiteKCastleRights = true;
        public bool BlackKCastleRights = true;
        public bool WhiteQCastleRights = true;
        public bool BlackQCastleRights = true;

        public int plyCount = 0;
        public int epFile;

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
                switch (move.type)
                {
                    case 0:
                        ExecuteMovement(start, target);
                        break;
                    case 1:
                        Capture(start, target);
                        break;
                    case 2:
                        ExecuteDoubleMovement(start, target);
                        break;
                    case 3:
                        EPCapture(start, target);
                        break;
                    case 4:
                        Castle(start, target);
                        break;
                    case 5:
                        Promote(start, target);
                        break;
                    default:
                        break;
                }
                whiteToMove = !whiteToMove;
                OpponentColor = OpponentColor ^ Piece.colorMask;
                ColorToMove = ColorToMove ^ Piece.colorMask;
                plyCount++;

                gW.UpdateOther(BoardRepresentation.CoordFromIndex(start), BoardRepresentation.CoordFromIndex(target));

                return 0;
            }
            return 1;
        }

        public void ExecuteMovement(int start, int target)
        {
            if(squares[start] == (Piece.King | Piece.White))
            {
                WhiteKCastleRights = false;
                WhiteQCastleRights = false;
            }
            else if (squares[start] == (Piece.King | Piece.Black))
            {
                BlackKCastleRights = false;
                BlackQCastleRights = false;
            }
            else if (start == 0 && Piece.IsType(squares[start], (Piece.Rook | Piece.White)))
                WhiteQCastleRights = false;
            else if (start == 7 && Piece.IsType(squares[start], (Piece.Rook | Piece.White)))
                WhiteKCastleRights = false;
            else if (start == 56 && Piece.IsType(squares[start], (Piece.Rook | Piece.Black)))
                WhiteQCastleRights = false;
            else if (start == 63 && Piece.IsType(squares[start], (Piece.Rook | Piece.Black)))
                WhiteKCastleRights = false;
            squares[target] = squares[start];
            squares[start] = Piece.None;
            epFile = -1;
        }
        public void ExecuteDoubleMovement(int start, int target)
        {
            squares[target] = squares[start];
            squares[start] = Piece.None;
            epFile = whiteToMove ? target - 8 : target + 8;
        }
        public void Capture(int start, int target)
        {
            if (whiteToMove)
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
            else
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
            if (squares[start] == (Piece.King | Piece.White))
            {
                WhiteKCastleRights = false;
                WhiteQCastleRights = false;
            }
            else if (squares[start] == (Piece.King | Piece.Black))
            {
                BlackKCastleRights = false;
                BlackQCastleRights = false;
            }
            else if (start == 0 && Piece.IsType(squares[start], (Piece.Rook | Piece.White)))
                WhiteQCastleRights = false;
            else if (start == 7 && Piece.IsType(squares[start], (Piece.Rook | Piece.White)))
                WhiteKCastleRights = false;
            else if (start == 56 && Piece.IsType(squares[start], (Piece.Rook | Piece.Black)))
                WhiteQCastleRights = false;
            else if (start == 63 && Piece.IsType(squares[start], (Piece.Rook | Piece.Black)))
                WhiteKCastleRights = false;

            gW.UpdateCaptures();
            if (squares[target] == (Piece.King | OpponentColor))
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
        public void EPCapture(int start, int target)
        {
            squares[target] = squares[start];
            if (whiteToMove)
            {
                gW.wPawnsV++;
                squares[target - 8] = Piece.None;
            }
            else if (!whiteToMove)
            {
                gW.bPawnsV++;
                squares[target + 8] = Piece.None;
            }
            squares[start] = Piece.None;
            epFile = -1;
        }
        public void Castle(int start, int target)
        {
            if (whiteToMove)
            {
                WhiteKCastleRights = false;
                WhiteQCastleRights = false;
            }
            else
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
            epFile = -1;
        }
        public void Promote(int start, int target)
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
    }
}
