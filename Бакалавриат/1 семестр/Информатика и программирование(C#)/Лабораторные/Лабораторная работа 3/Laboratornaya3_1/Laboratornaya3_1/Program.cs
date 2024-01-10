using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboratornaya3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите X: ");
            double x = double.Parse(Console.ReadLine());
            double y = -10;
            double r = 1;
            if (x >= -3 && x <= -2) y = -x - 2;
            if (x >= -2 && x <= -1) y = (Math.Pow(r, 2) - Math.Pow(x, 2) + 3);
            if (x >= -1 && x <= 1) y = 1;
            if (x >= 1 && x <= 2) y = -2 * x + 3;
            if (x >= 2 && x <= 5) y = -1;
            if (y != -10) Console.WriteLine("Y равен " + y);
            else Console.WriteLine("Введено неверное значение X");
            Console.ReadLine();
        }
    }
}
