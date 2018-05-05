using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib.ImageProcessing
{
    public static class InverseExtension
    {
        public static Image<Pixel32> Inverse(this Image<Pixel32> image)
        {
            return image.Inverse(127);
        }

        public static Image<Pixel32> Inverse(this Image<Pixel32> image, byte conversionPoint)
        {
            return image.Inverse(new Pixel32(conversionPoint));
        }

        public static Image<Pixel32> Inverse(this Image<Pixel32> image, Pixel32 conversionPoint)
        {
            image.ForEach((x, y) =>
            {
                var pixel = image.Get(x, y);
                var r = Inverse(pixel.R, conversionPoint.R);
                var g = Inverse(pixel.G, conversionPoint.G);
                var b = Inverse(pixel.B, conversionPoint.B);
                image.Set(x, y, new Pixel32(pixel.A, r, g, b));
            });
            return image;
        }

        public static byte Inverse(byte value, byte conversionPoint)
        {
            var delta = conversionPoint - value;
            return MathUtils.ByteClamp(conversionPoint + delta);
        }
    }
}
