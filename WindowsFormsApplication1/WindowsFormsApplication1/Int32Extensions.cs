using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public static class Int32Extensions
    {
        public static Boolean[] ToBooleanArray(this Int32 i)
        {
            Boolean[] ba = new Boolean[8];
            Boolean[] sBa = Convert.ToString(i, 2 /*for binary*/).Select(s => s.Equals('1')).ToArray();
            for (int c = 0; c < 8; c++)
            {
                ba[c] = false;
            }

            for (int c = 0; c < sBa.Length; c++)
            {
                ba[c+(ba.Length - sBa.Length)] = sBa[c];
            }
            return ba;
        }
    }
}
