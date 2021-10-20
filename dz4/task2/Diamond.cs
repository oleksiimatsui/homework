using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public class Diamond : Figure
    {
        public Diamond(double _a, double _angle)
        {
            a = _a;
            angle = _angle;
            if (check_values(a) == false || check_values(angle) == false || angle > 90)
            {
                throw new ArgumentException(String.Format("wrong parametres"));
            }
        }
        override public double GetPerimeter()
        {
            return a * 4;
        }
        override public double GetScale()
        {
            return a * a * Math.Sin(angle * Math.PI / 180.0);
        }
    }
}

