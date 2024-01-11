using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace laba_6
{
    public partial class Form1 : Form
    {
        decimal g, h;
        Int32 add2pyramid(Int32[] arr, Int32 i, Int32 N)
        {
            Int32 imax;
            Int32 buf;
            if ((2 * i + 2) < N)
            {
                if (arr[2 * i + 1] < arr[2 * i + 2]) imax = 2 * i + 2;
                else imax = 2 * i + 1;
            }
            else imax = 2 * i + 1;
            if (imax >= N) return i;
            if (arr[i] < arr[imax])
            {
                buf = arr[i];
                arr[i] = arr[imax];
                arr[imax] = buf;
                if (imax < N / 2) i = imax;
            }
            return i;
        }
        void Pyramid_Sort(Int32[] arr, Int32 len)
        {
            //step 1: building the pyramid
            for (Int32 i = len / 2 - 1; i >= 0; --i)
            {
                g++;
                long prev_i = i;
                i = add2pyramid(arr, i, len);
                if (prev_i != i) ++i;
            }
            //step 2: sorting
            Int32 buf;
            for (Int32 k = len - 1; k > 0; --k)
            {
                buf = arr[0];
                arr[0] = arr[k];
                arr[k] = buf;
                Int32 i = 0, prev_i = -1;
                g++;
                while (i != prev_i)
                {
                    g++;
                    prev_i = i;
                    i = add2pyramid(arr, i, k);
                }
            }
        }

        void HeapSort(int[] a)
        {
            int i;
            int temp;
            for (i = a.Length / 2 - 1; i >= 0; i--)
            {
                h++;
                shiftDown(a, i, a.Length);
            }

            for (i = a.Length - 1; i >= 1; i--)
            {
                temp = a[0];
                a[0] = a[i];
                a[i] = temp;
                h++;
                shiftDown(a, 0, i);
            }
        }

        void shiftDown(int[] a, int i, int j)
        {
            bool done = false;
            int maxChild;
            int temp;

            while ((i * 2 + 1 < j) && (!done))
            {
                h++;
                if (i * 2 + 1 == j - 1)
                    maxChild = i * 2 + 1;
                else if (a[i * 2 + 1] > a[i * 2 + 2])
                    maxChild = i * 2 + 1;
                else
                    maxChild = i * 2 + 2;

                if (a[i] < a[maxChild])
                {
                    temp = a[i];
                    a[i] = a[maxChild];
                    a[maxChild] = temp;
                    i = maxChild;
                }
                else
                {
                    done = true;
                }
            }
        }

        Int32[] arr = new Int32[100];
        int[] a = new int[100];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            g = 0; h = 0;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            Random rd = new Random();
            for (Int32 i = 0; i < arr.Length; ++i)
            {
                arr[i] = rd.Next(1, 101);
            }
            for (Int32 i = 0; i < arr.Length; ++i)
            {
                a[i] = arr[i];
            }
            foreach (Int32 x in arr)
            {
                textBox1.Text += (x + " ");
            }
            //сортировка
            Pyramid_Sort(arr, arr.Length);
            HeapSort(a);
            foreach (Int32 x in arr)
            {
                textBox2.Text += (x + " ");
            }
            foreach (int x in a)
            {
                textBox3.Text += (x + " ");
            }
            textBox4.Text += g;
            textBox5.Text += h;
            if (g > h) textBox6.Text = "Алгоритм пирамидально-турнирной сортировки на " + Convert.ToString(Math.Round(h / g * 100, 2)) + " %" + " эффективнее" + " алгоритма турнирной сортировки";
            else textBox6.Text = "Алгоритм турнирной сортировки на " + Convert.ToString(Math.Round(g / h * 100, 2)) + " %" + " эффективнее" + " алгоритма пирамидально-турнирной сортировки";
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
