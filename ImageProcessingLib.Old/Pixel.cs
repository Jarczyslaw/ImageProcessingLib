using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLib.Old
{
    public class Pixel
    {
        public byte r;
        public byte g;
        public byte b;

        public Pixel() { }

        public Pixel(byte r, byte g, byte b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }

        public void Set(byte r, byte g, byte b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }

        public void Set(byte value)
        {
            r = g = b = value;
        }

        public bool IsInGrayscale()
        {
            return (r == g && g == b);
        }

        public bool CompareTo(Pixel pixel)
        {
            return (r == pixel.r && g == pixel.g && b == pixel.b);
        }
    }
}
