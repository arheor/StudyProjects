using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    class Program
    {
        static void Main(string[] args)
        {
            int r = 0;
            List<int> dl = new List<int>();
            dl.Add(59);
            dl.Add(4);
            dl.Add(63);
            dl.Add(10);
            dl.Add(16);
            dl.Add(5);
            dl.Add(7);
            dl.Add(23);
            dl.Add(78);
            dl.Add(9);
            Console.WriteLine("Исходный список: ");
            foreach (int s in dl)
            { Console.Write("   " + s.ToString()); }
            Console.WriteLine();
            foreach (int s in dl)
            { r = s; break; }
            dl.RemoveAt(0);
            dl.Insert(dl.Count, r);
            Console.WriteLine("Список после удаления последнего элемента: ");
            foreach (int s in dl)
            {
                Console.Write("   " + s.ToString());
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
