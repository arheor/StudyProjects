using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace massive3
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 10;
            int[] a = new int[n];
            for (int i = 0; i < n; ++i)
            {
                Console.Write("Введите элемент массива №{0} ", i + 1);
                a[i] = Convert.ToInt16(Console.ReadLine());
            }
            int sum = 0;
            int pr = 1;
            int k = 0;
            for (int i = 0; i < n; ++i)
                if (a[i] < 0)
                {
                    sum += a[i];
                    pr *= a[i];
                    k++;
                }
            Console.WriteLine("Исходный массив: ");
            for (int i = 0; i < n; ++i)
                Console.Write(" " + a[i]);
            Console.WriteLine();
            Console.WriteLine("Сумма отрицательных элементов: " + sum);
            Console.WriteLine("Произведение отрицательных элементов: " + pr);
            Console.WriteLine("Количество отрицательных элементов: " + k);
            Console.ReadKey();
        }
    }
}
