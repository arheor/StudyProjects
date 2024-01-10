using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboratornaya3_2
{
    class Laboratornaya3
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите X: ");
            double x = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите Y: ");
            double y = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите R: ");
            double r = double.Parse(Console.ReadLine());
            double r2 = -r;
            if ((x >= 0 && y >= 0 && Math.Pow(x, 2) + Math.Pow(y, 2) <= Math.Pow(r, 2)) || (x <= 0 && y <= 0 && Math.Pow(x, 2) + Math.Pow(y, 2) <= Math.Pow(r, 2) && y <= -x - r2)) Console.WriteLine("Точка входит в закрашенную область");
            else Console.WriteLine("Точка не входит в закрашенную область");
            Console.ReadLine();
        }
    }
}
