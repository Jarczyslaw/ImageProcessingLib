using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib.ImageProcessing
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
                var grayscale = GrayscaleExtension.Luminance(pixel);
                if (grayscale > threshold)
                    image.Set(x, y, new Pixel32(pixel.A, 255));
                else
                    image.Set(x, y, new Pixel32(pixel.A, 0));
            });
            return image;
        }
    }
}
