using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace lr2
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
    }
}
