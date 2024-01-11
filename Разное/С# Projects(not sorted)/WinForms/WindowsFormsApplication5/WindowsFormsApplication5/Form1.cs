using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        //Метод, в котором считаются числа Каталана по рекуррентной формуле
        int katalan(int n)
        {
            //если число n меньше 0 выводится предупреждение
            if (n < 0)
                MessageBox.Show("Введите n > 0");
            //инициализация переменных
            int i, sum;
            //если n меньше 1, возвращает 1
            if (n == 0)
                return 1;
            //обнуление суммы
            sum = 0;
            //вычисляется только при n>0
            if (n > 0)
                //рекуррентная формула, считающая числа Каталана
                for (i = 0; i < n; i++)
                    sum += katalan(i) * katalan((n - 1) - i);
            return sum;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //первоначальная инициализзация n
            int n = -1;
            //очистка окна вывода результата
            textBox2.Text = "";
            //если окно ввода пусто, то ввод числа n пользователем, иначе вывод предупреждения
            if (textBox1.Text != "")
                n = Convert.ToInt32(textBox1.Text) - 1;
            else MessageBox.Show("Введите n > 0");
            //вывод чисел Каталана в окно вывода результата, если n >= 0, иначе вывод предупреждения
            if (n >= 0)
                textBox2.Text = Convert.ToString(katalan(n));
            else MessageBox.Show("Введите n > 0");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        //кнопка выхода из приложения
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
