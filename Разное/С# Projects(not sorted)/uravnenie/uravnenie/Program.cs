using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uravnenie
{
    class Program
    {
        public static double koren1(double a, double b, double c, double x1)
        {
            x1 = (-b + Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
            return (x1);
        }
        public static double koren2(double a, double b, double c, double x2)
        {
            x2 = (-b - Math.Sqrt(b*b-4*a*c)) / (2 * a);
            return (x2);
        }
        public static void Main()
        {
            double x1 = 0, x2 = 0;
            Console.Write("Введите a: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Введите b: ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("Введите с: ");
            double c = double.Parse(Console.ReadLine());
            double d = b*b-4*a*c;
            double X1 = koren1(a,b,c,x1);
            double X2 = koren2(a,b,c,x2);
            if (d>0) Console.WriteLine("x1 = {0}\nx2 = {1}", X1, X2);
            if (d == 0) Console.WriteLine("x = {0}", X1);
            if (d < 0) Console.WriteLine("Корней нет");
            Console.ReadKey();
        }
    }
}
