using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PrototypeFigure
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            IFigure figure = new Rectangle(10, 20);
            IFigure clonedFigure = figure.Clone();
            figure.GetInfo();
            clonedFigure.GetInfo();

            figure = new Circle(15);
            clonedFigure = figure.Clone();
            figure.GetInfo();
            clonedFigure.GetInfo();

            try
            {
                figure = new Triangle(10, 12, 9);
                clonedFigure = figure.Clone();
                figure.GetInfo();
                clonedFigure.GetInfo();
            }
            catch
            {
                Console.WriteLine("wrong parametrs");
            }
            
            Console.Read();
        }
    }
    interface IFigure
    {
        IFigure Clone();
        void GetInfo();
    }

    class Rectangle : IFigure
    {
        int width;
        int height;
        public Rectangle(int w, int h)
        {
            width = w;
            height = h;
        }
        public IFigure Clone()
        {
            return new Rectangle(this.width, this.height);
        }
        public void GetInfo()
        {
            Console.WriteLine("Прямокутник довжиною {0} и шириною {1}", height, width);
        }
    }

    class Triangle : IFigure
    {
        int a;
        int b;
        int c;
        public Triangle(int _a, int _b, int _c)
        {
            if (_a + _b <= _c || _c + _a <= _b || _b + _c <= _a)
            {
                throw new ArgumentException();
            }
            else
            {
                a = _a;
                b = _b;
                c = _c;
            }
        }
    public IFigure Clone()
    {
        return new Triangle(this.a, this.b, this.c);
    }
    public void GetInfo()
    {
        Console.WriteLine("Трикутник з сторонами {0} {1} {2}", a, b, c);
    }
}

    class Circle : IFigure
{
        int radius;
        public Circle(int r)
        {
            radius = r;
        }
        public IFigure Clone()
        {
            return new Circle(this.radius);
        }
        public void GetInfo()
        {
            Console.WriteLine("Круг радіусом {0}", radius);
        }
    }
}