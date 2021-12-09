using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffGetter
{
    public static class NullGetter
    {
        static public string NullIfSecondIsNotNull(string a, string b)
        {
            if (b != null) return null;
            else return a;
        }
    }
}
