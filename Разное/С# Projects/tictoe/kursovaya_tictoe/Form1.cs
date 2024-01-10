using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursovaya_tictoe
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void two_players_Click(object sender, EventArgs e)
        {
            two_players g = new two_players();
            g.Show();
            this.Hide();
        }

        private void one_player_Click(object sender, EventArgs e)
        {
            one_player h = new one_player();
            h.Show();
            this.Hide();
        }
    }
}
