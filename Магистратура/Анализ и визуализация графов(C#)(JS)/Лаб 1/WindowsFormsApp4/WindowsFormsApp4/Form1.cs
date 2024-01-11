using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        int[,] adjmatrix;
        int[,] arclist;
        int temp;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void arcmatrix_Click(object sender, EventArgs e)
        {
            adjmatrix = null;
            arclist = null;

            OpenFileDialog OPF = new OpenFileDialog();
            OPF.Filter = "Файлы txt|*.txt";
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                arclistTextBox1.Text = "   ";
                adjmatrixTextBox2.Text = "   ";
                adjlistTextBox1.Text = "   ";

                //загружаем и выводим список дуг
                string[] lines = File.ReadAllLines(OPF.FileName);
                arclist = new int[lines.Length, lines[0].Split(' ').Length];
                for (int k = 0; k < lines[0].Split(' ').Length; k++)
                {
                    arclistTextBox1.Text += ' ';
                    arclistTextBox1.Text += k + 1;
                }
                arclistTextBox1.Text += '\n';

                for (int i = 0; i < lines.Length; i++)
                {
                    string[] temp = lines[i].Split(' ');
                    for (int j = 0; j < temp.Length; j++)
                        arclist[i, j] = Convert.ToInt32(temp[j]);
                }
                for (int i = 0; i < arclist.GetLength(0); i++)
                {
                    arclistTextBox1.Text += i + 1;
                    arclistTextBox1.Text += "  ";
                    for (int j = 0; j < arclist.GetLength(1); j++)
                    {
                        arclistTextBox1.Text += arclist[i, j];
                        arclistTextBox1.Text += ' ';
                    }
                    arclistTextBox1.Text += '\n';
                }

                //преобразуем в матрицу смежности
                adjmatrix = new int[arclist.GetLength(1), arclist.GetLength(1)];
                for (int i = 0; i < arclist.GetLength(1); i++)
                {
                    if (arclist[2, i] > 0)
                        adjmatrix[arclist[0, i] - 1, arclist[1, i] - 1] = arclist[2, i];
                }
                //выводим
                for (int k = 0; k < lines[0].Split(' ').Length; k++)
                {
                    adjmatrixTextBox2.Text += ' ';
                    adjmatrixTextBox2.Text += k + 1;
                }
                adjmatrixTextBox2.Text += '\n';
                for (int i = 0; i < adjmatrix.GetLength(0); i++)
                {
                    adjmatrixTextBox2.Text += i + 1;
                    adjmatrixTextBox2.Text += "  ";
                    for (int j = 0; j < adjmatrix.GetLength(1); j++)
                    {
                        adjmatrixTextBox2.Text += adjmatrix[i, j];
                        adjmatrixTextBox2.Text += ' ';
                    }
                    adjmatrixTextBox2.Text += '\n';
                }

                //список смежности
                temp = arclist.GetLength(1);
                Graph g = new Graph(temp);
                for(int i = 0; i < arclist.GetLength(1); i++)
                {
                    g.addEdgeAtEnd(arclist[0,i], arclist[1,i], arclist[2,i]);
                }
                adjlistTextBox1.Text = g.info();

            }
        }
    }
}
