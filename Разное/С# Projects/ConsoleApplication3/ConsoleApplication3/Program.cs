using System;
using System.Collections.Generic;
using System.Text;
namespace ConsoleApplication_Kramer
{
    class Program
    {
        static void Main(string[] args)
        {
            int n; /* количество уравнений */
            double[,] A = new double[3, 3]; /* матрица системы */
            double[] b = new double[3]; /* вектор правых частей */
            double[] x = new double[3]; /* вектор решения */
            Console.Write("Введите размерность матрицы(<=3): ");
            n = Convert.ToInt32(Console.ReadLine());
            if (n > 3 || n <= 1)
            {
                Console.WriteLine("Ошибка в размерности системы (n=2,3)");
                Convert.ToInt32(Console.ReadLine());
                return;
            }
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    Console.Write("A[{0},{1}] = ", i, j);
                    A[i, j] = Convert.ToDouble(Console.ReadLine());
                }
            for (int i = 0; i < n; i++)
            {
                Console.Write("b[{0}] = ", i);
                b[i] = Convert.ToDouble(Console.ReadLine());
            }
            if (SLAU_kramer(n, A, b, x) == 1)
            {
                Console.WriteLine("Система не имеет решение");
                Convert.ToInt32(Console.ReadLine());
                return;
            }
            else
                for (int i = 0; i < n; i++)
                    Console.WriteLine("x[{0}] = {1}" ,i,x[i]);
            Console.ReadLine();
        }
        private
        static double det(int n, double[,] B)
        {
            if (n == 2)
                return B[0, 0] * B[1, 1] - B[0, 1] * B[1, 0];
            return B[0, 0] * (B[1, 1] * B[2, 2] - B[1, 2] * B[2, 1]) - B[0, 1] * (B[1, 0] * B[2, 2] - B[1, 2] * B[2, 0]) +
            B[0, 2] * (B[1, 0] * B[2, 1] - B[1, 1] * B[2, 0]);
        }
        static void equal(int n, double[,] A, double[,] B)
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    A[i, j] = B[i, j];
        }
        static void change(int n, int N, double[,] A, double[] b)
        {
            for (int i = 0; i < n; i++)
                A[i, N] = b[i];
        }
        public
        static int SLAU_kramer(int n, double[,] A, double[] b, double[] x)
        {
            double[,] An = new double[3, 3];
            double det1 = det(n, A);
            if (det1 == 0) return 1;
            for (int i = 0; i < n; i++)
            {
                equal(n, An, A);
                change(n, i, An, b);
                x[i] = det(n, An) / det1;
            }
            return 0;
        }
    }
}