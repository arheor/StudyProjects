using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornaya4_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите начальное значение аргумента |X|>1: ");
            double Xn = double.Parse(Console.ReadLine());
            Console.Write("Введите конечное значение аргумента |X|>1: ");
            double Xk = double.Parse(Console.ReadLine());
            Console.Write("Введите шаг dx: ");
            double dx = double.Parse(Console.ReadLine());
            Console.Write("Введите точность: ");
            double eps = double.Parse(Console.ReadLine());
            int n;
            double result, result2;
            double x = Xn;
            if (Math.Abs(Xn) > 1)
            {
                Console.WriteLine("Аргумент\tФункция\t\tКоличество слагаемых");
                Console.WriteLine();
                double sum = 0;
                while (x < Xk + dx)
                {
                    n = 0;
                    do
                    {
                        result = 1 / ((2 * n + 1) * Math.Pow(x, 2 * n + 1));
                        result2 = 1 / ((2 * (n + 1) + 1) * Math.Pow(x, 2 * (n + 1) + 1));
                        sum += result;
                        n++;
                    }
                    while (result - result2 > eps);
                    Console.WriteLine("{0:f8}\t{1:f8}\t{2}", x, sum, n);
                    x += dx;
                }
            }
            else Console.WriteLine("Введено неверное значение Х");
            Console.WriteLine("\nДля выхода нажмите любую клавишу");
            Console.ReadKey();
        }
    }
}