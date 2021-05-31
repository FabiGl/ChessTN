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
    public partial class Menu : Form
    {
        GameWindow Game = new GameWindow(0);
        public Menu()
        {
            InitializeComponent();
            string path = Path.Combine(Environment.CurrentDirectory, @"Resources\MenuBG.gif");
            Background.Image = Image.FromFile(path);
        }

        private void Multiplayer_Click(object sender, EventArgs e)
        {
            Game.mode = 2;
            this.Hide();
            Game.ShowDialog();
            this.Close();
        }

        private void Singleplayer_Click(object sender, EventArgs e)
        {
            Game.mode = 1;
            this.Hide();
            Game.ShowDialog();
            this.Close();
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            SettingsMenu sM = new SettingsMenu(Game);
            sM.Show();
        }
    }
}
