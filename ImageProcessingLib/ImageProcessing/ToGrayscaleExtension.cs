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
        public static Image24 ToGrayscale(this Image24 img, ToGrayscaleMethod method = ToGrayscaleMethod.Luminance)
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

        private static void ByLuminance(Image24 img)
        {
            img.ForEach((x, y) =>
            {
                var rgb = img.Get(x, y);
                var grayscale = MathUtils.RoundToByte(0.3d * rgb.R + 0.59d * rgb.G + 0.11d * rgb.B);
                img.Set(x, y, grayscale);
            });
        }

        private static void ByLightness(Image24 img)
        {
            img.ForEach((x, y) =>
            {
                var rgb = img.Get(x, y);
                var max = MathUtils.Max(rgb.R, rgb.G, rgb.B);
                var min = MathUtils.Min(rgb.R, rgb.G, rgb.B);
                var grayscale = MathUtils.RoundToByte(0.5d * (max + min));
                img.Set(x, y, grayscale);
            });
        }

        private static void ByAverage(Image24 img)
        {
            double q = 1d / 3d;
            img.ForEach((x, y) =>
            {
                var rgb = img.Get(x, y);
                var grayscale = MathUtils.RoundToByte(q * (rgb.R + rgb.G + rgb.B));
                img.Set(x, y, grayscale);
            });
        }
    }
}
