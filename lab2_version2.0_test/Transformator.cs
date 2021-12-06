using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;

namespace StaffGetter
{
    static class Transformator
    {
        public static void Transform()
        {
            // Завантаження стилів
            XslCompiledTransform xslt = new XslCompiledTransform();
            string styles = Links.Xsl;
            string f2 = Links.Xml;
            string f3 = Links.Html;

            xslt.Load(styles);
            // Виконання перетворення і виведення результатів у файл.
            xslt.Transform(f2, f3);
        }
    }
}
