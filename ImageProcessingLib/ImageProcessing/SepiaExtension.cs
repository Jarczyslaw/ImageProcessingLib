using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class SepiaExtension
    {
        public static Image<Pixel32> Sepia(this Image<Pixel32> image, int level)
        {
            image.ForEach((x, y) =>
            {
                var pixel = image.Get(x, y);
                image.Set(x, y, Sepia(pixel, level));
            });
            return image;
        }

        public static Pixel32 Sepia(Pixel32 pixel, int level)
        {
            var r = MathUtils.ByteClamp(pixel.R + 2 * level);
            var g = MathUtils.ByteClamp(pixel.G + level);
            var b = pixel.B;
            return new Pixel32(pixel.A, r, g, b);
        }
    }
}
