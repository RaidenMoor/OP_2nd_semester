using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR4
{
    internal class ArrayVector : IVectorable
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
                catch(Exception)
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
        public override string ToString()
        {
            string vector_string = "";
            for (int i = 0; i < this.Length; i++) 
            {
                vector_string += this[i].ToString() + " ";
            }
            return $"Число координат вектора: {this.Length} Координаты вектора: {vector_string}";
        }
    }
}
