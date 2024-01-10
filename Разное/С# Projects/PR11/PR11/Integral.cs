using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR11
{
    class Integral
    {
        //метод средних прямоугольников
        //h-высота,s-вся площадь,n-количество прямоугольников,f-функция
        public double a = 3, b = 5, h, s = 0, n, f;
        public string rectangle()
        {
            for (double x1 = 0, x = a; x <= b; x += h)
            {
                h = (b - a) / n;
                if (x < b)
                {
                    x1 = x + h / 2;
                    f = Math.Sin(x1) * (Math.Pow(x1, 2) + 4);
                    s += f;
                }
            }
            return Convert.ToString(Math.Round(s * h, 3));
        }
        //метод трапеции
        public string trapecia()
        {
            double f0 = Math.Sin(a) * (Math.Pow(a, 2) + 4);
            double fn = Math.Sin(b) * (Math.Pow(b, 2) + 4);
            h = (b - a) / n;
            for (double x1 = a; x1 <= b; x1 += h)
            {
                if (x1 < b)
                {
                    f = Math.Sin(x1) * (Math.Pow(x1, 2) + 4);
                    s += f;
                }
            }
            return Convert.ToString(Math.Round(h * (s + (f0 + fn) / 2), 3));
        }
        //метод Симпсона
        //h - , f0 - первое значение функции,fn - значение последнего значения подынтегральной функции
        public string Simpson()
        {
            h = (b - a) / n;
            double f0 = Math.Sin(a) * (Math.Pow(a, 2) + 4);
            double fn = Math.Sin(b) * (Math.Pow(b, 2) + 4);
            for (double x1 = a + h, i = 0; x1 < b; x1 += h, i++)
            {
                if (i % 2 == 0)
                {
                    f = 2 * (Math.Sin(x1) * (Math.Pow(x1, 2) + 4));
                    s += f;
                }
                if (i % 2 != 0)
                {
                    f = 4 * (Math.Sin(x1) * (Math.Pow(x1, 2) + 4));
                    s += f;
                }
            }
            return Convert.ToString(Math.Round(h / 3 * (f0 + fn + s), 3));
        }
    }
}
