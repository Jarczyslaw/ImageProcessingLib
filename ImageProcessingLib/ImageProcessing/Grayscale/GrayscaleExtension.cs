using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLib.ImageProcessing
{
    public static class GrayscaleExtension
    {
        public static Image<Pixel32> Grayscale(this Image<Pixel32> image, GrayscaleMethod method = GrayscaleMethod.Luminance)
        {
            switch (method)
            {
                case GrayscaleMethod.Average:
                    ByAverage(image);
                    break;
                case GrayscaleMethod.Lightness:
                    ByLightness(image);
                    break;
                case GrayscaleMethod.Luminance:
                    ByLuminance(image);
                    break;
            }
            return image;
        }

        private static void ByLuminance(Image<Pixel32> image)
        {
            image.ForEach((x, y) =>
            {
                var pixel = image.Get(x, y);
                var grayscale = Luminance(pixel);
                image.Set(x, y, new Pixel32(grayscale));
            });
        }

        public static byte Luminance(Pixel32 pixel)
        {
            return MathUtils.RoundToByte(0.3d * pixel.R + 0.59d * pixel.G + 0.11d * pixel.B);
        }

        private static void ByLightness(Image<Pixel32> image)
        {
            image.ForEach((x, y) =>
            {
                var pixel = image.Get(x, y);
                var grayscale = Lightness(pixel);
                image.Set(x, y, new Pixel32(grayscale));
            });
        }

        public static byte Lightness(Pixel32 pixel)
        {
            var max = MathUtils.Max(pixel.R, pixel.G, pixel.B);
            var min = MathUtils.Min(pixel.R, pixel.G, pixel.B);
            return MathUtils.RoundToByte(0.5d * (max + min));
        }

        private static void ByAverage(Image<Pixel32> image)
        {
            image.ForEach((x, y) =>
            {
                var pixel = image.Get(x, y);
                var grayscale = Average(pixel);
                image.Set(x, y, new Pixel32(grayscale));
            });
        }

        public static byte Average(Pixel32 pixel)
        {
            double q = 1d / 3d;
            return MathUtils.RoundToByte(q * (pixel.R + pixel.G + pixel.B));
        }
    }
}
