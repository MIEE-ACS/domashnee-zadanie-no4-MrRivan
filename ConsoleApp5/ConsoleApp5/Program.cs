using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ConsoleApp5
{

    class Program
    {
        public enum Call_outs
        {
            n,
            A,
            B
        }

        static void task1()
        {
            Console.WriteLine("Задание 1");
            Random random = new Random();
            int n;
            do
            {
                n = Try_read_int(Call_outs.n);
            } while (n <= 0);
            double[] Array = new double[n];
            int Max_Number = 0;
            double Max_Number_checker = 0.0;
            double sum = 0;
            bool beacon = false;
            Console.WriteLine("Рандомный массив размера n");
            for (int i = 0; i < n; i++)
            {
                Array[i] = Math.Round(random.NextDouble() * 10 - 5, 3);
                Console.Write($"{Array[i]}\t");
                if (Array[i] > 0)
                {
                    beacon = true;
                }
                if (beacon)
                {
                    sum += Array[i];
                }
                if (Math.Abs(Array[i]).CompareTo(Math.Abs(Max_Number_checker)) > 0)
                {
                    Max_Number_checker = Array[i];
                    Max_Number = i;
                }

            }
            Console.WriteLine("\n Номер максимального элемента");
            Console.WriteLine(Max_Number + 1);
            Console.WriteLine("Сумма членов после первого положительного числа");
            Console.WriteLine(Math.Round(sum, 2));
            double A;
            double B;
            do
            {
                A = Try_read_double(Call_outs.A);
            } while (A.CompareTo(Array.Max()) >= 0);
            do
            {
                B = Try_read_double(Call_outs.B);
            } while (B.CompareTo(Array.Min()) <= 0 || A > B);
            double[] New_Array = new double[n];
            int j = 0;
            for (int i = 0; i < n; i++)
            {
                if (Array[i].CompareTo(A) >= 0 && Array[i].CompareTo(B) <= 0)
                {
                    New_Array[j] = Array[i];
                    j++;
                }
            }
            for (int i = 0; i < n; i++)
            {
                if (Array[i].CompareTo(A) < 0 || Array[i].CompareTo(B) > 0)
                {
                    New_Array[j] = Array[i];
                    j++;
                }
                Console.WriteLine(New_Array[i]);
            }
        }

        static void task2()
        {
            Console.WriteLine("Задание 2");
            int n = 3;
            double[,] a = { { 1, 2, 3 }, { 2, 3, 4 }, { 3, 4, 5 } };
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{a[i, j]}\t");
                }
                Console.WriteLine("");
            }

            for (int k = 0; k < n - 1; k++)
            {
                for (int i = k + 1; i < n; i++)
                {
                    for (int j = k; j < n; j++)
                    {
                        a[i, j] = a[i, j] - a[k, j] * (a[i, k] / a[k, k]);
                    }
                }
            }
            Console.WriteLine("Полученное значение");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{a[i, j]}\t");
                }
                Console.WriteLine("");
            }
            bool beacon;
            Console.Write("Кол-во строк, в которых среднее арифметическое элементов <  ");
            int number = 0;
            do
            {
                string input = Console.ReadLine().Replace(',', '.');
                beacon = int.TryParse(input, out number);
                if (beacon == false)
                {
                    input = input.Replace('.', ',');
                    beacon = int.TryParse(input, out number);
                    if (beacon == false)
                    {
                        Console.WriteLine("Обнаружен некорректный ввод! Пожалуйста, повторите ввод.\n");
                    }
                }

            } while (beacon == false);
            bool check=false;
            for (int i = 0; i < 3; i++)
            {
                double sum = 0;
                for (int j = 0; j < 3; j++)
                {
                    sum += a[i, j];
                }
                if ((sum/3).CompareTo(number) < 0)
                {
                    check = true;
                    Console.WriteLine($"Строка {i} сред.арифмет. меньше заданного числа");
                }
            }
            if(!check)
            {
                Console.WriteLine($"нет сторк, среднее арифметическое которых меньше {number}");
            }
        }

        static int Try_read_int(Call_outs call)
        {
            int number = 0;
            bool beacon;
            switch (call)
            {
                case Call_outs.n:
                    {
                        Console.Write("Введите n больше 0. n = ");
                        do
                        {
                            string input = Console.ReadLine().Replace(',', '.');
                            beacon = int.TryParse(input, out number);
                            if (beacon == false)
                            {
                                input = input.Replace('.', ',');
                                beacon = int.TryParse(input, out number);
                                if (beacon == false)
                                {
                                    Console.WriteLine("Обнаружен некорректный ввод! Пожалуйста, повторите ввод.\n");
                                }
                            }

                        } while (beacon == false);
                        break;
                    }
            }
            return number;
        }
        static double Try_read_double(Call_outs call)
        {
            double number = 0;
            bool beacon;
            switch (call)
            {
                case Call_outs.n:
                    {
                        Console.Write("Введите  n большее 0. n = ");
                        do
                        {
                            string input = Console.ReadLine().Replace(',', '.');
                            beacon = double.TryParse(input, out number);
                            if (beacon == false)
                            {
                                input = input.Replace('.', ',');
                                beacon = double.TryParse(input, out number);
                                if (beacon == false)
                                {
                                    Console.WriteLine("Обнаружен некорректный ввод! Пожалуйста, повторите ввод.\n");
                                }
                            }

                        } while (beacon == false);
                        break;
                    }

                case Call_outs.A:
                    {
                        Console.Write("Введите A меньше  B и  меньше максимального эелмента массива.\n A =");
                        do
                        {
                            string input = Console.ReadLine().Replace(',', '.');
                            beacon = double.TryParse(input, out number);
                            if (beacon == false)
                            {
                                input = input.Replace('.', ',');
                                beacon = double.TryParse(input, out number);
                                if (beacon == false)
                                {
                                    Console.WriteLine("Обнаружен некорректный ввод! Пожалуйста, повторите ввод.\n");
                                }
                            }

                        } while (beacon == false);
                        break;
                    }
                case Call_outs.B:
                    {
                        Console.Write("Введите B больше A \t B = ");
                        do
                        {
                            string input = Console.ReadLine().Replace(',', '.');
                            beacon = double.TryParse(input, out number);
                            if (beacon == false)
                            {
                                input = input.Replace('.', ',');
                                beacon = double.TryParse(input, out number);
                                if (beacon == false)
                                {
                                    Console.WriteLine("Обнаружен некорректный ввод! Пожалуйста, повторите ввод.\n");
                                }
                            }
                        } while (beacon == false);
                        break;
                    }
            }
            return number;
        }



        static void Main(string[] args)
        {
            task1();
            task2();
        }
    }
}
