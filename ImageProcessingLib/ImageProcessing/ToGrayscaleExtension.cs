using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLib.ImageProcessing
{
    public static class ToGrayscaleExtension
    {
        public static Image<Pixel32> ToGrayscale(this Image<Pixel32> image, ToGrayscaleMethod method = ToGrayscaleMethod.Luminance)
        {
            switch (method)
            {
                case ToGrayscaleMethod.Average:
                    ByAverage(image);
                    break;
                case ToGrayscaleMethod.Lightness:
                    ByLightness(image);
                    break;
                case ToGrayscaleMethod.Luminance:
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
                var grayscale = MathUtils.RoundToByte(0.3d * pixel.R + 0.59d * pixel.G + 0.11d * pixel.B);
                image.Set(x, y, new Pixel32(grayscale));
            });
        }

        private static void ByLightness(Image<Pixel32> image)
        {
            image.ForEach((x, y) =>
            {
                var pixel = image.Get(x, y);
                var max = MathUtils.Max(pixel.R, pixel.G, pixel.B);
                var min = MathUtils.Min(pixel.R, pixel.G, pixel.B);
                var grayscale = MathUtils.RoundToByte(0.5d * (max + min));
                image.Set(x, y, new Pixel32(grayscale));
            });
        }

        private static void ByAverage(Image<Pixel32> image)
        {
            double q = 1d / 3d;
            image.ForEach((x, y) =>
            {
                var pixel = image.Get(x, y);
                var grayscale = MathUtils.RoundToByte(q * (pixel.R + pixel.G + pixel.B));
                image.Set(x, y, new Pixel32(grayscale));
            });
        }
    }
}
