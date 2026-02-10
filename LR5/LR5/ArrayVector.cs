using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR5
{
    internal class ArrayVector : IVectorable, IComparable, ICloneable
    {
        private double[] vector;
        public ArrayVector() : this(5)
        {
        }
        public ArrayVector(int n)
        {
            vector = new double[n];
        }
        public double this[int index]
        {
            get
            {
                try
                {
                    return vector[index];
                }
                catch (Exception)
                {
                    Console.WriteLine("Вы ввели неверный индекс.");
                    return 0;
                }
            }
            set
            {
                try
                {
                    vector[index] = value;
                }
                catch (Exception)
                {
                    Console.WriteLine("Вы ввели неверный индекс.");
                }
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
        public int Length
        {
            get { return vector.Length; }

        }
        public double[] SortUp()
        {
            for (int i = 1; i < vector.Length; i++)
            {
                double k = vector[i];
                int j = i - 1;

                while (j >= 0 && vector[j] > k)
                {
                    vector[j + 1] = vector[j];
                    vector[j] = k;
                    j--;
                }
            }
            return vector;
        }
        public override string ToString()
        {
            string vector_string = "";
            for (int i = 0; i < this.Length; i++)
            {
                vector_string += this[i].ToString() + " ";
            }
            return $"Число координат вектора: {this.Length} Координаты вектора: {vector_string}";
        }
        public override bool Equals(object obj)
        {
            IVectorable v = (IVectorable)obj;
            int k = 0;
            for (int i = 0; i < Length; i++)
            {
                if (this[i] == v[i])
                    k++;
            }
            if ((this.Length == v.Length) && (k == v.Length))
                return true;
            else return false;
        }
        public int CompareTo(object obj)
        {
            IVectorable v = (IVectorable)obj;
            if (v == null)
            {
                throw new ArgumentException("Объект не вектор.");
            }
            else
            {
                if (this.Length > v.Length) return 1;
                else if (this.Length < v.Length) return -1;
                else return 0;
            }
        }
        public override int GetHashCode()
        {
            return vector.GetHashCode();
        }
        public object Clone()
        {
            ArrayVector clone = new ArrayVector(Length);
            for (int i = 0; i < Length; i++)
            {
                clone[i] = vector[i];
            }
            return clone;
        }
    }
}
