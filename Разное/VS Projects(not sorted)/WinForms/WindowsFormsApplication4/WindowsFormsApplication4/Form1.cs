using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void SPISOK(LinkedList<int> elem)
        {
            textBox1.Text = "";
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                int v = r.Next(-10,10);
                textBox1.Text += " " + v;
                elem.AddFirst(v);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LinkedList<int> elem = new LinkedList<int>();
            SPISOK(elem);
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < elem.Count; i++)
            {
                if (elem.ElementAt(i) >= 0) queue.Enqueue(elem.ElementAt(i));
            }
            
            textBox2.Text = " ";
            for (int i = queue.Count; i > 0; i--)
            {
                textBox2.Text += queue.ElementAt(i-1) + " ";
            }
        }
        
    }
}
