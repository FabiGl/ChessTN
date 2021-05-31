using System;

namespace Chess
{
	public class Move
	{
		readonly int startSquare = 0;
		readonly int targetSquare = 0;
		public int type = 0; // 0 = Move; 1 = Capture; 2 = Doublemove; 3 = EP-Capture; 4 = Castle; 5 = Promotion
		Board board;
		
		public Move(int start, int target, Board b)
		{
			startSquare = start;
			targetSquare = target;
			board = b;
		}
		public Move(int start, int target, Board b, int type)
		{
			startSquare = start;
			targetSquare = target;
			board = b;
			this.type = type;
		}

		public void IsCapture()
        {
			bool res = (!Piece.IsType(board.squares[targetSquare], Piece.None));
			if (res)
				type = 1;
        }
		public bool IsIdentical(Move m)
        {
			bool res = false;
			if ((m.startSquare == this.startSquare) && (m.targetSquare == this.targetSquare))
				res = true;
			return res;
        }
		public void IsDoubleMove()
        {
			if (Piece.IsType(board.squares[startSquare], Piece.Pawn) && (targetSquare - 16 == startSquare) || (targetSquare + 16 == startSquare))
				type = 2;
        }
	}
}