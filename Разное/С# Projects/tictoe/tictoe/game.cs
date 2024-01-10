using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tictoe
{
    public partial class game : Form
    {
        Bitmap[] ticToe = new Bitmap[4] { Properties.Resources.tic, Properties.Resources.toe, Properties.Resources.wintic, Properties.Resources.wintoe };
        byte[] Table = new byte[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        bool tic = true;
        bool is_win = false;
        public game()
        {
            InitializeComponent();
        }
        Form main = Application.OpenForms[0];
        Bitmap Set(ref PictureBox pic, int Index)
        {
            if (!is_win)
            {
                if (Table[Index] == 0)
                {
                    if (tic)
                    {
                        pic.Image = ticToe[0];
                        tic = !tic;
                        Table[Index] = 1;
                    }
                    else
                    {
                        pic.Image = ticToe[1];
                        tic = !tic;
                        Table[Index] = 2;
                    }
                }
            }
            return null;
        }
        void CheckWin()
        {
            #region
            if (Table[0] == 1 && Table[1] == 1 && Table[2] == 1)
            {
                x1.Image = ticToe[2];
                x2.Image = ticToe[2];
                x3.Image = ticToe[2];
                is_win = true;
                return;
            }
            if (Table[0] == 1 && Table[3] == 1 && Table[6] == 1)
            {
                x1.Image = ticToe[2];
                x4.Image = ticToe[2];
                x7.Image = ticToe[2];
                is_win = true;
                return;
            }
            if (Table[6] == 1 && Table[7] == 1 && Table[8] == 1)
            {
                x7.Image = ticToe[2];
                x8.Image = ticToe[2];
                x9.Image = ticToe[2];
                is_win = true;
                return;
            }
            if (Table[2] == 1 && Table[5] == 1 && Table[8] == 1)
            {
                x3.Image = ticToe[2];
                x6.Image = ticToe[2];
                x9.Image = ticToe[2];
                is_win = true;
                return;
            }
            if (Table[1] == 1 && Table[4] == 1 && Table[7] == 1)
            {
                x2.Image = ticToe[2];
                x5.Image = ticToe[2];
                x8.Image = ticToe[2];
                is_win = true;
                return;
            }
            if (Table[3] == 1 && Table[4] == 1 && Table[5] == 1)
            {
                x4.Image = ticToe[2];
                x5.Image = ticToe[2];
                x6.Image = ticToe[2];
                is_win = true;
                return;
            }
            if (Table[0] == 1 && Table[4] == 1 && Table[8] == 1)
            {
                x1.Image = ticToe[2];
                x5.Image = ticToe[2];
                x9.Image = ticToe[2];
                is_win = true;
                return;
            }
            if (Table[2] == 1 && Table[4] == 1 && Table[6] == 1)
            {
                x3.Image = ticToe[2];
                x5.Image = ticToe[2];
                x7.Image = ticToe[2];
                is_win = true;
                return;
            }
            #endregion // check tic
            #region
            if (Table[0] == 2 && Table[1] == 2 && Table[2] == 2)
            {
                x1.Image = ticToe[3];
                x2.Image = ticToe[3];
                x3.Image = ticToe[3];
                is_win = true;
                return;
            }
            if (Table[0] == 2 && Table[3] == 2 && Table[6] == 2)
            {
                x1.Image = ticToe[3];
                x4.Image = ticToe[3];
                x7.Image = ticToe[3];
                is_win = true;
                return;
            }
            if (Table[6] == 2 && Table[7] == 2 && Table[8] == 2)
            {
                x7.Image = ticToe[3];
                x8.Image = ticToe[3];
                x9.Image = ticToe[3];
                is_win = true;
                return;
            }
            if (Table[2] == 2 && Table[5] == 2 && Table[8] == 2)
            {
                x3.Image = ticToe[3];
                x6.Image = ticToe[3];
                x9.Image = ticToe[3];
                is_win = true;
                return;
            }
            if (Table[1] == 2 && Table[4] == 2 && Table[7] == 2)
            {
                x2.Image = ticToe[3];
                x5.Image = ticToe[3];
                x8.Image = ticToe[3];
                is_win = true;
                return;
            }
            if (Table[3] == 2 && Table[4] == 2 && Table[5] == 2)
            {
                x4.Image = ticToe[3];
                x5.Image = ticToe[3];
                x6.Image = ticToe[3];
                is_win = true;
                return;
            }
            if (Table[0] == 2 && Table[4] == 2 && Table[8] == 2)
            {
                x1.Image = ticToe[3];
                x5.Image = ticToe[3];
                x9.Image = ticToe[3];
                is_win = true;
                return;
            }
            if (Table[2] == 2 && Table[4] == 2 && Table[6] == 2)
            {
                x3.Image = ticToe[3];
                x5.Image = ticToe[3];
                x7.Image = ticToe[3];
                is_win = true;
                return;
            }

            #endregion // check toe
        }
        private void x1_Click(object sender, EventArgs e)
        {
            Set(ref x1, 0);
            CheckWin();
        }

        private void x2_Click(object sender, EventArgs e)
        {
            Set(ref x2, 1);
            CheckWin();
        }

        private void x3_Click(object sender, EventArgs e)
        {
            Set(ref x3, 2);
            CheckWin();
        }

        private void x4_Click(object sender, EventArgs e)
        {
            Set(ref x4, 3);
            CheckWin();
        }

        private void x5_Click(object sender, EventArgs e)
        {
            Set(ref x5, 4);
            CheckWin();
        }

        private void x6_Click(object sender, EventArgs e)
        {
            Set(ref x6, 5);
            CheckWin();
        }

        private void x7_Click(object sender, EventArgs e)
        {
            Set(ref x7, 6);
            CheckWin();
        }

        private void x8_Click(object sender, EventArgs e)
        {
            Set(ref x8, 7);
            CheckWin();
        }

        private void x9_Click(object sender, EventArgs e)
        {
            Set(ref x9, 8);
            CheckWin();
        }

        private void game_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.Show();
        }
    }
}
