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
        //создание новых экземпляров 2й и 3й форм
        two_players tp;
        one_player op;
        //открытие 2й формы
        public void two_players_Click(object sender, EventArgs e)
        {
            tp = new two_players();
            tp.Show();
            this.Hide();
        }
        //открытие третьей формы
        public void one_player_Click(object sender, EventArgs e)
        {
            op = new one_player();
            op.Show();
            this.Hide();
        }
        //выход из приложения
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
