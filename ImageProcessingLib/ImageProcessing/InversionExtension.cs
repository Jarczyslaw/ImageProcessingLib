using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class InversionExtension
    {
        public static Image<Pixel32> Inversion(this Image<Pixel32> image)
        {
            return image.Inversion(127);
        }

        public static Image<Pixel32> Inversion(this Image<Pixel32> image, byte conversionPoint)
        {
            return image.Inversion(new Pixel32(conversionPoint));
        }

        public static Image<Pixel32> Inversion(this Image<Pixel32> image, Pixel32 conversionPoint)
        {
            image.ForEach((x, y) =>
            {
                var pixel = image.Get(x, y);
                var r = Inversion(pixel.R, conversionPoint.R);
                var g = Inversion(pixel.G, conversionPoint.G);
                var b = Inversion(pixel.B, conversionPoint.B);
                image.Set(x, y, new Pixel32(pixel.A, r, g, b));
            });
            return image;
        }

        public static byte Inversion(byte value, byte conversionPoint)
        {
            var delta = conversionPoint - value;
            return MathUtils.ByteClamp(conversionPoint + delta);
        }
    }
}
