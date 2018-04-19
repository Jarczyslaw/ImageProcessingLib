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
        public static Image<Pixel32> ToGrayscale(this Image<Pixel32> img, ToGrayscaleMethod method = ToGrayscaleMethod.Luminance)
        {
            switch (method)
            {
                case ToGrayscaleMethod.Average:
                    ByAverage(img);
                    break;
                case ToGrayscaleMethod.Lightness:
                    ByLightness(img);
                    break;
                case ToGrayscaleMethod.Luminance:
                    ByLuminance(img);
                    break;
            }
            return img;
        }

        private static void ByLuminance(Image<Pixel32> img)
        {
            img.ForEach((x, y, pixel) =>
            {
                var grayscale = MathUtils.RoundToByte(0.3d * pixel.R + 0.59d * pixel.G + 0.11d * pixel.B);
                return new Pixel32(grayscale);
            });
        }

        private static void ByLightness(Image<Pixel32> img)
        {
            img.ForEach((x, y, pixel) =>
            {
                var max = MathUtils.Max(pixel.R, pixel.G, pixel.B);
                var min = MathUtils.Min(pixel.R, pixel.G, pixel.B);
                var grayscale = MathUtils.RoundToByte(0.5d * (max + min));
                return new Pixel32(grayscale);
            });
        }

        private static void ByAverage(Image<Pixel32> img)
        {
            double q = 1d / 3d;
            img.ForEach((x, y, pixel) =>
            {
                var grayscale = MathUtils.RoundToByte(q * (pixel.R + pixel.G + pixel.B));
                return new Pixel32(grayscale);
            });
        }
    }
}
