using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace laba_7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static long T(int n)
        {
            if (n == 1) return 3;
            else return 16 * T(n - 1) + 4;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "i " + ";" + " T(i)" + "\n";
            for (int i = 1; i <= 50; i++)
            {
                richTextBox1.Text += Convert.ToString(i) + ";" + Convert.ToString(T(i)) + "\n";
            }
            FileInfo f = new FileInfo("C:/Users/night/Desktop/1/tablica.csv");
            StreamWriter writer = f.CreateText();          
            writer.WriteLine(richTextBox1.Text + "\t");
            writer.Write(writer.NewLine);
            writer.Close();
            MessageBox.Show("Таблица успешно сохранена в: tablica.csv");
        }
    }
}
