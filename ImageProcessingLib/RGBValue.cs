using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLib
{
    public class RGBValue
    {
        public byte r;
        public byte g;
        public byte b;

        public RGBValue() { }

        public RGBValue(byte value)
        {
            Set(value);
        }

        public RGBValue(byte r, byte g, byte b)
        {
            Set(r, g, b);
        }

        public void Set(byte value)
        {
            Set(value, value, value);
        }

        public void Set(byte r, byte g, byte b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }

        public bool IsInGrayscale()
        {
            return r == b && b == g;
        }

        public bool IsBlackOrWhite()
        {
            return IsBlack() || IsWhite();
        }

        public bool IsBlack()
        {
            return r == 0 && g == 0 && b == 0; 
        }

        public bool IsWhite()
        {
            return r == 255 && g == 255 && b == 255;
        }
    }
}
