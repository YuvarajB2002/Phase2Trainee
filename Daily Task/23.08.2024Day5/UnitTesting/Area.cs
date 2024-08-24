using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    public class Area
    {
        public double Square(double a)
        {
            return a * a;
        }
        public double Circle(double r)
        {
            return 3.14 * r * r;
        }
        public double Rectangle(double l,double b)
        {
            return l * b;
        }
    }
}
