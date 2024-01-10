using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace popytka1
{
    class Program
    {
        //метод для перестановки 2х линейных массивов; 
        static private void swapArray(double[,] An, int index, int lengthOfMatrix)
        {
            for (int i = 0; i < lengthOfMatrix; ++i)
                swapDouble(ref An[index, i], ref An[index + 1, i]);
        }
        //метод для перестановки 2х элементов;
        static private void swapDouble(ref double Buffer1, ref double Buffer2)
        {
            double Tmp = Buffer1;
            Buffer1 = Buffer2;
            Buffer2 = Tmp;
        }
        // сортировка матрицы по первым элементам строк
        static private void sort(double[,] An, int n,out int kol)
        {
            kol = new int();
            bool flagOfSwapping = true;
            int numberOfIteration = new int();
            while (flagOfSwapping) // цикл выполняется пока есть хотя бы одна перестановка в ходе итерации;
            {
                flagOfSwapping = false;
                for (int i = 0; i < n - 1 - numberOfIteration; ++i)
                    if (An[i, 0] < An[i + 1, 0])
                    {
                        swapArray(An, i, n);
                        flagOfSwapping = true;
                        ++kol;
                    }
                numberOfIteration++;
            }
        }

        static void Main(string[] args)
        {
            //создание матрицы
            int n,k;
            double kof;
            Console.Write("Введите размерность матрицы: ");
            n = Convert.ToInt32(Console.ReadLine());
            double[,] a = new double[n, n];// основная матрица
            double[] x = new double[n];
            double[] b = new double[n];
            double[,] array = new double[n, n + 1];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    Console.Write("A[{0},{1}] = ", i, j);
                    a[i, j] = Convert.ToDouble(Console.ReadLine());
                } // заполняем матрицу
            for (int i = 0; i < n; i++)
                {
                    Console.Write("b[{0}] = ", i);
                    b[i] = Convert.ToDouble(Console.ReadLine());
                }
            Console.WriteLine("Исходная матрица: ");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("{0:0} ", a[i, j]);
                }
                Console.WriteLine("{0:0}", b[i]);
            }
            //объединяем матрицы системы и правой части, а затем сортируем(по наибольшему значению)
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = a[i, j];
                }
            for (int i = 0; i <n ;i++)
                for (int j = 0;j<n+1;j++)
                    array[i, n] = b[i];
            int kol;
            sort(array, n, out kol);//сортировка
            for (int i = 0; i < n; i++)//делим матрицу на вектор правой части и основную матрицу
                for (int j = 0; j < n; j++)
                {
                    a[i, j] = array[i, j];
                }
            for (int i = 0; i <n ;i++)
                for (int j = 0;j<n+1;j++)
                    b[i] = array[i,n];
            for (k = 0; k < n - 1; k++)//приводим к треугольному виду
            {
                for (int i = k + 1; i < n; i++)
                {
                    kof = -1 * a[i, k] / a[k, k];
                    b[i] = b[i] + kof * b[k];
                    for (int j = k; j < n; j++)
                    {
                        a[i, j] = a[i, j] + a[k, j] * kof;
                    }
                }
            }
            Console.WriteLine("Матрица, приведенная к треугольному виду");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("{0:0} ", a[i, j]);
                }
                Console.WriteLine("{0:0}", b[i]);
            }
            //вычисление результата
            x[n - 1] = b[n - 1] / a[n - 1, n - 1];
            double sum = 0;
            for (int z = n - 2; z >= 0; --z)
            {
                sum = 0;
                for (int j = z + 1; j < n; j++)
                {
                    sum = sum + a[z, j] * x[j];
                    x[z] = (b[z] - sum) / a[z, z];
                }
            }
            Console.WriteLine("Решение: ");
            for (int i = 0; i < n; i++)
                Console.WriteLine("Х[{0}] = {1}", i+1 ,x[i]);
            Console.ReadKey();
        }
    }
}
