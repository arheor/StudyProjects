using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Ghost
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Открываем файл test.txt и выводим строки без двузначных чисел");
            StreamReader reader = new StreamReader("C:\\test.txt");
            Regex regex = new Regex(@"\b[+-]?\d{2}\b");
            string s = null;
            while (false == reader.EndOfStream)
            {
                s = reader.ReadLine();
                if (true != regex.IsMatch(s))
                {
                    Console.WriteLine(s);
                }
            }
            Console.ReadKey();
        }
    }
}