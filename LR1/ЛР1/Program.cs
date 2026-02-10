using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using ЛР1;
using Vector = ЛР1.Vector;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа №1\nВыполнила Гусева Мария, студентка группы 6101-020302D");

            while (true)
            {
                Console.WriteLine("Выберите пункт:\n0 - Выход\n1 - Задание первое: Описать класс с именем “ArrayVector”\n" +
                    "2 - Задание второе: Добавить класс с именем «Vectors», содержащий публичные статические методы");
                string menu = Console.ReadLine();
                switch (menu)
                {
                    case "0":
                        return;
                    case "1":
                        Task1();
                        Console.WriteLine();
                        Console.WriteLine("Для возвращения в главное меню нажмите Enter");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "2qqq":
                        Task2();
                        Console.WriteLine();
                        Console.WriteLine("Для возвращения в главное меню нажмите Enter");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Ошибка! Введите существующий пункт.");
                        Console.WriteLine();
                        Console.WriteLine("Для возвращения в главное меню нажмите Enter");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }

        }
        public static void Task1()
        {
            Console.Write("Введите размерность вектора: ");
            int user_lenght;
            bool check = int.TryParse(Console.ReadLine(), out user_lenght);
            ArrayVector vector;
            if ((check) && (user_lenght >= 0))
            {
                Console.WriteLine("\nВектор выбранной размерности успешно создан.");
                vector = new ArrayVector(user_lenght);
            }
            else
            {
                Console.WriteLine("\nНеверно введены данные! Создан вектор с размерность, равной \"5\"");
                vector = new ArrayVector();
            }
            Console.WriteLine("Введите значения вектора через пробел:");
            string? user_vector = Console.ReadLine();
            double[]? sup_vector;
            try
            {
                sup_vector = user_vector?.Split(' ').Select(double.Parse).ToArray();
                if (sup_vector.Length == vector.Lenght)
                {
                    for (int i = 0; i < vector.Lenght; i++)
                    {
                        vector.SetElement(i, sup_vector[i]);
                    }
                    Console.WriteLine("Значения успешно установлены.");
                }
                else
                {
                    Console.WriteLine("Размерность вектора и количество введенных чисел не совпадает. Значения не изменены.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Введенные данные некорректны.");
            }
            while (true)
            {
                Console.WriteLine("Выберете пункт меню:\n" +
                    "0 - Выход\n1 - Вывести элемент с выбранным индексом на экран\n" +
                    "2 - Заменить элемент по выбранному индексу\n3 - Вычислить модуль вектора\n" +
                    "4 - Вывести количество координат вектора на экран\n5 - Вывести координаты вектора на экран\n" +
                    "6 - метод подсчета суммы всех положительных элементов массива с четными номерами\n" +
                    "7 - метод подсчета суммы тех элементов массива, которые имеют нечетные номера и одновременно меньше " +
                    "среднего значения всех модулей элементов массива\n8 - метод подсчета произведения всех четных положительных элементов " +
                    "(по значению)\n9 - метод подсчета произведения всех нечетных элементов (по значению), не делящихся на три\n" +
                    "10 - метод сортировки массива по возрастанию\n11 - метод сортировки массива по убыванию");
                string? menu = Console.ReadLine();
                switch (menu)
                {
                    case "0":
                        return;
                    case "1":
                        try
                        {
                            Console.WriteLine("Введите индекс:");
                            int id = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine($"Элемент под индексом {id} равен: {vector.GetElement(id)}");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Элемента с данным индексом не существует.");
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("Элемента с данным индексом не существует.");
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("Элемента с данным индексом не существует.");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Нажмите Enter, чтобы продолжить.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "2":
                        try
                        {
                            Console.WriteLine("Введите индекс:");
                            int id = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Введите новое значение:");
                            double new_value = Convert.ToDouble(Console.ReadLine());
                            vector.SetElement(id, new_value);
                            Console.WriteLine("Элемент успешно изменен.");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Введенные данные некорректны.");
                        }
                        catch (IndexOutOfRangeException e)
                        {
                            Console.WriteLine("Такого индекса не существует");
                        }

                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Нажмите Enter, чтобы продолжить.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "3":
                        try
                        {
                            Console.WriteLine("Модуль вектора равен: " + vector.GetNorm());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Возникло следующее исключение: {e.Message}");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Нажмите Enter, чтобы продолжить.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "4":
                        try
                        {
                            Console.WriteLine("Число координат вектора равен: " + vector.Lenght);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Возникло следующее исключение: {e.Message}");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Нажмите Enter, чтобы продолжить.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "5":
                        try
                        {
                            Console.Write("Вектор:");
                            for (int i = 0; i < vector.Lenght; i++)
                            {
                                Console.Write(vector.GetElement(i) + " ");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Возникло исключение: {e.Message}");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Нажмите Enter, чтобы продолжить.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "6":
                
                        vector.SumPositivesFromChetIndex();
                        Console.WriteLine();
                        Console.WriteLine("Нажмите Enter, чтобы продолжить.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "7":                        
                        vector.SumLessFromNechetIndex();
                        Console.WriteLine();
                        Console.WriteLine("Нажмите Enter, чтобы продолжить.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "8":                       
                        vector.MultChet();
                        Console.WriteLine();
                        Console.WriteLine("Нажмите Enter, чтобы продолжить.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "9":                       
                        vector.MultNechet();
                        Console.WriteLine();
                        Console.WriteLine("Нажмите Enter, чтобы продолжить.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "10":
                        Console.WriteLine("Отсортированный по позрастанию массив:");
                        vector.SortUp();
                        Console.WriteLine();
                        Console.WriteLine("Нажмите Enter, чтобы продолжить.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "11":
                        Console.WriteLine("Отсортированный по убыванию массив:");
                        vector.SortDown();
                        Console.WriteLine();
                        Console.WriteLine("Нажмите Enter, чтобы продолжить.");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    default:
                        Console.WriteLine("Ошибка! Пожалуйста, введите существующий пункт меню.");
                        Console.WriteLine();
                        Console.WriteLine("Нажмите Enter, чтобы продолжить.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }



            }
        }


        public static void Task2()
        {
            Console.Write("Введите размерность первого вектора: ");
            int user_lenght_1;
            bool check_1 = int.TryParse(Console.ReadLine(), out user_lenght_1);
            ArrayVector vector_1;
            if ((check_1) && (user_lenght_1 >= 0))
            {
                Console.WriteLine("\nВектор выбранной размерности успешно создан.");
                vector_1 = new ArrayVector(user_lenght_1);
            }
            else
            {
                Console.WriteLine("\nНеверно введены данные! Создан вектор с размерность, равной \"5\"");
                vector_1 = new ArrayVector();
            }
            Console.WriteLine("Введите значения вектора через пробел:");
            string? user_vector_1 = Console.ReadLine();
            double[]? sup_vector_1;
            try
            {
                sup_vector_1 = user_vector_1?.Split(' ').Select(double.Parse).ToArray();
                if (sup_vector_1.Length == vector_1.Lenght)
                {
                    for (int i = 0; i < vector_1.Lenght; i++)
                    {
                        vector_1.SetElement(i, sup_vector_1[i]);
                    }
                    Console.WriteLine("Значения успешно установлены.");
                }
                else
                {
                    Console.WriteLine("Размерность вектора и количество введенных чисел не совпадает. Значения не изменены.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Введенные данные некорректны.");
            }

            Console.Write("Введите размерность второго вектора: ");
            int user_lenght_2;
            bool check_2 = int.TryParse(Console.ReadLine(), out user_lenght_2);
            ArrayVector vector_2;
            if ((check_2) && (user_lenght_2 >= 0))
            {
                Console.WriteLine("\nВектор выбранной размерности успешно создан.");
                vector_2 = new ArrayVector(user_lenght_2);
            }
            else
            {
                Console.WriteLine("\nНеверно введены данные! Создан вектор с размерность, равной \"5\"");
                vector_2 = new ArrayVector();
            }
            Console.WriteLine("Введите значения вектора через пробел:");
            string? user_vector_2 = Console.ReadLine();
            double[]? sup_vector_2;
            try
            {
                sup_vector_2 = user_vector_2?.Split(' ').Select(double.Parse).ToArray();
                if (sup_vector_2.Length == vector_2.Lenght)
                {
                    for (int i = 0; i < vector_2.Lenght; i++)
                    {
                        vector_2.SetElement(i, sup_vector_2[i]);
                    }
                    Console.WriteLine("Значения успешно установлены.");
                }
                else
                {
                    Console.WriteLine("Размерность вектора и количество введенных чисел не совпадает. Значения не изменены.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Введенные данные некорректны.");
            }
            Console.WriteLine();
            Console.WriteLine();
            while (true)
            {
                Console.WriteLine("Выберете пункт меню:\n0 - Выход\n1 - Сумма векторов\n2 - Скалярное произведение векторов\n" +
                    "3 - Вычисление модуля веторов\n4 - статический метод умножения вектора на число\n" +
                    "");
                string menu = Console.ReadLine();
                switch (menu)
                {
                    case "0":
                        return;
                    case "1":
                        try
                        {
                            ArrayVector? vector3 = Vector.Sum(vector_1, vector_2);
                            Console.WriteLine("Сумма векторов равна:");
                            Vector.OutputVector(vector3, vector3.Lenght);
                        }

                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Нажмите Enter, чтобы продолжить.");
                        Console.ReadKey();
                        Console.Clear();
                        break;                        
                        
                    case "2":
                        try
                        {
                            double? mult = Vector.Scalar(vector_1, vector_2);
                            Console.WriteLine("Скалярное произведение = " + mult);
                        }

                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Нажмите Enter, чтобы продолжить.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "3":
                        double norm_1 = Vector.GetNorm(vector_1);
                        Console.WriteLine("Модуль(длина) первого вектора: " + norm_1);
                        double norm_2 = Vector.GetNorm(vector_2);
                        Console.WriteLine("Модуль(длина) второго вектора: " + norm_2);
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Нажмите Enter, чтобы продолжить.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "4":
                        int ch;
                        try
                        {
                            Console.WriteLine("Введите число:");
                            ch = int.Parse(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Некорректные данные. Множителю присвоено значение \"1\"");
                            ch = 1;
                        }
                        vector_1 = Vector.NumberMult(vector_1, ch);
                        Console.WriteLine("Результат умножения на число первого вектора");
                        for (int i = 0; i < vector_1.Lenght; i++)
                        {
                            Console.Write(vector_1.GetElement(i) + " ");
                        }
                        Console.WriteLine();
                        vector_2 = Vector.NumberMult(vector_2, ch);
                        Console.WriteLine("Результат умножения на число второго вектора");
                        for (int i = 0; i < vector_2.Lenght; i++)
                        {
                            Console.Write(vector_2.GetElement(i) + " ");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Нажмите Enter, чтобы продолжить.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Ошибка! Пожалуйста, введите существующий пункт меню.");
                        Console.WriteLine();
                        Console.WriteLine("Нажмите Enter, чтобы продолжить.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
    }
}