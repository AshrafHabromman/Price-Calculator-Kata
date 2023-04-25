using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata
{
    public static class Float
    {
        public static float Round(this float value, int precision)
        {
            return (float)Math.Round(value, precision);
        }
    }
}
