using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
	public static class PrecomputedData
	{
		// Erst Orthogonal, dann Diagonal (N, S, W, O, NW, SO, NO, SW)
		public static readonly int[] directionOffsets = { 8, -8, -1, 1, 7, -7, 9, -9 };
		public static readonly int[] pawnOffsets = { 8, 7, 9, 16 };
		public static readonly int[] knightOffsets = { 15, 17, -17, -15, 10, -6, 6, -10 };

		public static readonly int[][] numSquaresToEdge = new int[64][];

		public static void ComputeData()
		{ 
			for (int file = 0; file < 8; file ++)
            {
				for (int rank = 0; rank < 8; rank++)
                {
					int numNorth = 7 - rank;
					int numSouth = rank;
					int numWest = file;
					int numEast = 7 - file;

					int squareIndex = rank * 8 + file;

					numSquaresToEdge[squareIndex] = new int[8];
					numSquaresToEdge[squareIndex][0] = numNorth;
					numSquaresToEdge[squareIndex][1] = numSouth;
					numSquaresToEdge[squareIndex][2] = numWest;
					numSquaresToEdge[squareIndex][3] = numEast;
					numSquaresToEdge[squareIndex][4] = Math.Min(numNorth, numWest);
					numSquaresToEdge[squareIndex][5] = Math.Min(numSouth, numEast);
					numSquaresToEdge[squareIndex][6] = Math.Min(numNorth, numEast);
					numSquaresToEdge[squareIndex][7] = Math.Min(numSouth, numWest);
				}
            }
		}
	}
}