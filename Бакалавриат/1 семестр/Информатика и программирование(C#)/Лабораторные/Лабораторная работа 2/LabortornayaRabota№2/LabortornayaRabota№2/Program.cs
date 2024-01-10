using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace LaboratornayaRabota_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите значение АЛЬФА = ");
            string alfa = Console.ReadLine();
            double ALFA = double.Parse(alfa);
            double y = (1 + 2 * Math.Sin(2 * ALFA)) / (1 - Math.Pow(Math.Sin(ALFA), 2));
            double z = (1 - (1 / Math.Tan(ALFA))) / (1 + (1 / Math.Tan(ALFA)));
            Console.WriteLine("y = " + y);
            Console.WriteLine("z = " + z);
            Console.ReadKey();
        }
    }
}
