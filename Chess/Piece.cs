﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
	public static class Piece
	{
		public const int None = 0; //XX000
		public const int King = 1; //XX001
		public const int Pawn = 2; //XX010
		public const int Knight = 3; //XX011
		public const int Bishop = 5; //XX101
		public const int Rook = 6; //XX110
		public const int Queen = 7; //XX111

		public const int White = 8; //01XXX
		public const int Black = 16; //10XXX

		public const int typeMask = 0b00111;
		public const int blackMask = 0b10000;
		public const int whiteMask = 0b01000;
		public const int colorMask = whiteMask | blackMask;

		public static bool IsColor(int piece, int color)
		{
			return (piece & colorMask) == color;
		}

		public static int Color(int piece)
		{
			return piece & colorMask;
		}

		public static int PieceType(int piece)
		{
			return piece & typeMask;
		}

		public static bool IsRookOrQueen(int piece)
		{
			return (piece & 0b110) == 0b110;
		}

		public static bool IsBishopOrQueen(int piece)
		{
			return (piece & 0b101) == 0b101;
		}

		public static bool IsSlidingPiece(int piece)
		{
			return (piece & 0b100) != 0;
		}

		public static bool IsType(int piece, int type)
        {
			return (piece & typeMask) == type;
        }

	}
}
