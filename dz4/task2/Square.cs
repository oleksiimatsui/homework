using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public class Square:Rectangle
    {
        public Square(double _a) : base(_a, _a)
        {

        }
        
        override public double GetPerimeter()
        {
            return a * 4;
        }
        override public double GetScale()
        {
            return a * a;
        }
    }
}

