using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLib.Utilities
{
    public class MathUtils
    {
        public static byte RoundToByte(double value)
        {
            return (byte)Math.Round(value);
        }

        public static byte Max(byte val1, byte val2, byte val3)
        {
            return Math.Max(val1, Math.Max(val2, val3));
        }

        public static byte Min(byte val1, byte val2, byte val3)
        {
            return Math.Min(val1, Math.Min(val2, val3));
        }
    }
}
