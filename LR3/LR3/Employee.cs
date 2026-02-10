using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR3
{
        public enum Vacancies
        {
            Manager,
            Boss,
            Clerk,
            Salesman
        }
        struct Employee
        {
            private string surname;
            private string name;         
            private Vacancies vacancy;
            private int salary;
            private DateTime hiredate;
            public string Name { get; set; }
            public string Surname { get; set; }
            public Vacancies Vacancy { get; set; }
            public int Salary { get; set; }
            public DateTime Hiredate { get; set; }           
            public void Info_Print()
            {
                Console.WriteLine($"Имя сотрудника: {Surname} {Name}\nДолжность: {Vacancy}\nРазмер заработной платы: {Salary} рублей\nНанят {Hiredate.ToString("d")}");
            }

        }

}
