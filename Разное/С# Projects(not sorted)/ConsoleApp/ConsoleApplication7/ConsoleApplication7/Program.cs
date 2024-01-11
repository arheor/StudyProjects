using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication7
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1;
            while (a != 2)
            {
                Console.WriteLine("Выберите метод:");
                Console.WriteLine("1) Матричный метод");
                Console.WriteLine("2) Метод Крамера");
                Console.WriteLine("3) Метод Гаусса");
                Console.WriteLine("4) Выход");
                Console.Write("Ваш выбор? ");
                char x = (char)Console.Read();
                Console.ReadLine();
                switch (x)
                {
                    case '1': matrix(); break;
                    case '2': kramer(); break;
                    case '3': gauss(); break;
                    case '4': a = 2; break;
                }
            }
        }
        static void matrix()//матричный метод
        {
            int n;
            Console.Write("Введите размерность матрицы: ");
            n = Convert.ToInt32(Console.ReadLine());
            double[] b = new double[n]; // вектор правых частей
            double[] x = new double[n]; // вектор решения
            double[,] matrix = new double[n, n];// основная матрица
            for (int i = 0; i < n; i++)// заполняем матрицу
                for (int j = 0; j < n; j++)
                {
                    Console.Write("A[{0},{1}] = ", i, j);
                    matrix[i, j] = Convert.ToDouble(Console.ReadLine());
                } 
            double[,] An = new double[n, n];
            for (int i = 0; i < n; i++)//клонируем ее
                for (int j = 0; j < n; j++)
                    An[i, j] = matrix[i, j];
            double[,] Ak = new double[n, n];
            Console.WriteLine("Введите вектор правой части:");
            for (int i = 0; i < n; i++) //заполняем вектор правой части
            {
                Console.Write("b[{0}] = ", i);
                b[i] = Convert.ToDouble(Console.ReadLine());
            }
            Console.WriteLine("Исходная система уравнений: ");
            printMatrix(matrix, n, b); // распечатываем матрицу;
            Console.WriteLine();
            double det = Determinant(An, n); // вычисляем определитель матрицы;
            Console.WriteLine("Определитель равен = {0}", det);
            Console.WriteLine();
            T(n,An,matrix);
            if (det == 0)
                Console.WriteLine("Матрица вырождена");
            else
            {
                for (int i = 0; i < n; i++)//создаем матрицу миноров
                    for (int j = 0; j < n; j++)
                    {
                        double A = Determinant(GetMinor(An, i, j, n), n - 1);
                        Ak[i, j] = Math.Pow(-1, i + j) * A;
                        Ak[i, j] = Ak[i, j] / det;
                    }
                for (int i = 0; i < n; i++)//находим вектор решения
                    for (int a = 0; a < n; a++)
                    {
                        x[i] = x[i] + Ak[i, a] * b[a];
                    }
                Console.WriteLine();
                for (int i = 0; i < n; i++)//выводим вектор решения на экран
                {
                    x[i] = Convert.ToInt32(x[i]);
                    Console.WriteLine("X[{0}]= {1}", i + 1, x[i]);
                }
            }
            Console.WriteLine();
            }
        static void kramer()//метод крамера
        {
            int n;
            Console.Write("Введите размерность матрицы: ");
            n = Convert.ToInt32(Console.ReadLine());
            double[] b = new double[n]; // вектор правых частей 
            double[] x = new double[n]; // вектор решения
            double[,] matrix = new double[n, n];// основная матрица
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    Console.Write("A[{0},{1}] = ", i, j);
                    matrix[i, j] = Convert.ToDouble(Console.ReadLine());
                } // заполняем матрицу
            double[,] An = new double[n, n];// клонируем основную матрицу
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    An[i, j] = matrix[i, j];
            Console.WriteLine("Введите вектор правой части:");
            for (int i = 0; i < n; i++) //заполняем вектор правой части
            {
                Console.Write("b[{0}] = ", i);
                b[i] = Convert.ToDouble(Console.ReadLine());
            }
            Console.WriteLine("Исходная система уравнений: ");
            printMatrix(matrix, n, b); // распечатываем матрицу;
            Console.WriteLine();
            double det = Determinant(An, n); // вычисляем определитель матрицы;
            Console.WriteLine("Определитель равен = {0}", det);
            Console.WriteLine();
            if (SLAU_kramer(n, matrix, b, x, An) == 1)
            {
                Console.WriteLine("Система не имеет решения");
                return;
            }
            else
                for (int i = 0; i < n; i++)
                {
                    x[i] = Convert.ToInt32(x[i]);
                    Console.WriteLine("x[{0}] = {1}", i, x[i]);
                }
            Console.WriteLine();
        }
        static void gauss()//метод гаусса
        {
            //создание матрицы
            int n, k;
            double kof;
            Console.Write("Введите размерность матрицы: ");
            n = Convert.ToInt32(Console.ReadLine());
            double[,] a = new double[n, n];// основная матрица
            double[] x = new double[n];
            double[] b = new double[n];
            double[,] array = new double[n, n + 1];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    Console.Write("A[{0},{1}] = ", i, j);
                    a[i, j] = Convert.ToDouble(Console.ReadLine());
                } // заполняем матрицу
            Console.WriteLine("Введите вектор правой части:");
            for (int i = 0; i < n; i++)
            {
                Console.Write("b[{0}] = ", i);
                b[i] = Convert.ToDouble(Console.ReadLine());
            }
            Console.WriteLine();
            Console.WriteLine("Исходная система уравнений: ");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("{0:0}*X[{1}] ", a[i, j], j);
                }
                Console.Write("= ");
                Console.WriteLine("{0:0}", b[i]);
            }
            Console.WriteLine();
            for (k = 0; k < n - 1; k++)//приводим к треугольному виду
            {
                for (int i = k + 1; i < n; i++)
                {
                    kof = -1 * a[i, k] / a[k, k];
                    b[i] = b[i] + kof * b[k];
                    for (int j = k; j < n; j++)
                    {
                        a[i, j] = a[i, j] + a[k, j] * kof;
                    }
                }
            }
            Console.WriteLine("Матрица, приведенная к треугольному виду");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("{0:0}*X[{1}] ", a[i, j], j);
                }
                Console.Write("= ");
                Console.WriteLine("{0:0}", b[i]);
            }
            Console.WriteLine();
            //вычисление результата
            x[n - 1] = b[n - 1] / a[n - 1, n - 1];
            double sum = 0;
            for (int z = n - 2; z >= 0; --z)
            {
                sum = 0;
                for (int j = z + 1; j < n; j++)
                {
                    sum = sum + a[z, j] * x[j];
                    x[z] = (b[z] - sum) / a[z, z];
                }
            }
            Console.WriteLine("Решение: ");
            for (int i = 0; i < n; i++)
                Console.WriteLine("Х[{0}] = {1}", i + 1, Convert.ToInt32(x[i]));
            Console.WriteLine();
        }
        public static double[,] GetMinor(double[,] An, int a, int b, int n)//находим миноры
        {
            double[,] buf = new double[n-1,n-1];
            for (int j = 0, q = 0; q < n-1; j++, q++)
                for (int i = 0, p = 0; p < n-1; i++, p++)
                {
                    if (i == a) i++;
                    if (j == b) j++;
                    buf[p, q] = An[i, j];
                }
            return buf;
        }
        static void T(int n, double[,] An,double[,] matrix)//транспонируем матрицу
        {
            Console.WriteLine("Транспонированная матрица: ");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    An[i, j] = matrix[j, i];
                    Console.Write(An[i, j] + " \t ");
                }
                Console.WriteLine();
            }
        }
        

        //метод вычисления определителя матрицы;
        static private double Determinant(double[,] An, int n)
        {
            if (n == 1) // если матрица первого порядка, то ее определитель это единственный элемент этой матрицы;
                return An[0, 0]; // возвращаем его;
            if (Zero(An, n)) // если есть нулевой столбец, то определитель равен 0;
                return 0;
            int kol; // число перестановок строк;
            sort(An, n, out kol); // сортируем матрицу по первым элементам строк;
            for (int i = 1; i < n; ++i) // итерация методом Гаусса;
            {
                double index = An[i, 0] / An[0, 0];
                for (int j = 0; j < n; ++j)
                    An[i, j] -= index * An[0, j];
            } // где зануляется первый столбец с 1 по n - 1 строки;
            return An[0, 0] * Math.Pow(-1, kol) * Determinant(subMatrix(An, n), n - 1);
            // возвращаем определитель рекурсивно;
        }
        //метод для перестановки 2х линейных массивов; 
        static private void swapArray(double[,] An, int index, int lengthOfMatrix)
        {
            for (int i = 0; i < lengthOfMatrix; ++i)
                swapDouble(ref An[index, i], ref An[index + 1, i]);
        }
        //метод для перестановки 2х элементов;
        static private void swapDouble(ref double Buffer1, ref double Buffer2)
        {
            double Tmp = Buffer1;
            Buffer1 = Buffer2;
            Buffer2 = Tmp;
        }
        // сортировка матрицы по первым элементам строк
        static private void sort(double[,] An, int n, out int kol)
        {
            kol = new int();
            bool flagOfSwapping = true;
            int numberOfIteration = new int();
            while (flagOfSwapping) // цикл выполняется пока есть хотя бы одна перестановка в ходе итерации;
            {
                flagOfSwapping = false;
                for (int i = 0; i < n - 1 - numberOfIteration; ++i)
                    if (An[i, 0] < An[i + 1, 0])
                    {
                        swapArray(An, i, n);
                        flagOfSwapping = true;
                        ++kol;
                    }
                numberOfIteration++;
            }
        }
        //метод вывода матрицы на экран;
        static private void printMatrix(double[,] matrix, int n, double[] b)
        {
            Console.WriteLine();
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                    Console.Write("{0}*X[{1}] ", matrix[i, j],j);
                Console.WriteLine("= {0}", b[i]);
            }
        }
        //метод выделения подматрицы размером n - 1;
        static private double[,] subMatrix(double[,] matrix, int n)
        {
            double[,] subMatrix = new double[n - 1, n - 1];
            for (int i = 1; i < n; ++i) // выделяется подматрица со строк [1, n);
                for (int j = 1; j < n; ++j) // .. cтолбцов [1; n);
                    subMatrix[i - 1, j - 1] = matrix[i, j];
            return subMatrix;
        }
        //метод проверки первого столбца на равенство нулевому;
        static private bool Zero(double[,] matrix, int n)
        {
            for (int i = 0; i < n; ++i)
                if (matrix[i, 0] != 0)
                    return false;
            return true;
        }
        //метод вычисления методом крамера
        static int SLAU_kramer(int n, double[,] matrix, double[] b, double[] x, double[,] An)
        {
            double det1 = Determinant(An, n);
            if (det1 == 0) return 1;
            for (int i = 0; i < n; i++)
            {
                equal(n, An, matrix);
                change(n, i, An, b);
                x[i] = Determinant(An, n) / det1;
            }
            return 0;
        }
        //клонирование матрицы
        static void equal(int n, double[,] An, double[,] B)
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    An[i, j] = B[i, j];
        }
        //метод замены столбца вектором правой части
        static void change(int n, int N, double[,] An, double[] b)
        {
            for (int i = 0; i < n; i++)
                An[i, N] = b[i];
        }

    }
}
