using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace laba1_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void SPISOK(List<int> ar)
        {
            textBox1.Text = "";
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                int v = r.Next(100);
                textBox1.Text += " " + v;
                ar.Add(v);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var elem = new List<int>();
            SPISOK(elem);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
