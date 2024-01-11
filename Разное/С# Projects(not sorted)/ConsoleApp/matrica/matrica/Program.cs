using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace matrica
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 2, m = 4;
            int[,] a;
            a = new int [n,m];
            for (int i = 0; i<n; i++)
            for (int j = 0; j<m; j++)
                {
                    Console.Write("Введите а[{0},{1}] = ", i, j);
                    a[i,j] = Convert.ToInt16(Console.ReadLine());
                }
            Console.WriteLine("Исходный массив:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                Console.Write(" " + a[i, j]);
                Console.WriteLine();
            }
           Console.ReadKey();
        }
    }
}
