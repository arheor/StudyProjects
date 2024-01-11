using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PR2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        geo new_Info;
        private void button1_Click(object sender, EventArgs e)
        {
            if (SortBox.Text != "")
                if (VesBox.Text != "")
                    if (CountryBox.Text != "")
                        new_Info = new geo(SortBox.Text, Convert.ToInt32(VesBox.Text), Convert.ToString(monthCalendar1.SelectionEnd.Date), CountryBox.Text);
            else
                if (SortBox.Text == "")
                    MessageBox.Show("Введите сорт.");
                    if (VesBox.Text == "")
                        MessageBox.Show("Введите объем.");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            InfoBox.Text += new_Info.GetInformation();
        }

    }
}
