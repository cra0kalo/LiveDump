using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveDump
{
    public static class Utilities
    {

        public static string ToHex(int decval)
        {
            return decval.ToString("X");
        }

        public static string ToHexPID(int decval)
        {
            return decval.ToString("X8");
        }

        static public Int32 ToDec(string hexval)
        {
            return Convert.ToInt32(hexval, 16);
        }

        static public Int64 ToDec64(string hexval)
        {
            return Convert.ToInt64(hexval, 16);
        }

    }
}
