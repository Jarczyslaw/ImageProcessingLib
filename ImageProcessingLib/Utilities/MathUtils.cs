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
            return Clamp((byte)Math.Round(value));
        }

        public static byte Clamp(int value)
        {
            if (value < 0)
                return 0;
            else if (value > 255)
                return 255;
            else
                return (byte)value;
        }
    }
}
