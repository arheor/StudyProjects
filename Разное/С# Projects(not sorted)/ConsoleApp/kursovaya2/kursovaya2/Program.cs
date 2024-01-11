using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kursovaya
{
    class Program
    {
        class Base
        {
            public static Dictionary<int, string> MyDic(int i)
            {
                Dictionary<int, string> dic = new Dictionary<int, string>();
                Console.WriteLine("Введите значение \n");
                string s;
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("ID:{0} --> ", j);
                    s = Console.ReadLine();
                    dic.Add(j, s);
                    Console.Clear();
                }
                return dic;
            }
        }
        static void Main()
        {
            Console.Write("Сколько значений добавить? ");
            int i = int.Parse(Console.ReadLine());
            Dictionary<int, string> dic = Base.MyDic(i);
            ICollection<int> keys = dic.Keys;
            Print(dic, keys);
            int a = 0;
            while (a != 2)
            {
                Console.WriteLine("Что сделать?");
                Console.WriteLine("1) Найти по ключу");
                Console.WriteLine("2) Удалить по ключу");
                Console.WriteLine("3) Добавить элемент");
                Console.WriteLine("4) Выход");
                Console.Write("Ваш выбор? ");
                char x = (char)Console.Read();
                Console.ReadLine();
                switch (x)
                {
                    case '1': find(dic, keys); break;
                    case '2': Delete(dic, keys); break;
                    case '3': Add(dic, keys); break;
                    case '4': a = 2; break;
                }
            }
        }
        static void Print(Dictionary<int, string> dic, ICollection<int> keys)
        {
            Console.WriteLine("База данных содержит: ");
            foreach (int j in keys)
                Console.WriteLine("ID:{0} Значение -> {1}", j, dic[j]);
        }
        static void Delete(Dictionary<int, string> dic, ICollection<int> keys)
        {
            Console.Clear();
            Console.WriteLine("Какой элемент удалить?");
            int z = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            dic.Remove(key: z);
            Print(dic, keys);
        }
        static void Add(Dictionary<int, string> dic, ICollection<int> keys)
        {
            Console.Clear();
            Console.Write("Введите значение: ");
            int g = 1;
            int h = 1;
            while (dic.ContainsKey(g++) == true)
                h++;
            string z = Console.ReadLine();
            dic.Add(h, z);
            Print(dic, keys);
        }
        static void find(Dictionary<int, string> dic, ICollection<int> keys)
        {
            Console.Clear();
            Console.Write("Введите ключ: ");
            int z = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("ID:{0} Значение -> {1}", z, dic[z]);
            Print(dic, keys);
        }
    }
}
