using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public struct Spisok
        {
            public bool view;
            public int list;
            public int b;
        }

        public Form1()
        {
            InitializeComponent();
        }
        void DELETE(int elem, Spisok[] ar)
        {
            for (int i = 0; i < ar.Length; i++)
            {
                if (elem == ar[i].list) ar[i].view = false;
                if (ar[i].view) label4.Text += " " + ar[i].list;
            }
            
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Spisok[] ar = new Spisok[7];
            ar[0].list = 2;
            ar[1].list = 5;
            ar[2].list = 9;
            ar[3].list = 3;
            ar[4].list = 4;
            ar[5].list = 6;
            ar[6].list = 10;
            for (int i = 0; i < ar.Length; i++) ar[i].view = true;
            for (int i = 0; i < ar.Length; i++) ar[i].b = i;
            int elem = Convert.ToInt32(textBox1.Text);
            DELETE(elem, ar);
            label4.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
