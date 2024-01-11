using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Math;
using static System.Console;
using System.Data.SqlClient;

namespace iis4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        const string connectionString = @"Data Source=NIGHT;Initial Catalog=IIS;Integrated Security=True";
        SqlConnection connect = new SqlConnection(connectionString);
        private void Form1_Load(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("(select isa from [Семейство воробьиных]) union all " +
                "(select isa from[Семейство ястребиных]) union all (select isa from Ласточки)", connect);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            DataRow row = dt.NewRow();
            row[0] = "";
            dt.Rows.InsertAt(row, 0);
            family_comboBox2.DataSource = dt;
            family_comboBox2.DisplayMember = "isa";
            family_comboBox2.ValueMember = "isa";
            SqlDataAdapter adapter1 = new SqlDataAdapter("(select isa1 from Воробьи) union all " +
                "(select isa1 from Соловьи) union all (select isa1 from Мухоловки)", connect);
            DataTable dt1 = new DataTable();
            adapter1.Fill(dt1);
            DataRow row1 = dt1.NewRow();
            row1[0] = "";
            dt1.Rows.InsertAt(row1, 0);
            connect.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (type_comboBox1.Text != "")
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from [" + type_comboBox1.Text + "]", connect);
                DataTable dt1 = new DataTable();
                da.Fill(dt1);
                dataGridView1.DataSource = dt1;
                connect.Close();
            }
            if (family_comboBox2.Text != "")
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from [" + family_comboBox2.Text + "]", connect);
                DataTable dt1 = new DataTable();
                da.Fill(dt1);
                dataGridView1.DataSource = dt1;
                dataGridView1.Columns[2].Visible = false;
                connect.Close();
            }
        }

        private void type_comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            family_comboBox2.Enabled = true;
        }

        private void family_comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            vid_comboBox3.Enabled = true;
        }

        private void family_comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (family_comboBox2.SelectedItem == "Семейство воробьиных")
            {
                vid_comboBox3.Items.Clear();
                vid_comboBox3.Items.Add("Домашние воробьи");
                vid_comboBox3.Items.Add("Полевые воробьи");
                vid_comboBox3.Items.Add("Воробьи Харриса");
            }
            else vid_comboBox3.Items.Clear();
            if (family_comboBox2.Text == "")
            {
                vid_comboBox3.Enabled = false;
            }
            else
            {
                vid_comboBox3.Enabled = true;
            }
        }

        private void type_comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (type_comboBox1.Text == "")
            {
                family_comboBox2.Enabled = false;
            }
            else
            {
                family_comboBox2.Enabled = true;
            }
        }
    }
}
