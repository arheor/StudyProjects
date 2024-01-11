
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace evklid
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1)Алрорим Евклида №1");
            Console.WriteLine("2)Алгоритм Евклида(рекурсивный) №2");
            Console.WriteLine("3)Решето Эратосфена №3");
            Console.Write("Выберите алгоритм:");
            char x = (char)Console.Read();
            Console.ReadLine();
            switch (x)
            {
                case '1': Main1(); break;
                case '2': Main2(); break;
                case '3': Main3(); break;
            }
            Console.ReadKey();
        }
        static int NOD1(int a, int b)
        {
            while ((a * b)!= 0)
            {
                if (a > b) a = a % b;
                else b = b & a;
            }
            return a + b;
        }
        static void Main1()
        {
            Console.Write("a = ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("b = ");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.Write("Наибольший общий делитель = ");
            Console.WriteLine(NOD1(a, b));
            Console.ReadKey();
        }
        static int NOD2(int a, int b)
        {
            if (a * b == 0)
                return a + b;
            if (a > b)
                return NOD2(b, a % b);
            else
                return (NOD2(a, b % a));
        }
        static void Main2()
        {
            Console.Write("a = ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("b = ");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.Write("Наибольший общий делитель = ");
            Console.WriteLine(NOD2(a, b));
            Console.ReadKey();
        }
        static void Main3()
        {
            Console.Write("Введите количество чисел n = ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] a = new int[n + 1];
            for (int i = 1; i <= n; i++)
                a[i] = 1;
                for (int k = 2; k * k <= n; k++)
                    if (a[k] != 0)
                        for (int i = k + k; i <= n; i += k)
                            a[i] = 0;
                for (int i = 1; i <= n; i++)
                {
                    if (a[i] == 1)
                        Console.Write(" " + i);
                }
            Console.ReadKey();
        }
    }
}
