using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib.ImageProcessing
{
    public static class NegativeExtension
    {
        public static Image<Pixel32> Negative(this Image<Pixel32> image)
        {
            return image.ForEach((x, y) =>
            {
                var pixel = image.Get(x, y);
                var r = Negative(pixel.R);
                var g = Negative(pixel.G);
                var b = Negative(pixel.B);
                image.Set(x, y, new Pixel32(pixel.A, r, g, b));
            });
        }

        public static byte Negative(byte value)
        {
            return (byte)(255 - value);
        }
    }
}
