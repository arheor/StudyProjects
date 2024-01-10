using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tis3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[2].Points.Clear();
            double x = 0;
            int a = Convert.ToInt32(textBox1.Text);
            double k = double.Parse(textBox2.Text);
            while (x <= 10)
            {
                var y = a * Math.Cos(x);
                double z = 0;
                for (int i = -a; i <= a; i++)
                {
                    if (y >= i * k & y < (i + 1) * k)
                        z = i * k;
                }
                chart1.Series[1].Points.AddXY(x, z);
                chart1.Series[0].Points.AddXY(x, y);
                x = x + 0.01;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            double x = 0;
            int a = Convert.ToInt32(textBox1.Text);
            double k = Convert.ToDouble(textBox2.Text);
            while (x <= 10)
            {
                var y = a * Math.Cos(x);
                double f = 0;
                for (int i = -a; i <= a; i++)
                {
                    if (y >= i * k & y < (i + 0.5) * k)
                        f = i * k;
                    else
                    {
                        if (y >= (i + 0.5) * k & y < (i + 1) * k)
                            f = (i + 1) * k;
                    }
                }
                chart1.Series[2].Points.AddXY(x, f);
                chart1.Series[0].Points.AddXY(x, y);
                x = x + 0.01;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Clear();
        }
    }
}
