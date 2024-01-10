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
    public partial class one_player : Form
    {
        //Создание Bitmap массива изображений
        Bitmap[] ticToe = new Bitmap[4] { Properties.Resources.x, Properties.Resources.o, Properties.Resources.winx, Properties.Resources.wino };
        byte[] Table = new byte[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        //логические переменные определяющие победу, поражение или ничью
        bool tic = true;
        bool is_win = false;
        bool is_standoff = false;
        //счетчик побед
        int winx = 0;
        int wino = 0;
        int standoff = 0;
        public one_player()
        {
            InitializeComponent();
        }
        //управление главной формой
        public Menu menu = new Menu();
        Form main = Application.OpenForms[0];
        //установка крестики либо нолика в свободную ячейку поля
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
                        step.Text = "Сейчас ходят нолики";
                    }
                    else
                    {
                        pic.Image = ticToe[1];
                        tic = !tic;
                        Table[Index] = 2;
                        step.Text = "Сейчас ходят крестики";
                    }
                }
            }
            return null;
        }
        //проверка выигрыша, ничьей
        void CheckWin()
        {
            if (is_win != true)
            {
                //проверка выигрыша крестиков
                if (Table[0] == 1 && Table[1] == 1 && Table[2] == 1)
                {
                    x1.Image = ticToe[2];
                    x2.Image = ticToe[2];
                    x3.Image = ticToe[2];
                    winx++;
                    info.Text = "Крестики: " + winx + " Нолики: " + wino + " Ничья: " + standoff;
                    step.Text = "Выиграли крестики";
                    is_win = true;
                    return;
                }
                if (Table[0] == 1 && Table[3] == 1 && Table[6] == 1)
                {
                    x1.Image = ticToe[2];
                    x4.Image = ticToe[2];
                    x7.Image = ticToe[2];
                    winx++;
                    info.Text = "Крестики: " + winx + " Нолики: " + wino + " Ничья: " + standoff;
                    step.Text = "Выиграли крестики";
                    is_win = true;
                    return;
                }
                if (Table[6] == 1 && Table[7] == 1 && Table[8] == 1)
                {
                    x7.Image = ticToe[2];
                    x8.Image = ticToe[2];
                    x9.Image = ticToe[2];
                    winx++;
                    info.Text = "Крестики: " + winx + " Нолики: " + wino + " Ничья: " + standoff;
                    step.Text = "Выиграли крестики";
                    is_win = true;
                    return;
                }
                if (Table[2] == 1 && Table[5] == 1 && Table[8] == 1)
                {
                    x3.Image = ticToe[2];
                    x6.Image = ticToe[2];
                    x9.Image = ticToe[2];
                    winx++;
                    info.Text = "Крестики: " + winx + " Нолики: " + wino + " Ничья: " + standoff;
                    step.Text = "Выиграли крестики";
                    is_win = true;
                    return;
                }
                if (Table[1] == 1 && Table[4] == 1 && Table[7] == 1)
                {
                    x2.Image = ticToe[2];
                    x5.Image = ticToe[2];
                    x8.Image = ticToe[2];
                    winx++;
                    info.Text = "Крестики: " + winx + " Нолики: " + wino + " Ничья: " + standoff;
                    step.Text = "Выиграли крестики";
                    is_win = true;
                    return;
                }
                if (Table[3] == 1 && Table[4] == 1 && Table[5] == 1)
                {
                    x4.Image = ticToe[2];
                    x5.Image = ticToe[2];
                    x6.Image = ticToe[2];
                    winx++;
                    info.Text = "Крестики: " + winx + " Нолики: " + wino + " Ничья: " + standoff;
                    step.Text = "Выиграли крестики";
                    is_win = true;
                    return;
                }
                if (Table[0] == 1 && Table[4] == 1 && Table[8] == 1)
                {
                    x1.Image = ticToe[2];
                    x5.Image = ticToe[2];
                    x9.Image = ticToe[2];
                    winx++;
                    info.Text = "Крестики: " + winx + " Нолики: " + wino + " Ничья: " + standoff;
                    step.Text = "Выиграли крестики";
                    is_win = true;
                    return;
                }
                if (Table[2] == 1 && Table[4] == 1 && Table[6] == 1)
                {
                    x3.Image = ticToe[2];
                    x5.Image = ticToe[2];
                    x7.Image = ticToe[2];
                    winx++;
                    info.Text = "Крестики: " + winx + " Нолики: " + wino + " Ничья: " + standoff;
                    step.Text = "Выиграли крестики";
                    is_win = true;
                    return;
                }
                //проверка выигрыша ноликов
                if (Table[0] == 2 && Table[1] == 2 && Table[2] == 2)
                {
                    x1.Image = ticToe[3];
                    x2.Image = ticToe[3];
                    x3.Image = ticToe[3];
                    wino++;
                    info.Text = "Крестики: " + winx + " Нолики: " + wino + " Ничья: " + standoff;
                    step.Text = "Выиграли нолики";
                    is_win = true;
                    return;
                }
                if (Table[0] == 2 && Table[3] == 2 && Table[6] == 2)
                {
                    x1.Image = ticToe[3];
                    x4.Image = ticToe[3];
                    x7.Image = ticToe[3];
                    wino++;
                    info.Text = "Крестики: " + winx + " Нолики: " + wino + " Ничья: " + standoff;
                    step.Text = "Выиграли нолики";
                    is_win = true;
                    return;
                }
                if (Table[6] == 2 && Table[7] == 2 && Table[8] == 2)
                {
                    x7.Image = ticToe[3];
                    x8.Image = ticToe[3];
                    x9.Image = ticToe[3];
                    wino++;
                    info.Text = "Крестики: " + winx + " Нолики: " + wino + " Ничья: " + standoff;
                    step.Text = "Выиграли нолики";
                    is_win = true;
                    return;
                }
                if (Table[2] == 2 && Table[5] == 2 && Table[8] == 2)
                {
                    x3.Image = ticToe[3];
                    x6.Image = ticToe[3];
                    x9.Image = ticToe[3];
                    wino++;
                    info.Text = "Крестики: " + winx + " Нолики: " + wino + " Ничья: " + standoff;
                    step.Text = "Выиграли нолики";
                    is_win = true;
                    return;
                }
                if (Table[1] == 2 && Table[4] == 2 && Table[7] == 2)
                {
                    x2.Image = ticToe[3];
                    x5.Image = ticToe[3];
                    x8.Image = ticToe[3];
                    wino++;
                    info.Text = "Крестики: " + winx + " Нолики: " + wino + " Ничья: " + standoff;
                    step.Text = "Выиграли нолики";
                    is_win = true;
                    return;
                }
                if (Table[3] == 2 && Table[4] == 2 && Table[5] == 2)
                {
                    x4.Image = ticToe[3];
                    x5.Image = ticToe[3];
                    x6.Image = ticToe[3];
                    wino++;
                    info.Text = "Крестики: " + winx + " Нолики: " + wino + " Ничья: " + standoff;
                    step.Text = "Выиграли нолики";
                    is_win = true;
                    return;
                }
                if (Table[0] == 2 && Table[4] == 2 && Table[8] == 2)
                {
                    x1.Image = ticToe[3];
                    x5.Image = ticToe[3];
                    x9.Image = ticToe[3];
                    wino++;
                    info.Text = "Крестики: " + winx + " Нолики: " + wino + " Ничья: " + standoff;
                    step.Text = "Выиграли нолики";
                    is_win = true;
                    return;
                }
                if (Table[2] == 2 && Table[4] == 2 && Table[6] == 2)
                {
                    x3.Image = ticToe[3];
                    x5.Image = ticToe[3];
                    x7.Image = ticToe[3];
                    wino++;
                    info.Text = "Крестики: " + winx + " Нолики: " + wino + " Ничья: " + standoff;
                    step.Text = "Выиграли нолики";
                    is_win = true;
                    return;
                }
                //проверка ничьей
                if (is_standoff == false && (Table[0] == 1 || Table[0] == 2) && (Table[1] == 1 || Table[1] == 2)
                    && (Table[2] == 1 || Table[2] == 2) && (Table[3] == 1 || Table[3] == 2)
                    && (Table[4] == 1 || Table[4] == 2) && (Table[5] == 1 || Table[5] == 2)
                    && (Table[6] == 1 || Table[6] == 2) && (Table[7] == 1 || Table[7] == 2)
                    && (Table[8] == 1 || Table[8] == 2))
                {
                    is_win = true;
                    is_standoff = true;
                    standoff++;
                    info.Text = "Крестики: " + winx + " Нолики: " + wino + " Ничья: " + standoff;
                    step.Text = "Ничья";
                    return;
                }
            }
        }
        //ход компьютера
        void brain()
        {
            bool value = false;
            while (value == false)
            {

                if (Table[4] == 0) { Set(ref x5, 4); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                //проверка на выигрыш средней ячейки строки/столбца(нолики)
                else if (Table[0] == 2 && Table[2] == 2 && Table[1] == 0) { Set(ref x2, 1); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return;}
                else if (Table[3] == 2 && Table[5] == 2 && Table[4] == 0) { Set(ref x5, 4); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                else if (Table[6] == 2 && Table[8] == 2 && Table[7] == 0) { Set(ref x8, 7); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                else if (Table[0] == 2 && Table[6] == 2 && Table[3] == 0) { Set(ref x4, 3); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                else if (Table[1] == 2 && Table[7] == 2 && Table[4] == 0) { Set(ref x5, 4); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                else if (Table[2] == 2 && Table[8] == 2 && Table[5] == 0) { Set(ref x6, 5); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                else if (Table[0] == 2 && Table[8] == 2 && Table[4] == 0) { Set(ref x5, 4); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                else if (Table[2] == 2 && Table[6] == 2 && Table[4] == 0) { Set(ref x5, 4); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                //проверка на выигрыш средней ячейки строки/столбца(крестики)
                else if (Table[0] == 1 && Table[2] == 1 && Table[1] == 0) { Set(ref x2, 1); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                else if (Table[3] == 1 && Table[5] == 1 && Table[4] == 0) { Set(ref x5, 4); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                else if (Table[6] == 1 && Table[8] == 1 && Table[7] == 0) { Set(ref x8, 7); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                else if (Table[0] == 1 && Table[6] == 1 && Table[3] == 0) { Set(ref x4, 3); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                else if (Table[1] == 1 && Table[7] == 1 && Table[4] == 0) { Set(ref x5, 4); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                else if (Table[2] == 1 && Table[8] == 1 && Table[5] == 0) { Set(ref x6, 5); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                else if (Table[0] == 1 && Table[8] == 1 && Table[4] == 0) { Set(ref x5, 4); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                else if (Table[2] == 1 && Table[6] == 1 && Table[4] == 0) { Set(ref x5, 4); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                //проверка на выигрыш крайней ячейки строки/столбца(нолики)
                else if (Table[0] == 2 && Table[1] == 2 && Table[2] == 0) { Set(ref x3, 2); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                else if (Table[5] == 2 && Table[8] == 2 && Table[2] == 0) { Set(ref x3, 2); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                else if (Table[6] == 2 && Table[7] == 2 && Table[8] == 0) { Set(ref x9, 8); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                else if (Table[2] == 2 && Table[5] == 2 && Table[8] == 0) { Set(ref x9, 8); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                else if (Table[0] == 2 && Table[3] == 2 && Table[6] == 0) { Set(ref x7, 6); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                else if (Table[7] == 2 && Table[8] == 2 && Table[6] == 0) { Set(ref x7, 6); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                else if (Table[1] == 2 && Table[2] == 2 && Table[0] == 0) { Set(ref x1, 0); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                else if (Table[3] == 2 && Table[6] == 2 && Table[0] == 0) { Set(ref x1, 0); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                else if (Table[3] == 2 && Table[4] == 2 && Table[5] == 0) { Set(ref x6, 5); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                else if (Table[1] == 2 && Table[4] == 2 && Table[7] == 0) { Set(ref x8, 7); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                else if (Table[4] == 2 && Table[5] == 2 && Table[3] == 0) { Set(ref x4, 3); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                else if (Table[4] == 2 && Table[7] == 2 && Table[1] == 0) { Set(ref x2, 1); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                //проверка на выигрыш крайней ячейки строки/столбца(крестики)
                else if (Table[0] == 1 && Table[1] == 1 && Table[2] == 0) { Set(ref x3, 2); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                else if (Table[5] == 1 && Table[8] == 1 && Table[2] == 0) { Set(ref x3, 2); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                else if (Table[6] == 1 && Table[7] == 1 && Table[8] == 0) { Set(ref x9, 8); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                else if (Table[2] == 1 && Table[5] == 1 && Table[8] == 0) { Set(ref x9, 8); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                else if (Table[0] == 1 && Table[3] == 1 && Table[6] == 0) { Set(ref x7, 6); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                else if (Table[7] == 1 && Table[8] == 1 && Table[6] == 0) { Set(ref x7, 6); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                else if (Table[1] == 1 && Table[2] == 1 && Table[0] == 0) { Set(ref x1, 0); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                else if (Table[3] == 1 && Table[6] == 1 && Table[0] == 0) { Set(ref x1, 0); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                else if (Table[3] == 1 && Table[4] == 1 && Table[5] == 0) { Set(ref x6, 5); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                else if (Table[1] == 1 && Table[4] == 1 && Table[7] == 0) { Set(ref x8, 7); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                else if (Table[4] == 1 && Table[5] == 1 && Table[3] == 0) { Set(ref x4, 3); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                else if (Table[4] == 1 && Table[7] == 1 && Table[1] == 0) { Set(ref x2, 1); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                //ход в оставшиеся незанятые ячейки
                else if (Table[0] == 0) { Set(ref x1, 0); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                else if (Table[2] == 0) { Set(ref x3, 2); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                else if (Table[6] == 0) { Set(ref x7, 6); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                else if (Table[8] == 0) { Set(ref x9, 8); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                else if (Table[1] == 0) { Set(ref x2, 1); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                else if (Table[3] == 0) { Set(ref x4, 3); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                else if (Table[5] == 0) { Set(ref x6, 5); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
                else if (Table[7] == 0) { Set(ref x8, 7); step.Text = "Сейчас ходят крестики"; value = true; CheckWin(); return; }
            }
        }
        //действие при нажатии на одну из девяти клеток поля
        private void x1_Click(object sender, EventArgs e)
        {
            if (Table[0] == 0)
            {
                Set(ref x1, 0);
                CheckWin();
                if (is_win != true) brain();
            }
        }

        private void x2_Click(object sender, EventArgs e)
        {
            if (Table[1] == 0)
            {
                Set(ref x2, 1);
                CheckWin();
                if (is_win != true) brain();
            }
        }

        private void x3_Click(object sender, EventArgs e)
        {
            if (Table[2] == 0)
            {
                Set(ref x3, 2);
                CheckWin();
                if (is_win != true) brain();
            }
        }

        private void x4_Click(object sender, EventArgs e)
        {
            if (Table[3] == 0)
            {
                Set(ref x4, 3);
                CheckWin();
                if (is_win != true) brain();
            }
        }

        private void x5_Click(object sender, EventArgs e)
        {
            if (Table[4] == 0)
            {
                Set(ref x5, 4);
                CheckWin();
                if (is_win != true) brain();
            }
        }

        private void x6_Click(object sender, EventArgs e)
        {
            if (Table[5] == 0)
            {
                Set(ref x6, 5);
                CheckWin();
                if (is_win != true) brain();
            }
        }

        private void x7_Click(object sender, EventArgs e)
        {
            if (Table[6] == 0)
            {
                Set(ref x7, 6);
                CheckWin();
                if (is_win != true) brain();
            }
        }

        private void x8_Click(object sender, EventArgs e)
        {
            if (Table[7] == 0)
            {
                Set(ref x8, 7);
                CheckWin();
                if (is_win != true) brain();
            }
        }

        private void x9_Click(object sender, EventArgs e)
        {
            if (Table[8] == 0)
            {
                Set(ref x9, 8);
                CheckWin();
                if (is_win != true) brain();
            }
        }
        //действие, вызываемое при закрытии формы
        private void one_player_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.Show();
        }
        //действие, при нажатии кнопки "Один игрок" в stripmenu
        private void одинИгрокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tic = true;
            is_win = false;
            is_standoff = false;
            step.Text = "Сейчас ходят крестики";
            Table = new byte[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            foreach (Control pict in Controls)
            {
                try
                {
                    ((PictureBox)pict).Image = null;
                }
                catch { }
            }
        }
        //действие, при нажатии кнопки "Два игрока" в stripmenu
        private void дваИгрокаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menu.two_players_Click(this, null);
            this.Close();
            main.Hide();
        }
        //действие, при нажатии кнопки "Выход в главное меню"
        private void выходВМенюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Show();
        }
        //действие, при нажатии кнопки "Выход"
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //действие, при нажатии кнопки "Начать заново"
        private void Reset_Click(object sender, EventArgs e)
        {
            tic = true;
            is_win = false;
            is_standoff = false;
            step.Text = "Сейчас ходят крестики";
            Table = new byte[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            foreach (Control pict in Controls)
            {
                try
                {
                    ((PictureBox)pict).Image = null;
                }
                catch { }
            }
        }
    }
}
