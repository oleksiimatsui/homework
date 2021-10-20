using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            RightTriangle rt = new RightTriangle(10,20);
            EquilateralTriangle et = new EquilateralTriangle(15);
            
            output.Text += rt.GetScale().ToString() + "\n";
            output.Text += rt.GetPer().ToString() + "\n";

            output.Text += et.GetScale().ToString() + "\n";
            output.Text += et.GetPer().ToString() + "\n";
        }

    }
}
