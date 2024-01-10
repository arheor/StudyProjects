using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboratornaya_6
{
    class Program
    {
        static void Main(string[] args)
        {
            //создание матрицы
            int n = 5;
            int m = 6;
            int[,] a = new int[n, m];
            Random r = new Random();
            Console.WriteLine("Исходная матрица:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    a[i, j] = r.Next(1, 10);
                    Console.Write(" " + a[i, j]);
                }
                Console.WriteLine();
            }
            //количество строк
            Console.WriteLine("Ведите число х: ");
            int x = int.Parse(Console.ReadLine());
            int k = 0;
            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                for (int j = 0; j < m; j++)
                {
                    sum += a[i, j];
                }
                if (sum < x)
                    ++k;
            }
            Console.WriteLine("Кол-во строк где средняя арифметическая сумма меньше заданного числа " + k);
            //приведение к треугольному виду

            for (int j = 0; j < m; j++)
                for (int i = j + 1; i < n; i++)
                    a[i, j] = a[i, j] - a[i, j] * a[j, j] / a[j, j];

            //вывод на экран преобразованной матрицы
            Console.WriteLine("Приведенная к треугольному виду матрица:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(" " + a[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }     
    }
}
