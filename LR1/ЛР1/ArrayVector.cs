using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ЛР1
{
    internal class ArrayVector
    {
        private double[] vector;
        public ArrayVector() : this(5)
        {
        }
        public ArrayVector(int n)
        {
            vector = new double[n];
        }

        public void SetElement(int n, double m)
        {
            if ((n < 0) && (n > vector.Length))
            {
                throw new Exception("Элемента с таким индексом не существует.");
            }
            else
            {
                vector[n] = m;
            }
            ;
        }
        public double GetElement(int n)
        {
            if ((n < 0) && (n > vector.Length))
            {
                throw new IndexOutOfRangeException("Элемента с таким индексом не существует.");
            }
            else
            {
                return vector[n];
            }

        }
        public double GetNorm()
        {
            double sum = 0;
            for (int i = 0; i < vector.Length; i++)
            {
                sum += vector[i] * vector[i];
            }
            return Math.Sqrt(sum);
        }
        public int Lenght
        {
            get { return vector.Length; }

        }
        public void SumPositivesFromChetIndex()
        {
            double summ = 0;
            for (int i = 0; i < vector.Length; i += 2)
            {
                if (vector[i] > 0) summ += vector[i];
            }
            if (summ == 0) Console.WriteLine("Нет положительных элементов с четными номерами");
            else Console.WriteLine("Сумма положительных элементов с четными номерами равна: " + summ);
        }
        public void SumLessFromNechetIndex()
        {
            double summ = 0;

            for (int i = 0; i < vector.Length;i++)
            {
                summ += Math.Abs(vector[i]);
            }
            double middle = summ / vector.Length;
            summ = 0;
            for (int j = 1; j < vector .Length; j+=2)
            {
                if (vector[j] < middle) summ += vector[j];
            }
            if (summ == 0) Console.WriteLine("Нет элементов, меньше среднего значения всех модулей элементов массива" +
                " с нечетными номерами");
            else Console.WriteLine("Сумма элементов с нечетными номерами, меньше среднего значения всех " +
                "модулей элементов массива, равна: " + summ);
        }
        public void MultChet()
        {
            double mult = 1, count = 0;
            for (int i = 0; i < vector .Length; i++)
            {
                if ((vector[i] > 0) && (vector[i] % 2 == 0))
                {
                    mult *= vector[i];
                    count += 1;
                }
            }
            if (count == 0) Console.WriteLine("Нет четных положительных элементов.");
            else Console.WriteLine("Произведение равно:" + mult);
        }
        public void MultNechet()
        {
            double mult = 1, count = 0;
            for (int i = 0; i < vector.Length; i++)
            {
                if ((vector[i] % 2 != 0) && (vector[i] % 3 != 0))
                {
                    mult *= vector[i];
                    count += 1;
                }
            }
            if (count == 0) Console.WriteLine("Нет нечетных элементов, не делящихся на три.");
            else Console.WriteLine("Произведение равно:" + mult);
        }
        public void SortUp()
        {
            for (int i = 1; i < vector.Length; i++)
            {
                double k = vector[i];
                int j = i - 1;

                while (j >= 0 && vector[j] > k)
                {
                    vector [j + 1] = vector [j];
                    vector [j] = k;
                    j--;
                }
            }
            for (int i = 0; i < vector .Length; i++)
            {
                Console.Write(vector [i] + " ");
            }
            Console.Write("\n");
        }
        public void SortDown()
        {
            for (int i = 1; i < vector.Length; i++)
            {
                double k = vector[i];
                int j = i - 1;

                while (j >= 0 && vector[j] < k)
                {
                    vector[j + 1] = vector[j];
                    vector[j] = k;
                    j--;
                }
            }
            for (int i = 0; i < vector.Length; i++)
            {
                Console.Write(vector[i] + " ");
            }
            Console.Write("\n");
        }                
    }
}
