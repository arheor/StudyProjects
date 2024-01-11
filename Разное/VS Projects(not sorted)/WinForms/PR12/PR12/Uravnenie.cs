using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR12
{
    class Uravnenie
    {
        public double a, b;
        public double eps;
        double function(double x)
        {
            /*(Math.Pow(Math.E, -x) / Math.Pow(x, 2)) - 1*/
            return (Math.Pow(Math.E, -x) / Math.Pow(x, 2)) - 1;
        }
        double df(double x)
        {
            return -Math.Pow(Math.E, -x) / Math.Pow(x, 3) * (x + 2);
        }
        //metod polovinnogo delenia
        public double dihotomi()
        {
            double c;

            while (Math.Abs(b - a) > 2 * eps)
            {
                if (a != 0 && b != 0)
                {
                    c = (a + b) / 2;
                    if (function(a) * function(c) > 0)
                        a = c;
                    else b = c;
                }
                else if (a == 0) a++; else b++;
            }
            return (a + b) / 2;
        }
        public double hord()
        {

            while (Math.Abs(b - a) > eps)
            {
                if (a != 0 && b != 0)
                {
                    a = b - (b - a) * function(b) / (function(b) - function(a));
                    b = a + (a - b) * function(a) / (function(a) - function(b));
                }
                else if (a == 0) a++; else b++;
            }
            return b;
        }
        public double kasatelnix()
        {
            double xn;
            Random r = new Random();
            double x0 = (b+a)/2;
            do
            {
                xn = x0 - function(x0) / df(x0);
            } while (xn - x0 > eps);
            return xn;
        }
    }
}
