using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MS
{
    class Program
    {
        public struct Dictionary
        {
            public string key;
            public List<string> value;
        }

        static void Main(string[] args)
        {
            Console.Title = "‘ловарь";
            Console.WriteLine();
            Console.Write("‚ведите размерность словарЯ: ");
            Dictionary[] s = new Dictionary[Convert.ToInt32(Console.ReadLine())];
            input(s, true);
            while (true)
            {
                Console.WriteLine("1.\t€скать по ключу.");
                Console.WriteLine("2.\t€скать по значению.");
                Console.WriteLine("3.\t“далить по ключу.");
                Console.WriteLine("4.\t“далить по значению.");
                Console.WriteLine("5.\t‘ловарь.");
                Console.WriteLine("6.\t„обавить ключ и значение.");
                Console.WriteLine("c\tClear Console");
                Console.WriteLine("q\t‚ыход.");
                switch (Console.ReadLine().ToLower())
                {
                    case "1":
                        findKey(s);
                        break;
                    case "2":
                        findValue(s);
                        break;
                    case "3":
                        deleteK(s);
                        break;
                    case "4":
                        deleteV(s);
                        break;
                    case "5":
                        print(s);
                        break;
                    case "6":
                        input(s, false);
                        break;
                    case "c":
                        Console.Clear();
                        break;
                    case "q":
                        return;
                }
            }
        }

        private static void input(Dictionary[] s, Boolean first)
        {

            for (int i = 0; i < s.Length; i++)
            {
                if (first) s[i].value = new List<string>();
                Console.Write("‚ведите ключ: ");
                string key = Convert.ToString(Console.ReadLine());
                Console.Write("‚ведите значение: ");
                string value = Convert.ToString(Console.ReadLine());

                if (!containsK(key, s) && find(key, s) == -1 && haveEmpty(s))
                {
                    s[i].key = key;
                    s[i].value.Add(value);
                }
                else
                {
                    if (find(key, s) != -1)
                    {
                        s[find(key, s)].value.Add(value);
                    }
                }
                Console.WriteLine();
            }

            for (int i = 0; i < s.Length; i++)
            {
                s[i].value.Sort();
            }
        }

        private static bool haveEmpty(Dictionary[] s)
        {
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].key == null) count++;
            }
            if (count < s.Length) return true;
            else return false;
        }
        private static void findValue(Dictionary[] s)
        {
            Console.Title = "Џоиск по значению";
            Console.WriteLine("=======================================");
            Console.WriteLine();
            Console.Write("Ѓудем искать значение: ");
            string value = Convert.ToString(Console.ReadLine());
            if (containsV(value, s))
            {
                printV(s, value);
            }
            else Console.WriteLine("Ќе найдено: " + value);
        }

        private static void printV(Dictionary[] s, string value)
        {
            Console.WriteLine();
            for (int i = 0; i < s.Length; i++)
            {
                s[i].value = s[i].value.Distinct().ToList();
                if (s[i].value.Count != 0 && s[i].value.Contains(value) && value != null)
                {
                    Console.WriteLine();
                    Console.WriteLine(s[i].key + " --------------------------");
                    Console.WriteLine("\t|");
                    s[i].value.ForEach(delegate(String name)
                    {
                        Console.WriteLine("\t" + name);
                    });
                    Console.WriteLine();
                }
            }
        }

        private static void findKey(Dictionary[] s)
        {
            Console.Title = "Џоиск по ключу";
            Console.WriteLine("=======================================");
            Console.WriteLine();
            Console.Write("Ѓудем искать ключ: ");
            string key = Convert.ToString(Console.ReadLine());
            if (containsK(key, s))
            {
                printK(s, key);
            }
            else Console.WriteLine("Ќе найдено: " + key);
        }

        private static void printK(Dictionary[] s, string key)
        {
            Console.WriteLine("=======================================");
            for (int i = 0; i < s.Length; i++)
            {
                s[i].value = s[i].value.Distinct().ToList();
                if (s[i].value.Count != 0 && key == s[i].key && key != null)
                {
                    Console.WriteLine();
                    Console.WriteLine(s[i].key + " --------------------------");
                    Console.WriteLine();
                }
            }
        }
        private static void pr(Dictionary[] s, int i)
        {
            Console.WriteLine();
            Console.WriteLine(s[i].key + " --------------------------");
            Console.WriteLine("\t|");
            s[i].value.ForEach(delegate(String name)
            {
                Console.WriteLine("\t" + name);
            });
            Console.WriteLine();
        }
        private static void deleteK(Dictionary[] s)
        {
            Console.Title = "“даление по ключу";
            Console.WriteLine("=======================================");
            Console.Write("Ѓудем удалЯть ключ: ");
            string key = Convert.ToString(Console.ReadLine());
            if (containsK(key, s))
            {
                int i = find(key, s);
                s[i].key = null;
                s[i].value.Clear();
            }
            print(s);
        }
        private static void deleteV(Dictionary[] s)
        {
            Console.Title = "“даление по по значению";
            Console.WriteLine("=======================================");
            Console.Write("Ѓудем удалЯть значение: ");
            string p = Convert.ToString(Console.ReadLine());
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].value.Contains(p)) s[i].value.Remove(p);
            }
            print(s);
        }
        private static void print(Dictionary[] s)
        {
            Console.WriteLine("=======================================");
            for (int i = 0; i < s.Length; i++)
            {
                s[i].value = s[i].value.Distinct().ToList();
                if (s[i].value.Count != 0 && s[i].key != null && s[i].value != null)
                {
                    pr(s, i);
                }
            }
        }
        private static int find(string key, Dictionary[] s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].key == key) return i;
            }
            return -1;
        }
        private static bool containsK(string key, Dictionary[] s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].key == key) return true;
            }
            return false;
        }
        private static bool containsV(string value, Dictionary[] s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].value.Contains(value)) return true;
            }
            return false;
        }
    }
}
