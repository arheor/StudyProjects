using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (double x = -7; x <= 7; x+=0.5)
            {
                if (x < 0)
                    chart1.Series[1].Points.AddXY(x, (1 / Math.Pow(x, 2)) - 1);
                else if (x > 0) chart1.Series[2].Points.AddXY(x, (1 / Math.Pow(x, 2)) - 1);
                chart1.Series[0].Points.AddXY(x,Math.Pow(Math.E, -x));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Uravnenie ur = new Uravnenie();
            ur.a = Convert.ToDouble(textBox1.Text);
            ur.b = Convert.ToDouble(textBox2.Text);
            ur.eps = Convert.ToDouble(textBox3.Text);
            if (radioButton1.Checked == true)
                textBox4.Text = Convert.ToString(ur.dihotomi());
            if (radioButton2.Checked == true)
                textBox4.Text = Convert.ToString(ur.hord());
            if (radioButton3.Checked == true)
                textBox4.Text = Convert.ToString(ur.kasatelnix());
        }
    }
}
