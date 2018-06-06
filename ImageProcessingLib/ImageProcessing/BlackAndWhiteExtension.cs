using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class BlackAndWhiteExtension
    {
        public static Image<Pixel32> BlackAndWhite(this Image<Pixel32> image)
        {
            return image.BlackAndWhite(127);
        }

        public static Image<Pixel32> BlackAndWhite(this Image<Pixel32> image, byte threshold)
        {
            image.ForEach((x, y) =>
            {
                var pixel = image.Get(x, y);
                var blackAndWhite = BlackAndWhite(pixel, threshold);
                image.Set(x, y, blackAndWhite);
            });
            return image;
        }

        public static Pixel32 BlackAndWhite(Pixel32 pixel, byte threshold)
        {
            var grayscale = GrayscaleExtension.Luminance(pixel);
            if (grayscale > threshold)
                return new Pixel32(pixel.A, 255);
            else
                return new Pixel32(pixel.A, 0);
        }
    }
}
