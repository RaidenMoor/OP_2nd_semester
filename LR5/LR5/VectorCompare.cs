using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR5
{
    internal class VectorCompare : IComparer <object>
    {
        public int Compare(object obj_1, object obj_2)
        {
            IVectorable v1 = (IVectorable)obj_1;
            IVectorable v2 = (IVectorable)obj_2;
            if (v1 != null && v2 != null)
            {
                if (v1.GetNorm() > v2.GetNorm())
                    return 1;
                if (v1.GetNorm() < v2.GetNorm())
                    return -1;
                else
                    return 0;
            }
            else throw new ArgumentException("Объект не вектор.");
        }
    }
}
