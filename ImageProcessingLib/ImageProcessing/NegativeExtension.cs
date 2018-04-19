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
            return image.ForEach((x, y, pixel) =>
            {
                var r = MathUtils.Negative(pixel.R);
                var g = MathUtils.Negative(pixel.G);
                var b = MathUtils.Negative(pixel.B);
                return new Pixel32(pixel.A, r, g, b);
            });
        }
    }
}
