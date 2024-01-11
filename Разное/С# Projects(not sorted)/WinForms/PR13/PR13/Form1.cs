using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace PR13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            oleDbConnection1.Open(); //открыть соединение
                                     //заполнить таблицы в объекте DataSet
            oleDbDataAdapter1.Fill(dataSet11.Info);
            oleDbDataAdapter1.Fill(dataSet11.DopInfo);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            oleDbConnection1.Close();   //закрыть соединение
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
