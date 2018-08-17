using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class GammaCorrectionExtension
    {
        public static Image<Pixel8> GammaCorrection(this Image<Pixel8> image, double gamma)
        {
            Pixel8 pixelOperator(Pixel8 pixel)
            {
                var gs = GammaCorrection(pixel.Value, gamma);
                return new Pixel8(gs);
            }
            return image.GammaCorrection(pixelOperator, gamma);
        }

        public static Image<Pixel32> GammaCorrection(this Image<Pixel32> image, double gamma)
        {
            Pixel32 pixelOperator(Pixel32 pixel)
            {
                var r = GammaCorrection(pixel.R, gamma);
                var g = GammaCorrection(pixel.G, gamma);
                var b = GammaCorrection(pixel.B, gamma);
                return new Pixel32(pixel.A, r, g, b);
            }
            return image.GammaCorrection(pixelOperator, gamma);
        }

        private static Image<TPixelType> GammaCorrection<TPixelType>(this Image<TPixelType> image, PixelOperator<TPixelType> pixelOperator, double gamma)
        {
            image.ForEach((x, y) =>
            {
                var pixel = image.Get(x, y);
                image.Set(x, y, pixelOperator(pixel));
            });
            return image;
        }

        public static byte GammaCorrection(byte value, double gamma)
        {
            return MathUtils.RoundToByte(255d * Math.Pow(value / 255d, gamma));
        }
    }
}
