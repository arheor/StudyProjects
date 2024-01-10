using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace massive2
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 5;
            int[] a = new int[n]; 
            Random r = new Random();
            Console.WriteLine("Исходный массив: ");
            for (int i = 0; i < n; ++i)
            {
                a[i] = r.Next(0, 15) - 7;
                Console.Write(" " + a[i]);
            }
            Console.ReadKey();
        }
    }
}
