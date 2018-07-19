using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class PixelsConverter
    {
        public static Pixel8 Pixel32To8(Pixel32 pixel)
        {
            var gs = GrayscaleExtension.Luminance(pixel);
            return new Pixel8(gs);
        }

        public static Pixel32 Pixel8To32(Pixel8 pixel)
        {
            var value = pixel.Value;
            return new Pixel32(value, value, value);
        }
    }
}
