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
    public partial class ChessMenu : Form
    {

        public ChessMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<ChessGame>().Count() == 1)
            {
                MessageBox.Show("Game already open");
            }
            else
            {
                ChessGame ChessGame = new ChessGame();
                ChessGame.Show();
                ChessGame.Text = "Chess";
                ChessGame.Name = "Chess Game";
                ChessGame.FormClosed += new System.Windows.Forms.FormClosedEventHandler(ChessGame_FormClosed);
                this.Hide();
            }
        }
        private void ChessGame_FormClosed(object sender, EventArgs e)
        {
            this.Show();
        }
    }
}
