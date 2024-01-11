using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace matrica2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] a = new int[5,5];
            Random r = new Random();
            Console.WriteLine("Исходный массив:");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    a[i, j] = r.Next(100);
                    Console.Write(" " + a[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

    }
}
