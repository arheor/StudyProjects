using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gauss
{
    class Program
    {
        static void Main(string[] args)
        {
            //создание матрицы
            int n = 5;
            int[,] a = new int[n, n];
            Random r = new Random();
            Console.WriteLine("Исходная матрица:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    a[i, j] = r.Next(0, 10);
                    Console.Write(" " + a[i, j]);
                }
                Console.WriteLine();
            }
            //запоминаем матрицу
            int[,] b = new int[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    b[i, j] = a[i, j];

           
            //приведение к треугольному виду

            for (int j = 0; j < n; j++)
                for (int i = j + 1; i < n; i++)
                    b[i, j] = b[i, j] - b[i, j] * b[j, j] / b[j, j];

            //вывод на экран преобразованной матрицы
            Console.WriteLine("Приведенная к треугольному виду матрица:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(" " + a[i, j]);
                }
                Console.WriteLine();
            }










            Console.ReadKey();
        }
    }
}
