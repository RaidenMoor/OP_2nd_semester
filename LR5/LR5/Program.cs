using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics;


namespace LR5
{
    class Program
    {
        static void Main(string?[] args)
        {
            Console.WriteLine("Лабораторная работа №5 \nВыполнила Гусева Мария \nстудентка группы 6101-020302D");
            while (true)
            {
                Console.WriteLine("Введите пункт меню:\n0 - Выход\n1 - Класс ArrayVector\n2 - Класс LinkedListVector\n3 - Класс Vectors" +
                    "\n4 - Работа с массивом векторов типа IVectorable");
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
                        Console.WriteLine();
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
                    "4 - Вывести количество координат вектора на экран\n5 - Вывести координаты вектора на экран\n6 - Клонировать вектор");
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
                            Console.WriteLine("Число координат вектора равен: " + vector.Length);
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
                    case "6":
                        ArrayVector clone = new ArrayVector();
                        clone = (ArrayVector)vector.Clone();
                        Console.WriteLine($"Сравнение векторов с помощью метода Equals() (если векторы равны по размеру и значениям, возвращает true)" +
                            $": {vector.Equals(clone)}");
                        Console.WriteLine("Оригинал вектора: " + vector.ToString());
                        Console.WriteLine("Копия вектора: " + clone.ToString());
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
            Console.WriteLine("Нажмите Enter, чтобы выйти в главное меню.");
            Console.ReadKey();
            Console.Clear();
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
                    "6 - Удаление элемента из списка по выбранному индексу\n7 - Вывести вектор на экран" +
                    "\n8 - Вычислить модуль вектора\n9 - Вывести число координат\n10 - Изменить элемент по выбранному индексу\n" +
                    "11 - Клонировать вектор");
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
                        try
                        {
                            Console.WriteLine("Число координат: " + vector.Length);
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
                    case "10":
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
                    case "11":
                        LinkedListVector clone = new LinkedListVector();
                        clone = (LinkedListVector)vector.Clone();
                        Console.WriteLine($"Сравнение векторов с помощью метода Equals() (если векторы равны по размеру и значениям, возвращает true)" +
                            $": {vector.Equals(clone)}");                    
                        Console.WriteLine("Оригинал вектора: " + vector.ToString());
                        Console.WriteLine("Копия вектора: " + clone.ToString());
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
            Console.WriteLine("Нажмите Enter, чтобы выйти в главное меню.");
            Console.ReadKey();
            Console.Clear();
        }
        static void Task3()
        {
            Console.Write("Введите размерность первого вектора: ");
            int user_lenght_1;
            bool check_1 = int.TryParse(Console.ReadLine(), out user_lenght_1);
            IVectorable vector_1;
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
                            IVectorable vector_3 = new ArrayVector();
                            vector_3 = Vectors.Sum(vector_1, vector_2);
                            Console.WriteLine("Сумма векторов равна:");
                            Vectors.ToString(vector_3);
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
            Console.WriteLine("Нажмите Enter, чтобы выйти в главное меню.");
            Console.ReadKey();
            Console.Clear();
        }
        static void Task4()
        {
            Console.WriteLine("Введите количество векторов в массиве: ");
            bool check = false;
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
            while (true)
            {
                Console.WriteLine("Выберете действие, которое хотите произвести с массивом векторов:\n0 - Выход в главное меню" +
                    "\n1 - Вывести максимальное и минимальное количество координат в векторах\n2 - Отсортировать вектора по возрастанию" +
                    " их модулей\n3 - Проверить с помощью метода Equals() выбранные векторы");
                string menu_4 = Console.ReadLine();
                switch (menu_4)
                {
                    case "0":
                        return;
                    case "1":
                        IVectorable max = vectors[0];
                        IVectorable min = vectors[0];
                        int cmp;
                        for (int i = 0; i < n - 1; i++)
                        {
                            cmp = max.CompareTo(vectors[i + 1]);
                            if (cmp == -1)
                            {
                                max = vectors[i + 1];
                            }
                            cmp = min.CompareTo(vectors[i + 1]);
                            if (cmp == 1)
                            {
                                min = vectors[i + 1];
                            }
                            else continue;
                        }
                        Console.WriteLine($"Минимальное число координат: {min.Length}\nМаксимальное число координат:{max.Length}");
                        Console.WriteLine("Векторы минимальной размерности:");
                        for (int i = 0; i < n; i++)
                        {
                            if (vectors[i].Length == min.Length )
                                Console.WriteLine(vectors[i].ToString());
                        }
                        Console.WriteLine("Векторы максимальной размерности:");
                        for (int i = 0; i < n; i++)
                        {
                            if (vectors[i].Length == max.Length)
                                Console.WriteLine(vectors[i].ToString());
                        }
                        Console.WriteLine();
                        Console.WriteLine("Нажмите Enter, чтобы продолжить.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "2":
                        Console.WriteLine("Сортировка векторов по возрастанию их модулей:\n");
                        for (int i = 1; i < n; i++)
                        {
                            IVectorable sup_vector = vectors[i];
                            int j = i - 1;

                            while (j >= 0 && vectors[j].GetNorm() > sup_vector.GetNorm())
                            {
                                vectors[j + 1] = vectors[j];
                                vectors[j] = sup_vector;
                                j--;
                            }
                        }
                        for (int i = 0; i < n; i++)
                        {
                            Console.WriteLine($"Вектор {i + 1}" + vectors[i].ToString() + $"\nМодуль вектора {i + 1}: {vectors[i].GetNorm()}");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Нажмите Enter, чтобы продолжить.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "3":
                        Console.WriteLine("Введите индекс первого вектора(нумерация начинается с нуля)");
                        int v1 = Int_Input();
                        if (v1 < 0)
                        {
                            Console.WriteLine($"Вы ввели отрицательно значение! {v1} будет заменено на {-v1}");
                            v1 = -v1;
                        }
                        Console.WriteLine("Введите индекс второго вектора(нумерация начинается с нуля)");
                        int v2 = Int_Input();
                        if (v1 < 0)
                        {
                            Console.WriteLine($"Вы ввели отрицательно значение! {v2} будет заменено на {-v2}");
                            v1 = -v2;
                        }
                        try
                        {
                            
                            if (vectors[v1].Length == vectors[v2].Length)
                            {
                                bool eqv = vectors[v1].Equals(vectors[v2]);
                                if (eqv)
                                {
                                    Console.WriteLine("Вектора эквивалентны. Их длины и координаты равны.");
                                }
                                else Console.WriteLine("Вектора не эквивалентны. Их длины и координаты не равны.");
                            }
                            else Console.WriteLine("Вектора не эквивалентны. Их длины и координаты не равны.");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Вы ввели несуществующий индекс.");
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
            Console.WriteLine("Нажмите Enter, чтобы выйти в главное меню.");
            Console.ReadKey();
            Console.Clear();

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
                Console.WriteLine("Вы ввели некорректные данные. Присвоено значение \"0\"");
                return 0;
            }
            
        }
        public static double Double_Input()
        {
            double n;
            try
            {
                n = double.Parse(Console.ReadLine());
                return n;
            }
            catch (Exception)
            {
                Console.WriteLine("Вы ввели некорректные данные. Присвоено значение \"0\"");
                return 0;
            }

        }
    }
}
