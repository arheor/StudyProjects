using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace factorial
{
    class Program
    {
        public static int factorial(int n,out int r)
        {
            r = 1;
            for (int i = 2; i <= n; ++i)
                r *= i;
            return r;
        }
        public static void Main()
        {
            int r;
            Console.Write("Введите число: ");
            int n = int.Parse(Console.ReadLine());
            factorial(n,out r);
            if (n > 0) Console.WriteLine("Факториал {0} равен {1}", n, r);
            else Console.WriteLine("Факториал {0} равен {1}", n, 0);
            Console.ReadKey();
        }
    }
}
