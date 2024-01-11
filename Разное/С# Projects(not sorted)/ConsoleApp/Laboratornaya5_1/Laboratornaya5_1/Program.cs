using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboratornaya5_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Номер минимального по модулю элемента массива
            Console.WriteLine("1) Номер минимального по модулю элемента массива");
            Console.Write("Введите количество элементов массива N = ");
            int n = int.Parse(Console.ReadLine());
            double[] a = new double[n];
            Random r = new Random();
            int min = 0;
            int b = -1;
            for (int i = 0; i < n; i++)
            {
                a[i] = r.Next(0, 100) - 6;
                Console.Write("array[{0}] = ", i);
                Console.WriteLine(a[i]);

                if (Math.Abs(a[min]) > Math.Abs(a[i]))
                    min = i;
                if (a[i] < 0)
                    if (b == -1)
                        b = i;  
            }
            Console.WriteLine("Номер минимального по модулю элемента массива {0}", min);
            // Сумма модулей элементов массива, расположенных после первого отрицательного элемента
            Console.WriteLine("2) Сумма модулей элементов массива, расположенных после первого отрицательного элемента");
            if (b == -1)
                Console.WriteLine("В массиве нет отрицательных чисел: сумму не посчитать!");
            else
            {
                double sum = 0;
                for (int i = b + 1; i < n; i++)
                    sum += Math.Abs(a[i]);
                Console.WriteLine("Сумма модулей элементов массива, расположенных после первого отрицательного элемента = {0}", sum);
            }
            // Сжать массив, удалив из него все элементы, величина которых находится в интервале [а, b].
            // Освободившиеся в конце массива элементы заполнить нулями.
            Console.WriteLine("3) Сжать массив, удалив из него все элементы, величина которых находится в интервале [а, b]. Освободившиеся в конце массива элементы заполнить нулями.");
            Console.WriteLine("Введите a,b");
            string X, Y;
            X = Console.ReadLine();
            Y = Console.ReadLine();
            double x = Convert.ToDouble(X);
            double y = Convert.ToDouble(Y);
            if (y < x)
               {
                double temp = x;
                x = y;
                y = temp;
               }
            double[] arr = new double[20];
            for (int i = 0,k = 0; i < n;++i)
            {
                if (a[i] < x || a[i] > y)
                {
                    arr[k] = a[i];
                    k++;
                }
            }
            Console.WriteLine("Сжатый массив:");
            for (int i = 0; i < n; i++)
                Console.Write(" " + arr[i]);
            Console.ReadKey();
        }
    }
}
