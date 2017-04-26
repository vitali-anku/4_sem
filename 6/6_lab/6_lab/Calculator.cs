using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_lab
{
    class Calculator
    {
        public int Sum(int a, int b)
        {
            return a + b;
        }

        public int Razn(int a, int b)
        {
            return a * b;
        }

        public int Umn(int a, int b)
        {
            return a * b;
        }

        public double Del(int a, int b)
        {
            double d;
            d = Convert.ToDouble(a / b);
            return d;
        }

        public UInt32 Step(int a, int b)
        {
            UInt32 step;
            step = Convert.ToUInt32(a ^ b);
            return step;
        }
    }
}
