using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboratornaya4_1
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
            double x = Xn;
            double y = -10;
            double r = 1;
            Console.WriteLine("Аргумент(x)\tФункция(y)\t");
            Console.WriteLine();
            while (x < Xk + dx)
            {
                if (x >= -3 && x <= -2) y = -x - 2;
                if (x >= -2 && x <= -1) y = Math.Pow(r, 2) - Math.Pow(x, 2) + 3;
                if (x >= -1 && x <= 1) y = 1;
                if (x >= 1 && x <= 2) y = -2 * x + 3;
                if (x >= 2 && x <= 5) y = -1;
                if (y != -10 && x <= 5) Console.WriteLine("{0}\t\t{1}", x, y);
                else Console.WriteLine("Введено неверное значение X");
                x += dx;
            }
            Console.ReadLine();
        }
    }
}
