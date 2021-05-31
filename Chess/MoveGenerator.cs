using System;
using System.Collections.Generic;

namespace Chess
{
    public class MoveGenerator
    {
        int[] Offsets = new int[] { -9, -8, -7, -1, 1, 7, 8, 9};
        int[] simulatedBoard = new int[64];
        int[] backupBoard = new int[64];
        public List<Move> moves;
        public List<Move> backupMoves;
        public static Board board;
        int friendlyColor;
        public void AddBoard(Board b)
        {
            board = b;
        }

        public List<Move> GenerateMoves () // Pseudo Legale Moves (z.B. den König selbst in ein Schach zu bewegen wird nicht verhindert.) Mögliche lösung: Alle moves simulieren und schauen ob einer als target das Feld des Königs enthält
        {
            simulatedBoard = board.squares;
            friendlyColor = board.ColorToMove;
            
            moves = new List<Move>();

            for (int startSquare = 0; startSquare < 64; startSquare++)
            {
                int piece = board.squares[startSquare];
                if (Piece.IsColor (piece, board.ColorToMove))
                {
                    if (Piece.IsSlidingPiece(piece))
                    {
                        GenerateSlidingMoves(startSquare, piece);
                    }
                    else if (Piece.IsType(piece, Piece.King))
                    {
                        GenerateKingMoves(startSquare);
                    }
                    else if (Piece.IsType(piece, Piece.Pawn))
                    {
                        GeneratePawnMoves(startSquare);
                    }
                    else if (Piece.IsType(piece, Piece.Knight))
                    {
                        GenerateKnightMoves(startSquare);
                    }
                }
            }

            return moves;
        }

        public void GenerateSlidingMoves(int startSquare, int piece)
        {
            int startDir = (Piece.IsType(piece, Piece.Bishop)) ? 4 : 0;
            int endDir = (Piece.IsType(piece, Piece.Rook)) ? 4 : 8;

            for (int direction = startDir; direction < endDir; direction++)
            {
                for (int n = 0; n < PrecomputedData.numSquaresToEdge[startSquare][direction]; n++)
                {
                    int targetSquare = startSquare + PrecomputedData.directionOffsets[direction] * (n + 1);
                    int pieceOnTargetSquare = board.squares[targetSquare];

                    if (Piece.IsColor(pieceOnTargetSquare, friendlyColor))
                        break;
                    moves.Add(new Move(startSquare, targetSquare, board));
                }
            }
        }
        public void GenerateKingMoves(int startSquare)
        {
            for (int direction = 0; direction < 8; direction++)
            {
                for (int n = 0; n < PrecomputedData.numSquaresToEdge[startSquare][direction]; n++)
                {
                    int targetSquare = startSquare + PrecomputedData.directionOffsets[direction];
                    int pieceOnTargetSquare = board.squares[targetSquare];

                    if (Piece.IsColor(pieceOnTargetSquare, friendlyColor))
                        break;
                    moves.Add(new Move(startSquare, targetSquare, board));
                }
            }
            if (board.whiteToMove)
            {
                if (board.WhiteQCastleRights)
                {
                    if (Piece.IsType(board.squares[0], Piece.Rook) && Piece.IsType(board.squares[1], Piece.None) && Piece.IsType(board.squares[2], Piece.None) && Piece.IsType(board.squares[3], Piece.None))
                    {
                        moves.Add(new Move(startSquare, 2, board, 4));
                    }
                }
                if (board.WhiteKCastleRights)
                {
                    if (Piece.IsType(board.squares[7], Piece.Rook) && Piece.IsType(board.squares[5], Piece.None) && Piece.IsType(board.squares[6], Piece.None))
                    {
                        moves.Add(new Move(startSquare, 6, board, 4));
                    }
                }
            }
            else
            {
                if (board.BlackQCastleRights)
                {
                    if (Piece.IsType(board.squares[56], Piece.Rook) && Piece.IsType(board.squares[57], Piece.None) && Piece.IsType(board.squares[58], Piece.None) && Piece.IsType(board.squares[59], Piece.None))
                    {
                        moves.Add(new Move(startSquare, 58, board, 4));
                    }
                }
                if (board.BlackKCastleRights)
                {
                    if (Piece.IsType(board.squares[63], Piece.Rook) && Piece.IsType(board.squares[61], Piece.None) && Piece.IsType(board.squares[62], Piece.None))
                    {
                        moves.Add(new Move(startSquare, 62, board, 4));
                    }
                }
            }
        }
        public void GeneratePawnMoves(int startSquare)
        {
            int targetSquare = 0;
            int offsetInvert;
            bool doubleMovePossible = false;

            offsetInvert = board.whiteToMove ? 1 : -1;

            if (board.whiteToMove && (startSquare < 16 && startSquare > 7))
            {
                targetSquare = startSquare + PrecomputedData.pawnOffsets[3] * offsetInvert;
                doubleMovePossible = true;
            }
            else if (!board.whiteToMove && (startSquare < 56 && startSquare > 47))
            {
                targetSquare = startSquare + PrecomputedData.pawnOffsets[3] * offsetInvert;
                doubleMovePossible = true;
            }
            if (doubleMovePossible)
            {
                if (Piece.IsType(board.squares[targetSquare], Piece.None) && Piece.IsType(board.squares[targetSquare - (8 * offsetInvert)], Piece.None))
                    moves.Add(new Move(startSquare, targetSquare, board));
            }
            for (int i = 1; i < 3; i++)
            {
                targetSquare = startSquare + PrecomputedData.pawnOffsets[i] * offsetInvert;
                if (targetSquare < 64 && targetSquare > -1)
                {
                    int pieceOnTargetSquare = board.squares[targetSquare];

                    if (Piece.IsColor(pieceOnTargetSquare, friendlyColor) || ((Piece.IsType(pieceOnTargetSquare, Piece.None) && targetSquare != board.epFile)))
                        continue;
                    if (targetSquare != board.epFile)
                        moves.Add(new Move(startSquare, targetSquare, board));
                    else
                        moves.Add(new Move(startSquare, targetSquare, board, 3));
                }
            }
            targetSquare = startSquare + PrecomputedData.pawnOffsets[0] * offsetInvert;
            if (targetSquare < 64 && targetSquare > -1)
            {
                int pieceOnTargetSquare = board.squares[targetSquare];

                if (Piece.IsType(pieceOnTargetSquare, Piece.None))
                {
                    if (board.whiteToMove && (targetSquare > 55))
                    {
                        moves.Add(new Move(startSquare, targetSquare, board, 5));
                    }
                    else if (!board.whiteToMove && targetSquare < 8)
                    {
                        moves.Add(new Move(startSquare, targetSquare, board, 5));
                    }
                    else
                        moves.Add(new Move(startSquare, targetSquare, board ));
                }
            }
        }
        public void GenerateKnightMoves(int startSquare)
        {
            for (int direction = 0; direction < 8; direction++)
            {
                int targetSquare = startSquare + PrecomputedData.knightOffsets[direction];
                if (targetSquare < 64 && targetSquare > -1)
                {
                    int pieceOnTargetSquare = board.squares[targetSquare];

                    if (Piece.IsColor(pieceOnTargetSquare, friendlyColor))
                        continue;
                    moves.Add(new Move(startSquare, targetSquare, board));
                }
            }
        }
    }
}
