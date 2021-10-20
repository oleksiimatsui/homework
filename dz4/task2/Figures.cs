using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    abstract public class Figure
    {
        protected double a;
        protected double b;
        protected double c;
        protected double r;
        protected double angle;
        abstract public double GetPerimeter();
        abstract public double GetScale();
        protected bool check_values(double a) 
        {
            if (a > 0) return true;
            else return false;
        }
    }
}
