using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class NegativeExtension
    {
        public static Image<Pixel8> Negative(this Image<Pixel8> image)
        {
            Pixel8 pixelOperator(Pixel8 pixel)
            {
                var neg = MathUtils.Negative(pixel.Value);
                return new Pixel8(neg);
            }
            return image.Negative(pixelOperator);
        }

        public static Image<Pixel32> Negative(this Image<Pixel32> image)
        {
            Pixel32 pixelOperator(Pixel32 pixel)
            {
                var r = MathUtils.Negative(pixel.R);
                var g = MathUtils.Negative(pixel.G);
                var b = MathUtils.Negative(pixel.B);
                return new Pixel32(pixel.A, r, g, b);
            }
            return image.Negative(pixelOperator);
        }

        private static Image<TPixelType> Negative<TPixelType>(this Image<TPixelType> image, PixelOperator<TPixelType> pixelOperator)
        {
            image.ForEach((x, y) =>
            {
                var pixel = image.Get(x, y);
                var newPixel = pixelOperator(pixel);
                image.Set(x, y, newPixel);
            });
            return image;
        }
    }
}
