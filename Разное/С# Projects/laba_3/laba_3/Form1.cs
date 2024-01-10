using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace laba_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] spisok1 = new string[10] {"","P","М","М","P","X","F","X","G","G"};
            string[] spisok2 = new string[10] {"P","M","D","E","X","F","H","G","J","K"};
            LEFTMOST_CHILD(spisok1, spisok2, this.textBox1.Text.ToUpper());
        }
        public void LEFTMOST_CHILD(string[] spisok1, string[] spisok2, string p)
        {
            textBox2.Text = "";
            if (p != "P")
                for (int i = 0; i < spisok1.Length; i++)
                {
                    if (spisok2[i] == p)
                        textBox2.Text += "Элемент " + spisok2[i] + " имеет родителя " + PARENT(ref spisok1, ref i);
                }
            else textBox2.Text += "Элемент " + p + " является корнем";

        }
        private static string PARENT(ref string[] b, ref int i)
        {
            return b[i];
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
