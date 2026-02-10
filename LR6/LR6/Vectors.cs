using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;

namespace LR6
{
    internal class Vectors
    {
        public static void WriteVector(IVectorable v, TextWriter output)
        {
            output.WriteLine(v);
        }
        public static IVectorable ReadVector(TextReader input)
        {
            string? support_string = input.ReadLine();
            string[] str_array_vector = support_string?.Split(' ').ToArray();
            double[] array_vector = new double[str_array_vector.Length];
            for (int i = 0; i < str_array_vector.Length; i++)
            {
                bool check = double.TryParse(str_array_vector[i], out array_vector[i]);
            }
           
            IVectorable output = new ArrayVector(Convert.ToInt32(array_vector[0]));
            for (int i = 0; i < output.Length; i++)
            {
                output[i] = array_vector[i + 1];
            }
            return output;
        }
        public static void Byte_Vector_Write(IVectorable v, BinaryWriter file)
        {
            byte[] byte_vector = new byte[1];
            byte_vector[0] = (byte)v.Length;
            file.Write(byte_vector);
            for(int i = 0; i < v.Length; i++)
            {
                byte[] sup = BitConverter.GetBytes(v[i]);
                file.Write(sup);
            }
           
        }
        public static IVectorable Byte_Vector_Read(BinaryReader file)
        {
            int vector_length = file.ReadByte();
            ArrayVector vector = new ArrayVector(vector_length);
            byte[] sup_array = new byte[vector_length];
            
            for (int i = 0; i < vector_length; i++)
            {
                byte[] sup = new byte[8];
                file.Read(sup);
                vector[i] = BitConverter.ToDouble(sup, 0);
            }
            return vector;
        }
        public static IVectorable Sum(IVectorable v1, IVectorable v2)
        {
            IVectorable v;
            if (v1.Length != v2.Length)
            {

                Console.WriteLine("Длины векторов не совпадают.");
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
