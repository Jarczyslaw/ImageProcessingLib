using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLib
{
    public static class GrayscaleExtension
    {
        public static Image<Pixel32> Grayscale(this Image<Pixel32> image, GrayscaleMethod method = GrayscaleMethod.Luminance)
        {
            Func<Pixel32, byte> pixelOperator = null;
            switch (method)
            {
                case GrayscaleMethod.Average:
                    pixelOperator = Average;
                    break;
                case GrayscaleMethod.Lightness:
                    pixelOperator = Lightness;
                    break;
                default:
                    pixelOperator = Luminance;
                    break;
            }
            image.Grayscale(pixelOperator);
            return image;
        }

        public static byte Average(Pixel32 pixel)
        {
            double q = 1d / 3d;
            return MathUtils.RoundToByte(q * (pixel.R + pixel.G + pixel.B));
        }

        public static byte Luminance(Pixel32 pixel)
        {
            return MathUtils.RoundToByte(0.3d * pixel.R + 0.59d * pixel.G + 0.11d * pixel.B);
        }

        public static byte Lightness(Pixel32 pixel)
        {
            var max = MathUtils.Max(pixel.R, pixel.G, pixel.B);
            var min = MathUtils.Min(pixel.R, pixel.G, pixel.B);
            return MathUtils.RoundToByte(0.5d * (max + min));
        }

        private static void Grayscale(this Image<Pixel32> image, Func<Pixel32, byte> pixelOperator)
        {
            image.ForEach((x, y) =>
            {
                var pixel = image.Get(x, y);
                var grayscale = pixelOperator(pixel);
                image.Set(x, y, new Pixel32(grayscale));
            });
        }
    }
}
