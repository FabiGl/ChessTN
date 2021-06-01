using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class GameWindow : Form
    {
        PictureBox[] pbArray = new PictureBox[64];
        PictureBox lastClicked = new PictureBox();
        Color lastColor = new Color();
        Board PlayingField;
        public Color lightColor = Color.Beige;
        public Color darkColor = Color.Salmon;
        public int mode { get; set; }

        public int wPawnsV = 0;
        public int wKnightsV = 0;
        public int wBishopsV = 0;
        public int wRooksV = 0;
        public int wQueensV = 0;

        public int bPawnsV = 0;
        public int bKnightsV = 0;
        public int bBishopsV = 0;
        public int bRooksV = 0;
        public int bQueensV = 0;

        public GameWindow(int mode)
        {
            InitializeComponent();
            this.mode = mode;
            UpdateCaptures();
        }

        public void CreateInterface()
        {
            lastClicked = null;
            int index = 0;
            for (int rank = 7; rank > -1; rank--)
            {
                for (int file = 0; file < 8; file++)
                {
                    bool isLightSquare = (rank + file) % 2 != 0;
                    Color squareColor = (isLightSquare) ? lightColor : darkColor;
                    PictureBox pb = new PictureBox();
                    pb.SizeMode = PictureBoxSizeMode.StretchImage;
                    pb.Name = index.ToString();
                    pb.Location = new Point((file * 75) + 12, (rank * 75) + 12);
                    pb.BackColor = squareColor;
                    pb.Size = new Size(75, 75);
                    Controls.Add(pb);
                    pbArray[index] = pb;
                    pb.MouseClick += new MouseEventHandler(SquareClicked);
                    index++;
                }
            }
            PlayingField = new Board(pbArray, this);
        }

        private void SquareClicked(object sender, MouseEventArgs e)
        {
            int res;
            PictureBox pb = FindPictureBoxAtCursor(this);
            if (lastClicked == null)
            {
                lastColor = pb.BackColor;
                lastClicked = pb;
                pb.BackColor = Color.Green;
            }
            else
            {
                res = PlayingField.MovementInput(Convert.ToInt32(lastClicked.Name), Convert.ToInt32(pb.Name));
                lastClicked.BackColor = lastColor;
                lastClicked = null;
                if (res == 0)
                    PlayingField.DrawBoard();
            }
        }
        public static PictureBox FindControlAtPoint(Control container, Point pos)
        {
            PictureBox child;
            PictureBox pb;
            foreach (Control c in container.Controls)
            {
                if (c.GetType() == typeof(PictureBox))
                {
                    pb = (PictureBox)c;
                    if (pb.Visible && pb.Bounds.Contains(pos))
                    {
                        child = FindControlAtPoint(pb, new Point(pos.X - pb.Left, pos.Y - pb.Top));
                        if (child == null) return pb;
                        else return child;
                    }
                }
            }
            return null;
        }

        public static PictureBox FindPictureBoxAtCursor(Form form)
        {
            Point pos = Cursor.Position;
            if (form.Bounds.Contains(pos))
                return FindControlAtPoint(form, form.PointToClient(pos));
            return null;
        }

        public void UpdateCaptures()
        {
            wPawns.Text = "Pawns:    " + wPawnsV;
            wKnights.Text = "Knights:    " + wKnightsV;
            wBishops.Text = "Bishops:    " + wBishopsV;
            wRooks.Text = "Rooks:    " + wRooksV;
            wQueens.Text = "Queens:    " + wQueensV;

            bPawns.Text = "Pawns:    " + bPawnsV;
            bKnights.Text = "Knights:    " + bKnightsV;
            bBishops.Text = "Bishops:    " + bBishopsV;
            bRooks.Text = "Rooks:    " + bRooksV;
            bQueens.Text = "Queens:    " + bQueensV;
        }

        public void UpdateOther(Coord coord1, Coord coord2)
        {
            switch (PlayingField.ColorToMove)
            {
                case Piece.White:
                    tmLabel.Text = "White to Move";
                    break;
                case Piece.Black:
                    tmLabel.Text = "Black to Move";
                    break;
            }
            bool halfTurn = PlayingField.plyCount % 2 == 0;
            int turn = PlayingField.plyCount;
            turn = halfTurn ? turn / 2 : (turn + 1) / 2;
            string sTurn = BoardRepresentation.SquareNameFromCoordinate(coord1);
            string sTurn2 = BoardRepresentation.SquareNameFromCoordinate(coord2);
            if (!halfTurn)
                turnHistoryTB.AppendText(turn + ".  " + sTurn +  " -> " + sTurn2 + "    ");
            else
                turnHistoryTB.AppendText(sTurn + " -> " + sTurn2 + "\n");
        }
        public void MatchRecap(char result)
        {
            MatchRecapInterface MRI = new MatchRecapInterface(turnHistoryTB, result);
            this.Hide();
            MRI.ShowDialog();
            this.Close();
        }
    }
}
