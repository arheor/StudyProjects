using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace lab10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount-1; i++)
            {
                //Создаем WebRequest-запрос no URI-адресу.
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://" + dataGridView1.Rows[i].Cells[i].Value);
                //Отправляем этот запрос и получаем ответ.
                HttpWebResponse resp = (HttpWebResponse) req.GetResponse();
                //Получаем список имен.
                textBox1.Text = resp.Headers.Keys.Get(4);
                //Закрываем поток, содержащий ответ.
                resp.Close();
            }

        }
    }
}
