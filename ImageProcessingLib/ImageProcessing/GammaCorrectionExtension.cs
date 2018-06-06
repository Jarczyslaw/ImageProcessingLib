using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class GammaCorrectionExtension
    {
        public static Image<Pixel32> GammaCorrection(this Image<Pixel32> image, double gamma)
        {
            image.ForEach((x, y) =>
            {
                var pixel = image.Get(x, y);
                image.Set(x, y, GammaCorrection(pixel, gamma));
            });
            return image;
        }

        public static byte GammaCorrection(byte value, double gamma)
        {
            return MathUtils.RoundToByte(255d * Math.Pow(value / 255d, gamma));
        }

        public static Pixel32 GammaCorrection(Pixel32 pixel, double gamma)
        {
            var r = GammaCorrection(pixel.R, gamma);
            var g = GammaCorrection(pixel.G, gamma);
            var b = GammaCorrection(pixel.B, gamma);
            return new Pixel32(pixel.A, r, g, b);
        }
    }
}
