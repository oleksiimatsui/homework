using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public class Rectangle : Figure
    {
        public Rectangle(double _a, double _b)
        {
            a = _a;
            b = _b;
            if (check_values(a) == false || check_values(b) == false)
            {
                throw new ArgumentException(String.Format("wrong parametres"));
            }
        }
        override public double GetPerimeter()
        {
            return a * 2 + b * 2;
        }
        override public double GetScale()
        {
            return a * b;
        }
    }
}
