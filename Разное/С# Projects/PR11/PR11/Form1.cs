using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void function()
        {
            for (int x1 = -10; x1 <= 10; x1++)
            {
                double f = Math.Sin(x1) * (Math.Pow(x1, 2) + 4);
                chart1.Series[0].Points.AddXY(x1, f);
                chart2.Series[0].Points.AddXY(x1, f);
                chart3.Series[0].Points.AddXY(x1, f);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Integral integral = new Integral();
            integral.n = Convert.ToDouble(textBox1.Text);
            textBox3.Text = integral.rectangle();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            function();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Integral integral = new Integral();
            integral.n = Convert.ToDouble(textBox4.Text);
            textBox2.Text = integral.trapecia();
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            textBox4.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Integral integral = new Integral();
            integral.n = Convert.ToDouble(textBox6.Text);
            textBox5.Text = integral.Simpson();
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            textBox6.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
