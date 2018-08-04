using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class InversionExtension
    {
        public static Image<Pixel8> Inversion(this Image<Pixel8> image, byte inversionPoint = 127)
        {
            Pixel8 pixelOperator(Pixel8 pixel)
            {
                var val = Inversion(pixel.Value, inversionPoint);
                return new Pixel8(val);
            };
            return image.Inversion(pixelOperator);
        }

        public static Image<Pixel32> Inversion(this Image<Pixel32> image, byte inversionPoint = 127)
        {
            return image.Inversion(new Pixel32(inversionPoint));
        }

        public static Image<Pixel32> Inversion(this Image<Pixel32> image, Pixel32 inversionPoint)
        {
            Pixel32 pixelOperator(Pixel32 pixel)
            {
                var r = Inversion(pixel.R, inversionPoint.R);
                var g = Inversion(pixel.G, inversionPoint.G);
                var b = Inversion(pixel.B, inversionPoint.B);
                return new Pixel32(pixel.A, r, g, b);
            };
            return image.Inversion(pixelOperator);
        }

        private static Image<TPixelType> Inversion<TPixelType>(this Image<TPixelType> image, PixelOperator<TPixelType> pixelOperator)
            where TPixelType : struct, IPixel<TPixelType>
        {
            image.ForEach((x, y) =>
            {
                var pixel = image.Get(x, y);
                var newPixel = pixelOperator(pixel);
                image.Set(x, y, newPixel);
            });
            return image;
        }

        public static byte Inversion(byte value, byte inversionPoint)
        {
            var delta = inversionPoint - value;
            return MathUtils.ByteClamp(inversionPoint + delta);
        }
    }
}
