using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PR1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            double m = Convert.ToInt32(textBox1.Text);
            double n = Convert.ToInt32(textBox2.Text);
            double mxn = m * n;
            textBox3.Text = Convert.ToString(mxn);
            int krat = 0;
            textBox4.Text += "Числа кратные " + n + ":" + System.Environment.NewLine;
            while (mxn > krat)
            {
                if (krat % n == 0 && krat != 0) textBox4.Text += krat + System.Environment.NewLine;
                krat++;
            }
            krat = 0;
            textBox4.Text += "Числа кратные " + m + ":" + System.Environment.NewLine;
            while (mxn > krat)
            {
                if (krat % m == 0 && krat != 0) textBox4.Text += krat + System.Environment.NewLine;
                krat++;
            }
        }
    }
}
