using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class ErrorMetrics
    {
        public static double MSE(Image<Pixel32> originalImage, Image<Pixel32> image)
        {
            if (originalImage.Width != image.Width || originalImage.Height != image.Height)
                throw new ArgumentException("Can not calculate metrics for images with different sizes");

            var errorR = 0d;
            var errorG = 0d;
            var errorB = 0d;
            image.ForEach((x, y) =>
            {
                var originalPixel = originalImage.Get(x, y);
                var pixel = image.Get(x, y);
                errorR += Math.Pow(originalPixel.R - pixel.R , 2d);
                errorG += Math.Pow(originalPixel.G - pixel.G, 2d);
                errorB += Math.Pow(originalPixel.B - pixel.B, 2d);
            });
            return (errorR + errorG + errorB) / (image.Width * image.Height * 3);
        }

        public static double PSNR(Image<Pixel32> originalImage, Image<Pixel32> image)
        {
            return 10d * Math.Log10(255d * 255d / MSE(originalImage, image));
        }
    }
}
