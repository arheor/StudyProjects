using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace massive1
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n=4;
            int[] a = new int[n];
            for (int i = 0; i < n; ++i)
            {
                Console.Write("Введите элемент массива №{0} ", i + 1);
                a[i] = Convert.ToInt16(Console.ReadLine());
            }
            Console.WriteLine("Исходный массив: ");
            for (int i = 0; i < n; ++i)
            {
                Console.Write(" " + a[i]);
            }
            Console.ReadKey();
        }
    }
}
