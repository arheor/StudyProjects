using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace laba_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        class Node
        {
            public string Data
            {
                get;
                set;
            }
            public Node Left
            {
                get;
                set;
            }
            public Node Right
            {
                get;
                set;
            }


            public Node(string data)
            {
                this.Data = data;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            label9.BackColor = Color.Transparent;
            label8.BackColor = Color.Transparent;
            label7.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label1.BackColor = Color.Transparent;

            label9.ForeColor = Color.Transparent;
            label8.ForeColor = Color.Transparent;
            label7.ForeColor = Color.Transparent;
            label6.ForeColor = Color.Transparent;
            label5.ForeColor = Color.Transparent;
            label4.ForeColor = Color.Transparent;
            label3.ForeColor = Color.Transparent;
            label2.ForeColor = Color.Transparent;
            label1.ForeColor = Color.Transparent;

            Node A1 = new Node("0");
            A1.Left = new Node("-3");
            A1.Right = new Node("11");
            A1.Right.Right = new Node("56");
            A1.Right.Right.Left = new Node("47");
            A1.Right.Right.Right = new Node("100");
            A1.Right.Right.Right.Right = new Node("101");
            A1.Left.Left = new Node("-10");
            A1.Left.Left.Right = new Node("-5");
            A1.Left.Left.Right.Left = new Node("-7");


            label1.Text = A1.Data;
            label2.Text = @"/      \ ";
            label3.Text = A1.Left.Data + "         " + A1.Right.Data;
            label4.Text = @"  /             \";
            label5.Text = A1.Left.Left.Data + "              " + A1.Right.Right.Data;
            label6.Text = @"\                / \";
            label7.Text = A1.Left.Left.Right.Data + "           " + A1.Right.Right.Left.Data + "    " + A1.Right.Right.Right.Data;
            label8.Text = @"/                         \";
            label9.Text = A1.Left.Left.Right.Left.Data + "                         " + A1.Right.Right.Right.Right.Data;
        }
    }
}

namespace WindowsFormsApplication5
{
    class BinaryTreeNode<TNode> : IComparable<TNode> where TNode : IComparable<TNode>
    {
        public BinaryTreeNode(TNode value)
        {
            Value = value;
        }
        public BinaryTreeNode<TNode> Left
        {
            get;
            set;
        }
        public BinaryTreeNode<TNode> Right
        {
            get;
            set;
        }

        public BinaryTreeNode<TNode> Search(System.Windows.Forms.TextBox tb)
        {

        }

        public TNode Value
        {
            get;
            set;
        }

        public int CompareTo(TNode other)
        {
            return Value.CompareTo(other);
        }

        public int CompareNode(BinaryTreeNode<TNode> other)
        {
            return Value.CompareTo(other.Value);
        }
        class Program
        {
            static void Main2(string[] args)
            {
                BinaryTreeNode<int> Node1 = new BinaryTreeNode<int>(0);
                BinaryTreeNode<int> Node2 = new BinaryTreeNode<int>(-3);
                BinaryTreeNode<int> Node3 = new BinaryTreeNode<int>(-10);
                BinaryTreeNode<int> Node4 = new BinaryTreeNode<int>(-5);
                BinaryTreeNode<int> Node5 = new BinaryTreeNode<int>(-7);
                BinaryTreeNode<int> Node6 = new BinaryTreeNode<int>(11);
                BinaryTreeNode<int> Node7 = new BinaryTreeNode<int>(56);
                BinaryTreeNode<int> Node8 = new BinaryTreeNode<int>(47);
                BinaryTreeNode<int> Node9 = new BinaryTreeNode<int>(100);
                BinaryTreeNode<int> Node10 = new BinaryTreeNode<int>(101);

                if (Node1.CompareNode(Node2) >= 0)
                {
                    Node1.Left = Node2;
                }

                else
                {
                    Node1.Right = Node2;
                }

                if (Node1.CompareNode(Node3) >= 0)
                {
                    Node1.Left = Node3;
                }

                else
                {
                    Node1.Right = Node3;
                }


                if (Node2.CompareNode(Node4) >= 0)
                {
                    Node2.Left = Node4;
                }

                else
                {
                    Node2.Right = Node5;
                }


                if (Node2.CompareNode(Node5) >= 0)
                {
                    Node2.Left = Node4;
                }

                else
                {
                    Node2.Right = Node5;
                }

                if (Node3.CompareNode(Node6) >= 0)
                {
                    Node2.Left = Node5;
                }

                else
                {
                    Node2.Right = Node6;
                }


                if (Node3.CompareNode(Node7) >= 0)
                {
                    Node2.Left = Node6;
                }

                else
                {
                    Node2.Right = Node7;
                }
            }
        }
    }
}


