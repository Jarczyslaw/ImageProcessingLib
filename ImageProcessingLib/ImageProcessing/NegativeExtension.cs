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
                var r = MathUtils.Negative(pixel.R);
                var g = MathUtils.Negative(pixel.G);
                var b = MathUtils.Negative(pixel.B);
                image.Set(x, y, new Pixel32(r, g, b));
            });
        }
    }
}
