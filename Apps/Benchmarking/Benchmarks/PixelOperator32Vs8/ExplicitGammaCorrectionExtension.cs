using ImageProcessingLib;
using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmarking.Benchmarks
{
    public static class ExplicitGammaCorrectionExtension
    {
        public static byte ExplicitGammaCorrection(byte value, double gamma)
        {
            return MathUtils.RoundToByte(255d * Math.Pow(value / 255d, gamma));
        }

        public static Image<Pixel32> ExplicitGammaCorrection(this Image<Pixel32> image, double gamma)
        {
            image.ForEach((x, y) =>
            {
                var pixel = image.Get(x, y);
                var r = ExplicitGammaCorrection(pixel.R, gamma);
                var g = ExplicitGammaCorrection(pixel.G, gamma);
                var b = ExplicitGammaCorrection(pixel.B, gamma);
                image.Set(x, y, new Pixel32(pixel.A, r, g, b));
            });
            return image;
        }
    }
}
