using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR5
{
    internal class Vectors
    {

        public static IVectorable? Sum(IVectorable v1, IVectorable v2)
        {
            IVectorable v;
            if (v1.Length != v2.Length)
            {

                throw new Exception("Длины векторов не совпадают.");
                v = null;
            }
            else
            {
                v = new ArrayVector(v1.Length);
                for (int i = 0; i < v1.Length; i++)
                {
                    v[i] = v1[i] + v2[i];

                }
            }
            return v;

        }
        public static double? Scalar(IVectorable v1, IVectorable v2)
        {
            double? mult = 0;
            if (v1.Length == v2.Length)
            {
                for (int i = 0; i < v1.Length; i++)
                {
                    mult += v1[i] * v2[i];
                }
            }
            else
            {
                throw new Exception("Длины векторов не совпадают.");
                mult = null;
            }
            return mult;
        }
        public static double GetNorm2(IVectorable v)
        {
            double sum = 0;
            for (int i = 0; i < v.Length; i++)
            {
                sum += v[i] * v[i];
            }
            return Math.Sqrt(sum);
        }
        public static string ToString(IVectorable vector)
        {
            string vector_string = "";
            for (int i = 0; i < vector.Length; i++)
            {
                vector_string += vector[i].ToString() + " ";
            }
            return $"Число координат вектора: {vector.Length} Координаты вектора: {vector_string}";
        }
    }
}
