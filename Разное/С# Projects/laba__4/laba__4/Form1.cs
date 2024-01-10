using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace laba__4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            int[] v = { 0, -3, -10, -5, -7, 11, 56, 47, 100, 101 };
            for (int i = 0; i < v.Length; i++)
            {
                t.Insert(v[i]);
            }
        }

        BinarTree t = new BinarTree();

        public void button1_Click(object sender, EventArgs e)
        {
            
            BinarTree s = t.Search(0);
            if (textBox2.Text == "")
                s.show(textBox2);
            else
            {
                textBox2.Text = "";
                s.show(textBox2);
            }           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox3.Text);
            textBox3.Text = "";
            BinarTree s = t.Search(x);
            if (textBox2.Text == "")
                s.show(textBox3);
            else
            {
                textBox2.Text = "";
                s.show(textBox3);
            }           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    class BinarTree
    {
        private int? value;
        private BinarTree left;
        private BinarTree right;
        //добавляем
        public void Insert(int value)
        {
            if (this.value == null)
                this.value = value;
            else
            {
                if (this.value > value)
                {
                    if (left == null)
                        this.left = new BinarTree();
                    left.Insert(value);
                }
                else if (this.value < value)
                {
                    if (right == null)
                        this.right = new BinarTree();
                    right.Insert(value);
                }
                else
                    throw new Exception("Узел уже существует");
            }
        }
        // обход дерева в обратном порядке
        public BinarTree Search(int value)
        {
            if (this.value < value)
            {
                if (right != null)
                    return this.right.Search(value);
                else
                    throw new Exception("Искомого узла в дереве нет");
            }

            else if (this.value == value)
                return this;
            else
            {
                if (left != null)
                    return this.left.Search(value);
                else
                    throw new Exception("Искомого узла в дереве нет");
            }
        }
        public void show(System.Windows.Forms.TextBox tb)
        {
                if (left != null)
                    left.show(tb);
                
                if (right != null)
                    right.show(tb);
                tb.Text += value + " ";
        }
    }
}
