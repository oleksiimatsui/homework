using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Figures
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Square sq1 = new Square(5);

            Circle circ1 = new Circle(5);

            Triangle tr1 = new Triangle(5, 5, 5);

            Rectangle rec1 = new Rectangle(5, 5);

            Diamond d1 = new Diamond(5, 15);

            mylab.Text = "square scale " + sq1.GetScale() + "\n";
            mylab.Text += "square perimeter " + sq1.GetPerimeter() + "\n";

            mylab.Text += "circle scale " + circ1.GetScale() + "\n";
            mylab.Text += "circle perimeter " + circ1.GetPerimeter() + "\n";

            mylab.Text += "Triangle scale " + tr1.GetScale() + "\n";
            mylab.Text += "Triangle perimeter " + tr1.GetPerimeter() + "\n";

            mylab.Text += "Rectangle scale " + rec1.GetScale() + "\n";
            mylab.Text += "Rectangle perimeter " + rec1.GetPerimeter() + "\n";

            mylab.Text += "Diamond scale " + d1.GetScale() + "\n";
            mylab.Text += "Diamond perimeter " + d1.GetPerimeter() + "\n";
        }
    }
}
