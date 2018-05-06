using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib.ImageProcessing
{
    public static class ColorFiltrationExtension
    {
        public static Image<Pixel32> ColorFiltration(this Image<Pixel32> image, ColorFilter filter)
        {
            var mask = GetColorFilterMask(filter);
            image.ForEach((x, y) =>
            {
                var pixel = image.Get(x, y);
                image.Set(x, y, ApplyColorFilter(pixel, filter));
            });
            return image;
        }

        public static Pixel32 ApplyColorFilter(Pixel32 pixel, ColorFilter filter)
        {
            var newData = pixel.Data & GetColorFilterMask(filter);
            return new Pixel32(newData);
        }

        public static int GetColorFilterMask(ColorFilter filter)
        {
            switch (filter)
            {
                case ColorFilter.Magenta:
                    return 0xFF << 24 | 0xFF << 16 | 0xFF;
                case ColorFilter.Yellow:
                    return 0xFF << 24 | 0xFF << 16 | 0xFF << 8;
                case ColorFilter.Cyan:
                    return 0xFF << 24 | 0xFF << 8 | 0xFF;
                case ColorFilter.Red:
                    return 0xFF << 24 | 0xFF << 16;
                case ColorFilter.Green:
                    return 0xFF << 24 | 0xFF << 8;
                case ColorFilter.Blue:
                    return 0xFF << 24 | 0xFF;
                default:
                    return 0xFF << 24 | 0xFF << 16 | 0xFF << 8 | 0xFF;
            }
        }
    }
}
