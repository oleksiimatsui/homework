using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public class Circle : Figure
    {
        public Circle(double _r)
        {
            r = _r;
            if (check_values(r) == false)
            {
                throw new ArgumentException(String.Format("wrong parametres"));
            }
        }
        private double r;

        override public double GetPerimeter()
        {
            return 2 * Math.PI * r;
        }
        override public double GetScale()
        {
            return Math.PI * r * r;
        }
    }
}

