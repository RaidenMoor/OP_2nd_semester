using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr2
{
    internal class Vectors
    {
        public static ArrayVector? Sum(ArrayVector v1, ArrayVector v2)
        {
            ArrayVector v = new ArrayVector(v1.Lenght);
            if (v1.Lenght != v2.Lenght)
            {
                throw new Exception("Длины векторов не совпадают.");
                v = null;
            }
            else
            {
                for (int i = 0; i < v1.Lenght; i++)
                {
                    v.SetElement(i, v1.GetElement(i) + v2.GetElement(i));
                    
                }
            }
            return v;
           
        }
        public static double? Scalar(ArrayVector v1, ArrayVector v2)
        {
            double? mult = 0;
            if (v1.Lenght == v2.Lenght)
            {
                for (int i = 0; i < v1.Lenght; i++)
                {
                    mult += v1.GetElement(i) * v2.GetElement(i);
                }
            }
            else
            {
                throw new Exception("Длины векторов не совпадают.");
                mult = null;
            }
            return mult;
        }
        public static double GetNorm2(ArrayVector v)
        {
            double sum = 0;
            for (int i = 0; i < v.Lenght; i++)
            {
                sum += v.GetElement(i) * v.GetElement(i);
            }
            return Math.Sqrt(sum);
        }
        public static void OutputVector(ArrayVector vector, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(vector.GetElement(i) + " ");
            }
        }
    }
}
