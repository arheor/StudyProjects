using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void INSERTNEW(int elem, List<int> list)
        {
            int k = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == elem) k = 1;
            }
            if (k == 1) label1.Text = "список содержит\nзаданный элемент";
            else label1.Text = "4 8 3 9 " + elem;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            var kuk = new List<int>();
            int[] kuks = new int[] { 4, 8, 3, 9 };
            kuk.AddRange(kuks);
            int elem = Convert.ToInt32(textBox1.Text);
            INSERTNEW(elem, kuk);
            label1.Show();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

    }
}
