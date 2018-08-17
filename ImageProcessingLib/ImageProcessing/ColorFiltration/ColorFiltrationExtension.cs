using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class ColorFiltrationExtension
    {
        public static Image<Pixel32> ColorFiltration(this Image<Pixel32> image, ColorFilter filter)
        {
            image.ForEach((x, y) =>
            {
                var pixel = image.Get(x, y);
                image.Set(x, y, ApplyColorFilter(pixel, filter));
            });
            return image;
        }

        public static Pixel32 ApplyColorFilter(Pixel32 pixel, ColorFilter filter)
        {
            switch (filter)
            {
                case ColorFilter.Magenta:
                    return new Pixel32(pixel.A, pixel.R, 0, pixel.B);
                case ColorFilter.Yellow:
                    return new Pixel32(pixel.A, pixel.R, pixel.G, 0);
                case ColorFilter.Cyan:
                    return new Pixel32(pixel.A, 0, pixel.G, pixel.B);
                case ColorFilter.Red:
                    return new Pixel32(pixel.A, pixel.R, 0, 0);
                case ColorFilter.Green:
                    return new Pixel32(pixel.A, 0, pixel.G, 0);
                case ColorFilter.Blue:
                    return new Pixel32(pixel.A, 0, 0, pixel.B);
                default:
                    return pixel;
            }
        }
    }
}
