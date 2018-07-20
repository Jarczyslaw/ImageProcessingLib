using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class BlackAndWhiteExtension
    {
        public static Image<Pixel8> BlackAndWhite(this Image<Pixel8> image)
        {
            return image.BlackAndWhite(127);
        }

        public static Image<Pixel8> BlackAndWhite(this Image<Pixel8> image, byte threshold)
        {
            Pixel8 pixelOperator(Pixel8 pixel)
            {
                if (pixel.Value > threshold)
                    return new Pixel8(255);
                else
                    return new Pixel8(0);
            };
            return image.BlackAndWhite(pixelOperator);
        }

        public static Image<Pixel32> BlackAndWhite(this Image<Pixel32> image)
        {
            return image.BlackAndWhite(127);
        }

        public static Image<Pixel32> BlackAndWhite(this Image<Pixel32> image, byte threshold)
        {
            Pixel32 pixelOperator(Pixel32 pixel)
            {
                var grayscale = GrayscaleExtension.Luminance(pixel);
                if (grayscale > threshold)
                    return new Pixel32(pixel.A, 255);
                else
                    return new Pixel32(pixel.A, 0);
            };
            return image.BlackAndWhite(pixelOperator);
        }

        private static Image<TPixelType> BlackAndWhite<TPixelType>(this Image<TPixelType> image, PixelOperator<TPixelType> pixelOperator)
             where TPixelType : struct, IPixel<TPixelType>
        {
            image.ForEach((x, y) =>
            {
                var pixel = image.Get(x, y);
                var blackAndWhite = pixelOperator(pixel);
                image.Set(x, y, blackAndWhite);
            });
            return image;
        }
    }
}
