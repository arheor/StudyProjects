using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace laba_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public struct Spisok
        {
            public string key;
            public string value;
        }

        Spisok[] s = new Spisok[10];

        private void button1_Click(object sender, EventArgs e)
        {
            input(s);
        }

        private static bool contains(string key, Spisok[] s) // Узнаем есть ли у нас элемент в массиве s со значением key
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].key == key) return true;
            }
            return false;
        }

        private static int findKey(string key, Spisok[] s) // Находим индекс по ключу
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].key == key) return i;
            }
            return 0;
        }

        private void find(Spisok[] s)
        {
                string key = Convert.ToString(textBox3.Text);
                int i = findKey(key, s);
                if (contains(key, s))
                {
                    textBox3.Text = s[i].value;
                }
                else textBox3.Text = "Значение не найдено";
                if (contains(key, s) && s[i].value == null)
                    textBox3.Text = "Значение не найдено";
        }

        private void input(Spisok[] s)
        {
                string key = Convert.ToString(textBox1.Text);//ключ из текстбокс
                string value = Convert.ToString(textBox2.Text);//значение 
                int i = Convert.ToInt32(textBox1.Text);
                if (!contains(key, s))
                {
                    s[i].value = value;
                    s[i].key = key;
                }
                else
                {
                    s[findKey(key, s)].value = value;
                }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            find(s);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string value = Convert.ToString(textBox3.Text);
            for (int i = 0; i < s.Length; i++)
                if (value == s[i].value) s[i].value = null;
        }
    }
}
