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
    public partial class MatchRecapInterface : Form
    {
        RichTextBox movementHistory;
        char winner;

        public MatchRecapInterface(RichTextBox mH, char w)
        {
            InitializeComponent();
            this.BackColor = Color.LightGray;
            winner = w;
            movementHistory = mH;

            switch (winner)
            {
                case 'w':
                    winnerPB.BackColor = Color.White;
                    break;
                case 'b':
                    winnerPB.BackColor = Color.Black;
                    break;
                case 'r':
                    winnerPB.BackColor = Color.Gray;
                    break;
            }

            moveHistory.AppendText("\n" + mH.Text);
        }

        private void backToMenu_Click(object sender, EventArgs e)
        {
            Menu m = new Menu();
            this.Hide();
            m.ShowDialog();
            this.Close();
        }
    }
}
