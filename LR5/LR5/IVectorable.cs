using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR5
{
    internal interface IVectorable
    {
        double this[int index] { get; set; }
        int Length { get; }
        double GetNorm();
        int CompareTo(object obj);
    }
}
