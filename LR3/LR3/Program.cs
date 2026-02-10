using System;
using System.Collections.Generic;
using System.Data;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Reflection.Metadata;

namespace LR3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа №3\nВыполнена Гусевой Марией студенткой 6101-020302D\nСписок работников и его обработка");
            Console.WriteLine("Введите количество сотрудников:");
            int count = IntInput();
            while (count < 1)
            {
                Console.WriteLine("У вас не может быть менее одного сотрудника! Введите число, больше или равное единице.");
                count = IntInput();
            }
            bool boss_find = false;
            Employee[] employer = new Employee[count];
            for (int i = 0; i < count; i++)
            {
               Console.WriteLine($"Введите имя сотрудника {i + 1}");
               string? surname = Console.ReadLine();
                Console.WriteLine($"Введите фамилию сотрудника {i + 1}");
                string? name = Console.ReadLine();
                Console.WriteLine($"Введите заработную плату сотрудника {i + 1}");
                int salary = IntInput();
                Console.WriteLine("Выберете должность:\n1 - Менеджер\n2 - Босс\n3 - Клерк\n4 - Продавец");
                bool key = true;
                while (key == true)
                {
                    string? chose = Console.ReadLine();
                    switch (chose)
                    {

                        case "1":
                            employer[i].Vacancy = Vacancies.Manager;
                            key = false;
                            break;
                        case "2":
                            if (boss_find)
                            {
                                Console.WriteLine("Вы уже ввели в базу человека с должностью \"Босс\". Выберете другую должность:");                               
                            }
                            else
                            {
                                employer[i].Vacancy = Vacancies.Boss;
                                key = false;
                                boss_find = true;
                            }
                            break;
                        case "3":
                            employer[i].Vacancy = Vacancies.Clerk;
                            key = false;
                            break;
                        case "4":
                            employer[i].Vacancy = Vacancies.Salesman;
                            key = false;
                            break;
                        default:
                            Console.WriteLine("Нет такого варианта! Введите существующую должность.");                          
                            break;
                    }
                }
                if (employer[i].Vacancy == Vacancies.Boss) boss_find = true;
                Console.WriteLine($"Введите дату, когда был назначен сотрудник {i + 1}: ");
                DateTime hierdate;
                try
                {
                    hierdate = DateTime.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Дата введена некорректно. Присвоено значение по умолчанию: 01.01.2023.");
                    hierdate = new DateTime(2023, 01, 01);
                }

                employer[i].Surname = surname;
                employer[i].Name = name;                
                employer[i].Salary = salary;
                employer[i].Hiredate = hierdate;
                Console.WriteLine();
            }
            Console.WriteLine("Список сотрудников создан!\n");
            while(true)
            {
                Console.WriteLine(" Выберете действие:\n0 - Выход\n1 - " +
               "Вывести полную информацию обо всех сотрудниках\n2 - Вывести полную информацию о сотрудниках," +
               " работающих в указанной должности\n3 - Найти в массиве всех менеджеров, зарплата которых больше средней " +
               "зарплаты всех клерков, вывести на экран полную информацию о таких менеджерах, отсортировать в алфавитном порядке " +
               "по фамилии\n4 - Вывести полную информацию обо всех сотрудниках, принятых на работу позже босса, " +
               "отсортированную в алфавитном порядке по фамилии сотрудника");
                string menu = Console.ReadLine();
                switch (menu)
                {
                    case "0":
                        return;
                    case "1":
                        Console.WriteLine("Все сотрудники:\n");
                        for (int i = 0; i < count; i++)
                        {
                            employer[i].Info_Print();
                            Console.WriteLine();
                        }
                        Console.WriteLine();
                        Console.WriteLine("Нажмите любую клавишу, чтобы продолжить.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "2":
                        Console.WriteLine("Выберете должность:\n1 - Менеджер\n2 - Босс\n3 - Клерк\n4 - Продавец");
                        string? chose = Console.ReadLine();
                        switch (chose)
                        {

                            case "1":
                                int ch_2 = 0;
                                Console.WriteLine("Все менеджеры:\n");
                                for (int i = 0; i < count; i++)
                                {

                                    if (employer[i].Vacancy == Vacancies.Manager)
                                    {
                                        employer[i].Info_Print();
                                        Console.WriteLine();
                                        ch_2++;
                                    }
                                }
                                if (ch_2 == 0) Console.WriteLine("В данном списке нет менеджеров!");
                                break;
                            case "2":
                                ch_2 = 0;
                                Console.WriteLine("Босс:\n");
                                for (int i = 0; i < count; i++)
                                {

                                    if (employer[i].Vacancy == Vacancies.Boss)
                                    {
                                        employer[i].Info_Print();
                                        Console.WriteLine();
                                        ch_2++;
                                    }
                                }
                                if (ch_2 == 0) Console.WriteLine("В данном списке нет босса!");
                                break;
                            case "3":
                                ch_2 = 0;
                                Console.WriteLine("Все клерки:\n");
                                for (int i = 0; i < count; i++)
                                {

                                    if (employer[i].Vacancy == Vacancies.Clerk)
                                    {
                                        employer[i].Info_Print();
                                        Console.WriteLine();
                                        ch_2++;
                                    }
                                }
                                if (ch_2 == 0) Console.WriteLine("В данном списке нет клерков!");
                                break;
                            case "4":
                                ch_2 = 0;
                                Console.WriteLine("Все продавцы:\n");
                                for (int i = 0; i < count; i++)
                                {

                                    if (employer[i].Vacancy == Vacancies.Salesman)
                                    {
                                        employer[i].Info_Print();
                                        Console.WriteLine();
                                        ch_2++;
                                    }
                                }
                                if (ch_2 == 0) Console.WriteLine("В данном списке нет продавцов!");
                                break;
                            default:
                                Console.WriteLine("Нет такого варианта!");
                                break;
                        }
                        Console.WriteLine();
                        Console.WriteLine("Нажмите любую клавишу, чтобы продолжить.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "3":
                        int m = 0, c = 0, average_salary = 0;

                        for (int i = 0; i < count; i++)
                        {
                            if (employer[i].Vacancy == Vacancies.Clerk)
                            {
                                c++;
                                average_salary += employer[i].Salary;
                            }
                        }
                        if (c != 0)
                        {
                            average_salary /= c;
                            Console.WriteLine("Средняя зарплата клерков: " + average_salary);
                        }
                        else Console.WriteLine("В списке сотрудников нет клерков! Средняя зарплата равна нулю.");
                        for (int i = 0; i < count; i++)
                        {
                            if ((employer[i].Vacancy == Vacancies.Manager) && (employer[i].Salary > average_salary))
                            {
                                m++;

                            }
                        }
                        Employee[] managers = new Employee[m];
                        int ch = 0;
                        try
                        {
                            for (int i = 0; i < count; i++)
                            {
                                if ((employer[i].Vacancy == Vacancies.Manager) && (employer[i].Salary > average_salary))
                                {
                                    managers[ch] = employer[i];
                                    ch++;
                                }
                            }
                        }
                        catch (IndexOutOfRangeException)
                        {
                            break;
                        }

                        if (m != 0)
                        {
                            for (int j = 0; j < m - 1; j++)
                            {
                                if (m > 1)
                                {
                                    if (Reorginize(managers[j].Name, managers[j + 1].Name))
                                    {
                                        string sup = managers[j].Name;
                                        managers[j].Name = managers[j + 1].Name;
                                        managers[j + 1].Name = sup;
                                    }
                                }

                            }
                            Console.WriteLine("Все менеджеры, зарплата которых выше средней зарплаты всех клерков:\n");

                            for (int i = 0; i < m; i++)
                            {
                                managers[i].Info_Print();
                                Console.WriteLine();
                            }
                        }

                        else Console.WriteLine("В списке сотрудников нет менеджеров с зарплатой, удовлетворяющей условию!");
                        Console.WriteLine();
                        Console.WriteLine("Нажмите любую клавишу, чтобы продолжить.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "4":
                        int k = 0;
                        bool boss = false;
                        DateTime boss_date = new DateTime();
                        for (int i = 0; i < count; i++)
                        {
                            if (employer[i].Vacancy == Vacancies.Boss)
                            {
                                boss_date = employer[i].Hiredate;
                                boss = true;
                            }
                        }
                        if (boss)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                if ((employer[i].Hiredate > boss_date) && (employer[i].Vacancy != Vacancies.Boss))
                                {
                                    k++;
                                }
                            }
                            if (k != 0)
                            {
                                Employee[] after_boss = new Employee[k];
                                int ch_1 = 0;
                                try
                                {
                                    for (int i = 0; i < count; i++)
                                    {
                                        if ((employer[i].Hiredate > boss_date) && (employer[i].Vacancy != Vacancies.Boss))
                                        {
                                            after_boss[ch_1] = employer[i];
                                            ch_1++;
                                        }
                                    }
                                }
                                catch (IndexOutOfRangeException)
                                {
                                    break;
                                }
                                for (int i = 0; i < k-1; i++)
                                {
                                    if (k > 1)
                                    {
                                        if (Reorginize(after_boss[i].Name, after_boss[i + 1].Name))
                                        {
                                            string sup = after_boss[i].Name;
                                            after_boss[i].Name = after_boss[i + 1].Name;
                                            after_boss[i + 1].Name = sup;
                                        }
                                    }
                                }
                                for (int i = 0; i < k; i++)
                                {
                                    after_boss[i].Info_Print();
                                    Console.WriteLine();
                                }
                            }
                            else Console.WriteLine("Нет сотрудников, нанятых позже босса");
                        }
                        else Console.WriteLine("Нет босса.");
                        Console.WriteLine();
                        Console.WriteLine("Нажмите любую клавишу, чтобы продолжить.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Введен неверный пункт меню. Повторите попытку ввода.");
                        Console.WriteLine();
                        Console.WriteLine("Нажмите любую клавишу, чтобы продолжить.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
        public static int IntInput()
        {
            int n;
            try
            {
                n = Convert.ToInt32(Console.ReadLine());

                if (n < 0)
                {
                    Console.WriteLine("Вы ввели отрицательное значение. Переменной присвоено значение \"0\"");
                    n = 0;
                }
                return n;
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Вы ввели строку или не ввели ничего. Переменной присвоено значение \"0\"");
                return n = 0;
            }
            catch (FormatException)
            {
                Console.WriteLine("Вы ввели строку или не ввели ничего.Переменной присвоено значение \"0\"");
                return n = 0;
            }
            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу, чтобы продолжить.");
            Console.ReadKey();
            

        }
        public static bool Reorginize(string emp1, string emp2)
        {
            for (int i = 0; i < (emp1.Length > emp2.Length ? emp2.Length : emp1.Length); i++)
            {
                if (emp1.ToCharArray()[i] < emp2.ToCharArray()[i]) return false;
                else return true;
            }
            return false;

        }
    }
}
