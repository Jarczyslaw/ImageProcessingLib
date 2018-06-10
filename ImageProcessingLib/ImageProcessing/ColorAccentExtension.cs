using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class ColorAccentExtension
    {
        public static Image<Pixel32> ColorAccent(this Image<Pixel32> image, double hue, double hueRange)
        {
            var h1 = (hue - hueRange / 2d + 360d) % 360d;
            var h2 = (hue + hueRange / 2d + 360d) % 360d;
            image.ForEach((x, y) =>
            {
                var pixel = image.Get(x, y);
                var pixelHue = pixel.ToHSV().Hue;

                bool toGrayscale = false;
                if (h1 <= h2)
                {
                    if (pixelHue < h1 || pixelHue > h2)
                        toGrayscale = true;
                }
                else
                {
                    if (pixelHue < h1 && pixelHue > h2)
                        toGrayscale = true;
                }

                if (toGrayscale)
                {
                    var grayscale = GrayscaleExtension.Luminance(pixel);
                    image.Set(x, y, new Pixel32(pixel.A, grayscale));
                }
            });
            return image;
        }

        public static Image<Pixel32> ColorAccent(this Image<Pixel32> image, Pixel32 color, double hueRange)
        {
            return image.ColorAccent(color.ToHSV().Hue, hueRange);
        }
    }
}
