using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class PromotionInterface : Form
    {
        Board board;
        public PromotionInterface(Board b)
        {
            board = b;
            InitializeComponent();
            SetImages();
        }

        private void queenButton_Click(object sender, EventArgs e)
        {
            board.promotionChoice = Piece.Queen;
            this.Close();
        }

        private void rookButton_Click(object sender, EventArgs e)
        {
            board.promotionChoice = Piece.Rook;
            this.Close();
        }

        private void knightButton_Click(object sender, EventArgs e)
        {
            board.promotionChoice = Piece.Knight;
            this.Close();
        }

        private void bishopButton_Click(object sender, EventArgs e)
        {
            board.promotionChoice = Piece.Bishop;
            this.Close();
        }
        private void SetImages()
        {
            string fileNameQueen = (Piece.Queen | board.ColorToMove) + ".png";
            string pathQueen = Path.Combine(Environment.CurrentDirectory, @"PieceImages\", fileNameQueen);
            string fileNameRook = (Piece.Rook | board.ColorToMove) + ".png";
            string pathRook = Path.Combine(Environment.CurrentDirectory, @"PieceImages\", fileNameRook);
            string fileNameKnight = (Piece.Knight | board.ColorToMove) + ".png";
            string pathKnight = Path.Combine(Environment.CurrentDirectory, @"PieceImages\", fileNameKnight);
            string fileNameBishop = (Piece.Bishop | board.ColorToMove) + ".png";
            string pathBishop = Path.Combine(Environment.CurrentDirectory, @"PieceImages\", fileNameBishop);
            queenImage.Image = Image.FromFile(pathQueen);
            rookImage.Image = Image.FromFile(pathRook);
            knightImage.Image = Image.FromFile(pathKnight);
            bishopImage.Image = Image.FromFile(pathBishop);
        }
    }
}
