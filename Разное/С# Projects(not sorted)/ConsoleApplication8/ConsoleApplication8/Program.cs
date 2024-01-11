using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        public struct Spisok
        { public int x;}
        static public void LOCATE_and_INSERT(Spisok[] a)
        {
            List<int> Spisok = new List<int>();
            int c, w = 0;
            Console.WriteLine("Введите элемент для поиска");
            c = Convert.ToInt16(Console.ReadLine());
            for (int t = 0; t < a.Length; t++)
            {
                if (a[t].x == c)
                { w++; }

            } if (w > 0)
            {
                for (int i = 0; i < a.Length; i++)
                { Spisok.Add(a[i].x); }
                Spisok.Insert(a.Length, c); Console.WriteLine
("Измененный список с элементом, который есть в списке: ");
                Spisok.ForEach(delegate(int name)
                { Console.Write("  " + name); });
            }
            else Console.WriteLine("Элемента нет в списке.");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Исходный список: ");
            Random r = new Random();
            Spisok[] a = new Spisok[10];
            for (int i = 0; i < a.Length; i++)
            {
                a[i].x = r.Next(-10, 10);
                Console.Write("  " + a[i].x);
            } Console.WriteLine();
            LOCATE_and_INSERT(a);
            Console.ReadKey();
        }
    }
}
