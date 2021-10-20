using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Triangle tr = new Triangle(7, 4, 3);
            tr.GetAngles();
            EquilateralTriangle tr1 = new EquilateralTriangle(10);
            tr1.GetScale();
            List<double> angles = tr.GetAngles();

            label1.Text = "\n";
            for ( int i=0; i<3; i++)
            label1.Text += "angle " + i + ": " + angles[i].ToString() + "\n";
        }


    }
}
