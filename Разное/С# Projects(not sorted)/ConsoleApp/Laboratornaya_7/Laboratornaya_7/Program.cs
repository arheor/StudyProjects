using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboratornaya_7
{
    class Program
    {
        static void Main(string[] args)
        {
            int a1, a2, a3;
            Console.WriteLine("Сумма цифр трехзначного числа кратна 7, само число также делиться на 7. Найти все такие числа.");
            Console.Write("Введите делитель: ");
            int del = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Подходящие числа:");
            for (int i = 100; i <= 999; i++)
            {
                a1 = i / 100;
                a2 = i / 10 % 10;
                a3 = i % 10;
                if ( i % del == 0 && sum(a1,a2,a3) % del == 0)
                    Console.Write(i + " ");
            }
            Console.ReadKey();
        }
        static double sum(int a1, int a2, int a3)
        {
            int s = a1 + a2 + a3;
            return s;
        }
    }
}
