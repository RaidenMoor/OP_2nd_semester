using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Reflection.Metadata;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace LR6
{
    class Program
    {
        static void Main(string?[] args)
        {
            Console.WriteLine("Лабораторная работа №6 \nВыполнила Гусева Мария студентка группы 6101-020302D");
            while (true)
            {
                Console.WriteLine("Введите пункт меню:\n0 - Выход\n1 - Класс ArrayVector\n2 - Класс LinkedListVector\n3 - Класс Vectors\n" +
                    "4 - Работа с потоками и сериализацией");
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
                    case "4":
                        Task4();
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
                            Console.WriteLine(vector.ToString());
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
                    key_1 = false;
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
        static void Task4()
        {
            while (true)
            {
                Console.WriteLine("Выберете пункт меню:\n0 - Выход\n1 - Запись в байтовый поток\n2 - Чтение из байтового потока" +
                    "\n3 - Запись в символьный поток\n4 - Чтение из символьного потока\n5 - Сериализация классов ArrayVector и LinkedListVector\n" +
                    "6 - Запись и чтение массива векторов в символьном потоке\n7 - Запись и чтение массива векторов в байтовом потоке");
                string menu = Console.ReadLine();
                switch (menu)
                {
                    case "0":
                        return;
                    case "1":

                        Console.Write("Введите размерность вектора: ");
                        int user_lenght;
                        bool check = int.TryParse(Console.ReadLine(), out user_lenght);
                        ArrayVector vector_to_byte;
                        if ((check) && (user_lenght >= 0))
                        {
                            Console.WriteLine("\nВектор выбранной размерности успешно создан.");
                            vector_to_byte = new ArrayVector(user_lenght);
                        }
                        else
                        {
                            Console.WriteLine("\nНеверно введены данные! Создан вектор с размерность, равной \"5\"");
                            vector_to_byte = new ArrayVector();
                        }
                        Console.WriteLine("Введите значения вектора через пробел:");
                        string? user_vector = Console.ReadLine();
                        double[]? sup_vector;
                        try
                        {
                            sup_vector = user_vector?.Split(' ').Select(double.Parse).ToArray();
                            if (sup_vector.Length == vector_to_byte.Length)
                            {
                                for (int i = 0; i < vector_to_byte.Length; i++)
                                {
                                    vector_to_byte[i] = sup_vector[i];
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
                        bool all_positive = true;
                        for (int i = 0; i < vector_to_byte.Length; i++)
                        {
                            if (vector_to_byte[i] < 0)
                            {
                                vector_to_byte[i] *= -1;
                                all_positive = false;
                            }
                            else continue;
                        }
                        if (all_positive == false)
                        {
                            Console.WriteLine("Отрицательные значения заменены на те же с противоположным знаком, " +
                                "так как запись отрицательных чисел в байтовый поток невозможна.");
                        }
                        BinaryWriter stream_write = new BinaryWriter(File.Open("test_symbolstream.txt", FileMode.Create));
                       
                        Vectors.Byte_Vector_Write(vector_to_byte, stream_write);
                        Console.WriteLine("Вектор успешно записан в байтовый поток!");
                        stream_write.Close();
                        Console.WriteLine("Нажмите Enter, чтобы продолжить.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "2":
                        BinaryReader stream_read = new BinaryReader(File.Open("test_symbolstream.txt", FileMode.Open));
                        IVectorable byte_vector = Vectors.Byte_Vector_Read(stream_read);
                        stream_read.Close();
                        Console.Write("Вектор, прочитанный из символьного потока: " +
                            "\nРазмерность: " + byte_vector.Length + " Координаты: ");
                        for (int i = 0; i < byte_vector.Length; i++)
                            Console.Write(byte_vector[i] + " ");
                        Console.WriteLine();
                        Console.ReadLine();
                        Console.WriteLine("Нажмите Enter, чтобы продолжить.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "3":
                        Console.Write("Введите размерность вектора: ");
                        int user_lenght_3;
                        bool check_3 = int.TryParse(Console.ReadLine(), out user_lenght_3);
                        ArrayVector vector_to_write;
                        if ((check_3) && (user_lenght_3 >= 0))
                        {
                            Console.WriteLine("\nВектор выбранной размерности успешно создан.");
                            vector_to_write = new ArrayVector(user_lenght_3);
                        }
                        else
                        {
                            Console.WriteLine("\nНеверно введены данные! Создан вектор с размерность, равной \"5\"");
                            vector_to_write = new ArrayVector();
                        }
                        Console.WriteLine("Введите значения вектора через пробел:");
                        string? user_vector_3 = Console.ReadLine();
                        double[]? sup_vector_3;
                        try
                        {
                            sup_vector_3 = user_vector_3?.Split(' ').Select(double.Parse).ToArray();
                            if (sup_vector_3.Length == vector_to_write.Length)
                            {
                                for (int i = 0; i < vector_to_write.Length; i++)
                                {
                                    vector_to_write[i] = sup_vector_3[i];
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
                        StreamWriter stream_to_write = new StreamWriter("test_symbolstream.txt");
                        Vectors.WriteVector(vector_to_write, stream_to_write);
                        Console.WriteLine("Вектор успешно записан в символьный поток.");
                        stream_to_write.Close();
                        Console.WriteLine("Нажмите Enter, чтобы продолжить.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "4":
                        StreamReader stream_to_read = new StreamReader("test_symbolstream.txt");
                        IVectorable input_vector = Vectors.ReadVector(stream_to_read);
                        stream_to_read.Close();
                        Console.Write("Вектор, прочитанный из символьного потока: " + 
                             "\nРазмерность: " + input_vector.Length + " Координаты: ");
                        for (int i = 0; i < input_vector.Length; i++)
                            Console.Write(input_vector[i] + " ");
                        Console.WriteLine();
                        Console.ReadLine();
                        Console.WriteLine("Нажмите Enter, чтобы продолжить.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "5":
                        Console.WriteLine("Сериализация LinkedListVector:");
                        Console.Write("Введите размерность вектора: ");
                        int user_lenght_5;
                        bool check_5 = int.TryParse(Console.ReadLine(), out user_lenght_5);
                        LinkedListVector serialization_vector;
                        if ((check_5) && (user_lenght_5 >= 0))
                        {
                            Console.WriteLine("\nВектор выбранной размерности успешно создан.");
                            serialization_vector = new LinkedListVector(user_lenght_5);
                        }
                        else
                        {
                            Console.WriteLine("\nНеверно введены данные! Создан вектор с размерность, равной \"5\"");
                            serialization_vector = new LinkedListVector();
                        }
                        Console.WriteLine("Введите значения вектора через пробел:");
                        string? user_vector_5 = Console.ReadLine();
                        double[]? sup_vector_5;
                        try
                        {
                            sup_vector_5 = user_vector_5?.Split(' ').Select(double.Parse).ToArray();
                            if (sup_vector_5.Length == serialization_vector.Length)
                            {
                                for (int i = 0; i < serialization_vector.Length; i++)
                                {
                                    serialization_vector[i] = sup_vector_5[i];
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

                        Console.WriteLine("Вектор до сериализации: " + serialization_vector.ToString());
                        BinaryFormatter formatter = new BinaryFormatter();

                        using (FileStream fs = new FileStream("vector.dat", FileMode.OpenOrCreate))
                        {
                            formatter.Serialize(fs, serialization_vector);

                            Console.WriteLine("Объект сериализован");
                        }

                        // десериализация из файла vector.dat
                        using (FileStream fs = new FileStream("vector.dat", FileMode.OpenOrCreate))
                        {
                            LinkedListVector new_vector = (LinkedListVector)formatter.Deserialize(fs);

                            Console.WriteLine("Объект десериализован");
                            Console.WriteLine("Вектор после сериализации: " + new_vector);
                        }
                        Console.WriteLine("\n\nСериализация ArrayVector:");
                        Console.Write("Введите размерность вектора: ");
                        int user_lenght_a5;
                        bool check_a5 = int.TryParse(Console.ReadLine(), out user_lenght_a5);
                        ArrayVector test_arr_vector;
                        if ((check_a5) && (user_lenght_a5 >= 0))
                        {
                            Console.WriteLine("\nВектор выбранной размерности успешно создан.");
                            test_arr_vector = new ArrayVector(user_lenght_a5);
                        }
                        else
                        {
                            Console.WriteLine("\nНеверно введены данные! Создан вектор с размерность, равной \"5\"");
                            test_arr_vector = new ArrayVector();
                        }
                        Console.WriteLine("Введите значения вектора через пробел:");
                        string? user_vector_a5 = Console.ReadLine();
                        double[]? sup_vector_a5;
                        try
                        {
                            sup_vector_a5 = user_vector_a5?.Split(' ').Select(double.Parse).ToArray();
                            if (sup_vector_a5.Length == test_arr_vector.Length)
                            {
                                for (int i = 0; i < test_arr_vector.Length; i++)
                                {
                                    test_arr_vector[i] = sup_vector_a5[i];
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
                        Console.WriteLine("Вектор до сериализации: " + test_arr_vector.ToString());
                        BinaryFormatter formatter_2 = new BinaryFormatter();

                        using (FileStream fs = new FileStream("arr_vector.dat", FileMode.OpenOrCreate))
                        {
                            formatter.Serialize(fs, test_arr_vector);

                            Console.WriteLine("\nОбъект сериализован");
                        }
                        
                        // десериализация из файла vector.dat
                        using (FileStream fs = new FileStream("arr_vector.dat", FileMode.OpenOrCreate))
                        {
                            ArrayVector new_vector = (ArrayVector)formatter.Deserialize(fs);

                            Console.WriteLine("\nОбъект десериализован");
                            Console.Write("Вектор после сериализации: " + "\nРазмерность: " + new_vector.Length + " Координаты: ");
                            for (int i = 0; i < new_vector.Length; i++)
                                Console.Write(new_vector[i] + " ");
                            Console.WriteLine();
                        }
                        Console.WriteLine("Нажмите Enter, чтобы продолжить.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "6":
                        Console.WriteLine("Работа с байтовым потоком");
                        Console.WriteLine("Введите количество векторов в массиве: ");
                        check = false;
                        int n = 0;
                        while (check == false)
                        {
                            n = Int_Input();
                            if (n != 0)
                            {
                                if (n < 0)
                                {
                                    Console.WriteLine($"Вы ввели отрицательное значение! {n} будет заменено на {-n}");
                                    n = -n;
                                }
                                check = true;
                            }
                        }

                        IVectorable[] vectors = new IVectorable[n];
                        Console.WriteLine("Хотите ли Вы задать массив вручную? Если нет, будет создан массив с векторами размерности от 1 до 10 " +
                            "включительно и координатами от -100 до 100 включительно.\n1 - Да\n2 - Нет.");
                        check = false;
                        string choice;
                        while (check == false)
                        {
                            choice = Console.ReadLine();
                            if (choice == "1")
                            {
                                int r;

                                for (int i = 0; i < n; i++)
                                {
                                    Console.WriteLine("Введите размерность вектора №" + (i + 1));
                                    r = Int_Input();
                                    if ((r == 0) || (r < 0))
                                    {


                                        bool check_1 = false;
                                        while (check_1 == false)
                                        {
                                            Console.WriteLine("Размерность вектора не может быть равна нулю или быть меньше нуля!. Будет задана размерность по умолчанию." +
                                            "\nВыберете класс вектора №" + (i + 1) + "\n1 - ArrayVector\n2 - LinkedListVector");
                                            string choice_class = Console.ReadLine();
                                            if (choice_class == "1")
                                            {
                                                vectors[i] = new ArrayVector();
                                                Console.WriteLine("Введите значения вектора через пробел:");
                                                string? user_vector_2 = Console.ReadLine();
                                                double[]? sup_vector_2;
                                                try
                                                {
                                                    sup_vector_2 = user_vector_2?.Split(' ').Select(double.Parse).ToArray();
                                                    if (sup_vector_2.Length == vectors[i].Length)
                                                    {
                                                        for (int j = 0; j < vectors[i].Length; j++)
                                                        {
                                                            vectors[i][j] = sup_vector_2[j];
                                                        }
                                                        Console.WriteLine("Значения успешно установлены.");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Размерность вектора и количество введенных чисел не совпадает. Значения равны нулю.");
                                                    }
                                                }
                                                catch (FormatException)
                                                {
                                                    Console.WriteLine("Введенные данные некорректны.");
                                                }
                                                check_1 = true;
                                                break;
                                            }
                                            if (choice_class == "2")
                                            {
                                                vectors[i] = new LinkedListVector();
                                                Console.WriteLine("Введите значения вектора через пробел:");
                                                string? user_vector_2 = Console.ReadLine();
                                                double[]? sup_vector_2;
                                                try
                                                {
                                                    sup_vector_2 = user_vector_2?.Split(' ').Select(double.Parse).ToArray();
                                                    if (sup_vector_2.Length == vectors[i].Length)
                                                    {
                                                        for (int j = 0; j < vectors[i].Length; j++)
                                                        {
                                                            vectors[i][j] = sup_vector_2[j];
                                                        }
                                                        Console.WriteLine("Значения успешно установлены.");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Размерность вектора и количество введенных чисел не совпадает. Значения равны нулю.");
                                                    }
                                                }
                                                catch (FormatException)
                                                {
                                                    Console.WriteLine("Введенные данные некорректны.");
                                                }
                                                check_1 = true;
                                                break;
                                            }
                                            else Console.WriteLine("Вы ввели некорретный номер! Введите \"1\" или \"2\".");
                                        }

                                    }
                                    if (r > 0)
                                    {
                                        Console.WriteLine("Выберете класс вектора №" + (i + 1) + "\n1 - ArrayVector\n2 - LinkedListVector");
                                        string choice_class = Console.ReadLine();
                                        bool check_1 = false;
                                        while (check_1 == false)
                                        {
                                            if (choice_class == "1")
                                            {
                                                vectors[i] = new ArrayVector(r);
                                                Console.WriteLine("Введите значения вектора через пробел:");
                                                string? user_vector_2 = Console.ReadLine();
                                                double[]? sup_vector_2;
                                                try
                                                {
                                                    sup_vector_2 = user_vector_2?.Split(' ').Select(double.Parse).ToArray();
                                                    if (sup_vector_2.Length == vectors[i].Length)
                                                    {
                                                        for (int j = 0; j < vectors[i].Length; j++)
                                                        {
                                                            vectors[i][j] = sup_vector_2[j];
                                                        }
                                                        Console.WriteLine("Значения успешно установлены.");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Размерность вектора и количество введенных чисел не совпадает. Значения равны нулю.");
                                                    }
                                                }
                                                catch (FormatException)
                                                {
                                                    Console.WriteLine("Введенные данные некорректны.");
                                                }
                                                check_1 = true;
                                                break;
                                            }
                                            if (choice_class == "2")
                                            {
                                                vectors[i] = new LinkedListVector(r);
                                                Console.WriteLine("Введите значения вектора через пробел:");
                                                string? user_vector_2 = Console.ReadLine();
                                                double[]? sup_vector_2;
                                                try
                                                {
                                                    sup_vector_2 = user_vector_2?.Split(' ').Select(double.Parse).ToArray();
                                                    if (sup_vector_2.Length == vectors[i].Length)
                                                    {
                                                        for (int j = 0; j < vectors[i].Length; j++)
                                                        {
                                                            vectors[i][j] = sup_vector_2[j];
                                                        }
                                                        Console.WriteLine("Значения успешно установлены.");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Размерность вектора и количество введенных чисел не совпадает. Значения равны нулю.");
                                                    }
                                                }
                                                catch (FormatException)
                                                {
                                                    Console.WriteLine("Введенные данные некорректны.");
                                                }
                                                check_1 = true;
                                                break;
                                            }
                                            else Console.WriteLine("Вы ввели некорретный номер! Введите \"1\" или \"2\".");
                                        }
                                    }

                                }
                                Console.WriteLine("Все векторы массива:");
                                for (int i = 0; i < n; i++)
                                {
                                    Console.WriteLine($"Вектор №{i + 1}: {vectors[i].ToString()}");
                                }
                                check = true;
                                break;
                            }
                            if (choice == "2")
                            {
                                var rand = new Random();
                                int r;
                                Console.WriteLine("Если индекс вектора четный, то он принадлежит классу ArrayVector, а если нечетный, " +
                                    "то классу LinkedListVector");
                                for (int i = 0; i < n; i++)
                                {
                                    r = rand.Next(1, 11);

                                    if (i % 2 == 0)
                                    {
                                        vectors[i] = new ArrayVector(r);
                                        for (int j = 0; j < vectors[i].Length; j++)
                                        {
                                            vectors[i][j] = rand.Next(0, 101);
                                        }
                                    }
                                    if (i % 2 != 2)
                                    {
                                        vectors[i] = new LinkedListVector(r);
                                        for (int j = 0; j < vectors[i].Length; j++)
                                        {
                                            vectors[i][j] = rand.Next(-100, 101);
                                        }
                                    }
                                    Console.WriteLine($"Вектор №{i + 1}: {vectors[i].ToString()}");
                                }
                                check = true;
                                break;
                            }
                            else Console.WriteLine("Вы ввели некорретный номер! Введите \"1\" или \"2\".");
                        }
                        TextWriter text_write = File.CreateText("text.txt");
                        for (int i = 0; i < n; i++)
                        {
                            Vectors.WriteVector(vectors[i], text_write);
                        }
                        Console.WriteLine("Текст записан в файл");
                        text_write.Close();

                        Console.WriteLine("----------------------");
                        TextReader text_read = File.OpenText("text.txt");
                        IVectorable[] Nvectors = new IVectorable[n];
                        for (int i = 0; i < n; i++)
                        {
                            Nvectors[i] = Vectors.ReadVector(text_read);
                            Console.WriteLine(Nvectors[i].ToString());
                        }
                        text_read.Close();

                        Console.WriteLine("Нажмите Enter, чтобы продолжить.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "7":
                       
                        Console.WriteLine("Работа с байтовым потоком");
                        Console.WriteLine("\nВведите количество векторов в массиве: ");
                        check = false;
                        n = 0;
                        while (check == false)
                        {
                            n = Int_Input();
                            if (n != 0)
                            {
                                if (n < 0)
                                {
                                    Console.WriteLine($"Вы ввели отрицательное значение! {n} будет заменено на {-n}");
                                    n = -n;
                                }
                                check = true;
                            }
                        }

                        vectors = new IVectorable[n];
                        Console.WriteLine("Хотите ли Вы задать массив вручную? Если нет, будет создан массив с векторами размерности от 1 до 10 " +
                            "включительно и координатами от -100 до 100 включительно.\n1 - Да\n2 - Нет.");
                        check = false;
                        while (check == false)
                        {
                            choice = Console.ReadLine();
                            if (choice == "1")
                            {
                                int r;

                                for (int i = 0; i < n; i++)
                                {
                                    Console.WriteLine("Введите размерность вектора №" + (i + 1));
                                    r = Int_Input();
                                    if ((r == 0) || (r < 0))
                                    {


                                        bool check_1 = false;
                                        while (check_1 == false)
                                        {
                                            Console.WriteLine("Размерность вектора не может быть равна нулю или быть меньше нуля!. Будет задана размерность по умолчанию." +
                                            "\nВыберете класс вектора №" + (i + 1) + "\n1 - ArrayVector\n2 - LinkedListVector");
                                            string choice_class = Console.ReadLine();
                                            if (choice_class == "1")
                                            {
                                                vectors[i] = new ArrayVector();
                                                Console.WriteLine("Введите значения вектора через пробел:");
                                                string? user_vector_2 = Console.ReadLine();
                                                double[]? sup_vector_2;
                                                try
                                                {
                                                    sup_vector_2 = user_vector_2?.Split(' ').Select(double.Parse).ToArray();
                                                    if (sup_vector_2.Length == vectors[i].Length)
                                                    {
                                                        for (int j = 0; j < vectors[i].Length; j++)
                                                        {
                                                            vectors[i][j] = sup_vector_2[j];
                                                        }
                                                        Console.WriteLine("Значения успешно установлены.");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Размерность вектора и количество введенных чисел не совпадает. Значения равны нулю.");
                                                    }
                                                }
                                                catch (FormatException)
                                                {
                                                    Console.WriteLine("Введенные данные некорректны.");
                                                }
                                                check_1 = true;
                                                break;
                                            }
                                            if (choice_class == "2")
                                            {
                                                vectors[i] = new LinkedListVector();
                                                Console.WriteLine("Введите значения вектора через пробел:");
                                                string? user_vector_2 = Console.ReadLine();
                                                double[]? sup_vector_2;
                                                try
                                                {
                                                    sup_vector_2 = user_vector_2?.Split(' ').Select(double.Parse).ToArray();
                                                    if (sup_vector_2.Length == vectors[i].Length)
                                                    {
                                                        for (int j = 0; j < vectors[i].Length; j++)
                                                        {
                                                            vectors[i][j] = sup_vector_2[j];
                                                        }
                                                        Console.WriteLine("Значения успешно установлены.");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Размерность вектора и количество введенных чисел не совпадает. Значения равны нулю.");
                                                    }
                                                }
                                                catch (FormatException)
                                                {
                                                    Console.WriteLine("Введенные данные некорректны.");
                                                }
                                                check_1 = true;
                                                break;
                                            }
                                            else Console.WriteLine("Вы ввели некорретный номер! Введите \"1\" или \"2\".");
                                        }

                                    }
                                    if (r > 0)
                                    {
                                        Console.WriteLine("Выберете класс вектора №" + (i + 1) + "\n1 - ArrayVector\n2 - LinkedListVector");
                                        string choice_class = Console.ReadLine();
                                        bool check_1 = false;
                                        while (check_1 == false)
                                        {
                                            if (choice_class == "1")
                                            {
                                                vectors[i] = new ArrayVector(r);
                                                Console.WriteLine("Введите значения вектора через пробел:");
                                                string? user_vector_2 = Console.ReadLine();
                                                double[]? sup_vector_2;
                                                try
                                                {
                                                    sup_vector_2 = user_vector_2?.Split(' ').Select(double.Parse).ToArray();
                                                    if (sup_vector_2.Length == vectors[i].Length)
                                                    {
                                                        for (int j = 0; j < vectors[i].Length; j++)
                                                        {
                                                            vectors[i][j] = sup_vector_2[j];
                                                        }
                                                        Console.WriteLine("Значения успешно установлены.");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Размерность вектора и количество введенных чисел не совпадает. Значения равны нулю.");
                                                    }
                                                }
                                                catch (FormatException)
                                                {
                                                    Console.WriteLine("Введенные данные некорректны.");
                                                }
                                                check_1 = true;
                                                break;
                                            }
                                            if (choice_class == "2")
                                            {
                                                vectors[i] = new LinkedListVector(r);
                                                Console.WriteLine("Введите значения вектора через пробел:");
                                                string? user_vector_2 = Console.ReadLine();
                                                double[]? sup_vector_2;
                                                try
                                                {
                                                    sup_vector_2 = user_vector_2?.Split(' ').Select(double.Parse).ToArray();
                                                    if (sup_vector_2.Length == vectors[i].Length)
                                                    {
                                                        for (int j = 0; j < vectors[i].Length; j++)
                                                        {
                                                            vectors[i][j] = sup_vector_2[j];
                                                        }
                                                        Console.WriteLine("Значения успешно установлены.");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Размерность вектора и количество введенных чисел не совпадает. Значения равны нулю.");
                                                    }
                                                }
                                                catch (FormatException)
                                                {
                                                    Console.WriteLine("Введенные данные некорректны.");
                                                }
                                                check_1 = true;
                                                break;
                                            }
                                            else Console.WriteLine("Вы ввели некорретный номер! Введите \"1\" или \"2\".");
                                        }
                                    }

                                }
                                
                                Console.WriteLine("\nВсе векторы массива:");
                                for (int i = 0; i < n; i++)
                                {
                                    Console.WriteLine($"Вектор №{i + 1}: {vectors[i].ToString()}");
                                }
                                check = true;
                                break;
                            }
                            if (choice == "2")
                            {
                                var rand = new Random();
                                int r;
                                Console.WriteLine("\nЕсли индекс вектора четный, то он принадлежит классу ArrayVector, а если нечетный, " +
                                    "то классу LinkedListVector");
                                for (int i = 0; i < n; i++)
                                {
                                    r = rand.Next(1, 11);

                                    if (i % 2 == 0)
                                    {
                                        vectors[i] = new ArrayVector(r);
                                        for (int j = 0; j < vectors[i].Length; j++)
                                        {
                                            vectors[i][j] = rand.Next(0, 101);
                                        }
                                    }
                                    if (i % 2 != 2)
                                    {
                                        vectors[i] = new LinkedListVector(r);
                                        for (int j = 0; j < vectors[i].Length; j++)
                                        {
                                            vectors[i][j] = rand.Next(-100, 101);
                                        }
                                    }
                                    Console.WriteLine($"Вектор №{i + 1}: {vectors[i].ToString()}");
                                }
                                check = true;
                                break;
                            }
                            else Console.WriteLine("Вы ввели некорретный номер! Введите \"1\" или \"2\".");
                        }
                        BinaryWriter byte_file = new BinaryWriter(File.Open("byte.txt", FileMode.Create));
                        for (int i = 0; i < n; i++)
                        {
                            Vectors.Byte_Vector_Write(vectors[i], byte_file);
                        }
                        byte_file.Close();
                        BinaryReader bf_r = new BinaryReader(File.Open("byte.txt", FileMode.Open));
                        Console.WriteLine("Векторы записаны в файл");
                        Console.WriteLine("....................................");
                        Console.WriteLine("\nЧитаем векторы из файла:");
                        Nvectors = new IVectorable[n];
                        for (int i = 0; i < n; i++)
                        {
                            Nvectors[i] = Vectors.Byte_Vector_Read(bf_r);
                            Console.WriteLine(Nvectors[i].ToString());
                        }
                       
                        bf_r.Close();
                        Console.ReadLine();
                        Console.WriteLine("Нажмите Enter, чтобы продолжить.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Ошибка! Введите существующее действие.");
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
