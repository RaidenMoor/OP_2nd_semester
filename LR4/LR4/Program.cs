using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Reflection.Metadata;
using LR4;

namespace LR4
{
    class Program
    {
        static void Main(string?[] args)
        {
            Console.WriteLine("Лабораторная работа №4 \nВыполнила Гусева Мария студентка группы 6101-020302D");
            while (true)
            {
                Console.WriteLine("Введите пункт меню:\n0 - Выход\n1 - Класс ArrayVector\n2 - Класс LinkedListVector\n3 - Класс Vectors");
                string? menu = Console.ReadLine();
                switch (menu)
                {
                    case "0":
                        return;
                    case "1":
                        Task1();
                        Console.WriteLine("Нажмите Enter, чтобы продолжить.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "2":
                        Task2();
                        Console.WriteLine("Нажмите Enter, чтобы продолжить.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "3":
                        Task3();
                        Console.WriteLine("Нажмите Enter, чтобы продолжить.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Ошибка! Пожалуйста, введите существующий пункт меню.\nНажмите Enter, чтобы продолжить.\n\n");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                }
            }
        }
        static void Task1()
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
                if (sup_vector.Length == vector.Length)
                {
                    for (int i = 0; i < vector.Length; i++)
                    {
                        vector[i] = sup_vector[i];
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
                    "4 - Вывести размерность и координаты вектора на экран");
                string? menu = Console.ReadLine();
                switch (menu)
                {
                    case "0":
                        return;
                    case "1":
                        try
                        {
                            Console.WriteLine("Введите индекс:");
                            int id = Int_Input();
                            Console.WriteLine($"Элемент под индексом {id} равен: {vector[0]}");
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
                            int id = Int_Input();

                            Console.WriteLine("Введите новое значение:");
                            double new_value = Convert.ToDouble(Console.ReadLine());
                            vector[id] = new_value;
                            Console.WriteLine("Элемент успешно изменен.");
                        }
                        catch (IndexOutOfRangeException e)
                        {
                            Console.WriteLine("Произошла ошибка при вводе данных!");
                        }

                        catch (Exception e)
                        {
                            Console.WriteLine("Произошла ошибка при вводе данных!");
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
                            Console.WriteLine (vector.ToString());
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
        static void Task2()
        {
            Console.Write("Введите размерность вектора: ");
            int user_lenght;
            bool check = int.TryParse(Console.ReadLine(), out user_lenght);
            LinkedListVector vector;
            if ((check) && (user_lenght >= 0))
            {
                Console.WriteLine("\nВектор выбранной размерности успешно создан.");
                vector = new LinkedListVector(user_lenght);
            }
            else
            {
                Console.WriteLine("\nНеверно введены данные! Создан вектор с размерность, равной \"5\"");
                vector = new LinkedListVector();
            }
            Console.WriteLine("Введите значения вектора через пробел:");
            string? user_vector = Console.ReadLine();
            double[]? sup_vector;
            try
            {
                sup_vector = user_vector?.Split(' ').Select(double.Parse).ToArray();
                if (sup_vector.Length == vector.Length)
                {
                    for (int i = 0; i < vector.Length; i++)
                    {
                        vector[i] = sup_vector[i];
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
            catch (NullReferenceException)
            {
                Console.WriteLine("Размерность данного вектора равна нулю." +
                    " Вы не можете ввести элементы в пустой вектор, но можете добавить новые элементы, выбрав необходимый пункт меню.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ой! Возникло исключение: {e.Message}");
            }


            while (true)
            {
                Console.WriteLine("Выберете пункт меню:\n0 - Выход\n1 - Добавление нового элемента в начало списка\n" +
                    "2 - Добавление нового элемента в конец конец\n3 - Добавление нового элемента в список по выбранному индексу" +
                    "\n4 - Удаление элемента с конца списка\n5 - Удаление элемента из начала списка\n" +
                    "6 - Удаление элемента из списка по выбранному индексу\n7 - Вывести размерность и координаты вектора на экран" +
                    "\n8 - Вычислить модуль вектора\n9 - Изменить элемент по выбранному индексу\n");
                string? menu = Console.ReadLine();
                switch (menu)
                {
                    case "0":
                        return;
                    case "1":
                        vector.AddToStart();
                        Console.WriteLine("Введите значение нового элемента:");
                        try
                        {
                            double new_element = Convert.ToDouble(Console.ReadLine());
                            vector[0] = new_element;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Неверные входные данные. Значение не было изменено");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Неверные входные данные. Значение не было изменено");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Нажмите Enter, чтобы продолжить.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "2":
                        vector.AddToTheEnd();
                        Console.WriteLine("Введите значение нового элемента:");
                        try
                        {
                            double new_element = Convert.ToDouble(Console.ReadLine());
                            vector[vector.Length - 1] = new_element;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Неверные входные данные. Значение не было изменено");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Неверные входные данные. Значение не было изменено" + e.Message);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Нажмите Enter, чтобы продолжить.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "3":
                        Console.WriteLine("Введите индекс:");
                        try
                        {
                            int user_index = int.Parse(Console.ReadLine());
                            vector.AddElement(user_index);
                            Console.WriteLine("Элемент успешно добавлен. Введите значение нового элемента:");
                            try
                            {
                                double new_element = Convert.ToDouble(Console.ReadLine());
                                vector[user_index] = new_element;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Неверные входные данные. Значение не было изменено");
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Неверные входные данные. Значение не было изменено" + e.Message);
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Элемента с таким индексом не существует.");
                        }
                        catch (NullReferenceException)
                        {
                            Console.WriteLine("Элемента с таким индексом не существует.");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Элемента с таким индексом не существует.");
                        }

                        Console.WriteLine();
                        Console.WriteLine("Нажмите Enter, чтобы продолжить.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "4":
                        try
                        {
                            vector.DeleteFromEnd();
                            Console.WriteLine("Элемент успешно удален.");
                        }
                        catch (NullReferenceException)
                        {
                            Console.WriteLine("Список пуст. Добавьте элементы, чтобы их удалить.");
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("Список пуст. Добавьте элементы, чтобы их удалить.");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Воу, неожиданное исключение: {e.Message}");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Нажмите Enter, чтобы продолжить.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "5":
                        try
                        {
                            vector.DeleteFromStart();
                            Console.WriteLine("Элемент успешно удален.");
                        }
                        catch (NullReferenceException)
                        {
                            Console.WriteLine("Список пуст. Добавьте элементы, чтобы их удалить.");
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("Список пуст. Добавьте элементы, чтобы их удалить.");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Воу, неожиданное исключение: {e.Message}");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Нажмите Enter, чтобы продолжить.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "6":
                        Console.WriteLine("Введите индекс:");
                        try
                        {
                            int user_index = int.Parse(Console.ReadLine());
                            vector.DeleteElement(user_index);
                            Console.WriteLine("Элемент успешно удален.");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Элемента с таким индексом не существует.");
                        }
                        catch (NullReferenceException)
                        {
                            Console.WriteLine("Элемента с таким индексом не существует.");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Элемента с таким индексом не существует.");
                        }

                        Console.WriteLine();
                        Console.WriteLine("Нажмите Enter, чтобы продолжить.");
                        Console.ReadKey();
                        Console.Clear();

                        break;
                    case "7":
                        try
                        {
                            Console.WriteLine(vector.ToString());
                        }

                        catch (NullReferenceException)
                        {
                            Console.WriteLine("Элементы отсутствуют.");
                        }

                        Console.WriteLine();
                        Console.WriteLine("Нажмите Enter, чтобы продолжить.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "8":
                        try
                        {
                            Console.WriteLine("Модуль вектора: " + vector.GetNorm());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Все идет не по плану... Исключение: {e.Message}");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Нажмите Enter, чтобы продолжить.");
                        Console.ReadKey();
                        Console.Clear();
                        break;                   
                    case "9":
                        Console.WriteLine("Введите индекс:");
                        try
                        {
                            int user_index = int.Parse(Console.ReadLine());

                            Console.WriteLine($"Элемент с выбранным индексом: {vector[user_index]}");
                            Console.WriteLine("Введите новое значение элемента:");
                            try
                            {
                                int user_change = int.Parse(Console.ReadLine());
                                vector[user_index] = user_change;
                                Console.WriteLine("Элемент по выбранному индексу успешно изменен.");
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Введено некорректное значение. Элемент не изменен.");
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Элемента с таким индексом не существует.");
                        }
                        catch (NullReferenceException)
                        {
                            Console.WriteLine("Элемента с таким индексом не существует.");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Элемента с таким индексом не существует.");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Нажмите Enter, чтобы продолжить.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Такого пункта нет в меню. Введите существующий пункт.");
                        break;
                }
            }
        }
        static void Task3()
        {
            
            bool key_1 = true;
            IVectorable vector_1 = new ArrayVector();
            while (key_1)
            {
                Console.WriteLine("Выберете класс вектора:\n1 - ArrayVector\n2 - LinkedListVector");
                string vector_class = Console.ReadLine();
                if (vector_class == "1")
                {
                    Console.Write("Введите размерность первого вектора: ");
                    int user_lenght_1;
                    bool check_1 = int.TryParse(Console.ReadLine(), out user_lenght_1);
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
                    key_1= false;
                    break;
                }
                if (vector_class == "2")
                {
                    Console.Write("Введите размерность первого вектора: ");
                    int user_lenght_1;
                    bool check_1 = int.TryParse(Console.ReadLine(), out user_lenght_1);
                    if ((check_1) && (user_lenght_1 >= 0))
                    {
                        Console.WriteLine("\nВектор выбранной размерности успешно создан.");
                        vector_1 = new LinkedListVector(user_lenght_1);
                    }
                    else
                    {
                        Console.WriteLine("\nНеверно введены данные! Создан вектор с размерность, равной \"5\"");
                        vector_1 = new LinkedListVector();
                    }
                    key_1 = false;
                    break;
                }
                else Console.WriteLine("Неверно введен пункт! Попробуйте снова.");
            }
            Console.WriteLine("Введите значения вектора через пробел:");
            string? user_vector_1 = Console.ReadLine();
            double[]? sup_vector_1;
            try
            {
                sup_vector_1 = user_vector_1?.Split(' ').Select(double.Parse).ToArray();
                if (sup_vector_1.Length == vector_1.Length)
                {
                    for (int i = 0; i < vector_1.Length; i++)
                    {
                        vector_1[i] = sup_vector_1[i];
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

           
            bool key_2 = true;
            IVectorable vector_2 = new ArrayVector();
            while (key_2)
            {
                Console.WriteLine("Выберете класс вектора:\n1 - ArrayVector\n2 - LinkedListVector");
                string vector_class = Console.ReadLine();
                if (vector_class == "1")
                {
                    Console.Write("Введите размерность второго вектора: ");
                    int user_lenght_2;
                    bool check_2 = int.TryParse(Console.ReadLine(), out user_lenght_2);
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
                    key_2 = false;
                    break;
                }
                if (vector_class == "2")
                {
                    Console.Write("Введите размерность второго вектора: ");
                    int user_lenght_2;
                    bool check_2 = int.TryParse(Console.ReadLine(), out user_lenght_2);
                    if ((check_2) && (user_lenght_2 >= 0))
                    {
                        Console.WriteLine("\nВектор выбранной размерности успешно создан.");
                        vector_2 = new LinkedListVector(user_lenght_2);
                    }
                    else
                    {
                        Console.WriteLine("\nНеверно введены данные! Создан вектор с размерность, равной \"5\"");
                        vector_2 = new LinkedListVector();
                    }
                    key_2 = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Неверно введен пункт! Попробуйте снова.");
                   
                }
            }
            Console.WriteLine("Введите значения вектора через пробел:");
            string? user_vector_2 = Console.ReadLine();
            double[]? sup_vector_2;
            try
            {
                sup_vector_2 = user_vector_2?.Split(' ').Select(double.Parse).ToArray();
                if (sup_vector_2.Length == vector_2.Length)
                {
                    for (int i = 0; i < vector_2.Length; i++)
                    {
                        vector_2[i] = sup_vector_2[i];
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
                Console.WriteLine("Выберете пункт меню:\n0 - Выход\n1 - Сумма векторов\n2 - Скалярное произведение векторов\n3 - Вычисление модуля веторов");
                string menu = Console.ReadLine();
                switch (menu)
                {
                    case "0":
                        return;
                    case "1":
                        try
                        {
                            IVectorable vector_3 = Vectors.Sum(vector_1, vector_2);
                            Console.WriteLine("Сумма векторов равна:");
                            for (int i = 0; i < vector_3.Length; i++)
                            {
                                Console.Write(vector_3[i] + " ");
                            }
                            Console.WriteLine();
                        }

                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Нажмите Enter, чтобы продолжить.");
                        Console.ReadKey();
                        Console.Clear();
                    case "2":
                        try
                        {
                            double? mult = Vectors.Scalar(vector_1, vector_2);
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
                        double a1 = Vectors.GetNorm2(vector_1);
                        Console.WriteLine("Модуль(длина) первого вектора: " + a1);
                        double a2 = Vectors.GetNorm2(vector_2);
                        Console.WriteLine("Модуль(длина) второго вектора: " + a2);
                        Console.WriteLine();
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
            public static int Int_Input()
            {
                int n;
                try
                {
                    n = int.Parse(Console.ReadLine());
                    return n;
                }
                catch (Exception)
                {
                    Console.WriteLine("Вы ввели некорректные данные. Попробуйте снова.");
                    return 0;
                }
            }        
    }
}
