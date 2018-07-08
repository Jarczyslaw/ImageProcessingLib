using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class ErrorMetrics
    {
        public static double MSE(Image<Pixel32> originalImage, Image<Pixel32> image)
        {
            return MSE(originalImage, image, 0, 0, originalImage.Width, originalImage.Height);
        }

        public static double MSE(Image<Pixel32> originalImage, Image<Pixel32> image, int x, int y, int width, int height)
        {
            if (originalImage.Width != image.Width || originalImage.Height != image.Height)
                throw new ArgumentException("Can not calculate metrics for images with different sizes");

            var errorR = 0d;
            var errorG = 0d;
            var errorB = 0d;
            image.ForBlock(x, y, width, height, (i, j) =>
            {
                var originalPixel = originalImage.Get(i, j);
                var pixel = image.Get(i, j);
                errorR += Math.Pow(originalPixel.R - pixel.R, 2d);
                errorG += Math.Pow(originalPixel.G - pixel.G, 2d);
                errorB += Math.Pow(originalPixel.B - pixel.B, 2d);
            });
            return (errorR + errorG + errorB) / (image.Size * 3d);
        }

        public static double PSNR(Image<Pixel32> originalImage, Image<Pixel32> image)
        {
            return PSNR(originalImage, image, out double mse);
        }

        public static double PSNR(Image<Pixel32> originalImage, Image<Pixel32> image, out double mse)
        {
            mse = MSE(originalImage, image, 0, 0, originalImage.Width, originalImage.Height);
            return PSNRFromMSE(mse);
        }

        public static double PSNR(Image<Pixel32> originalImage, Image<Pixel32> image, int x, int y, int width, int height)
        {
            return PSNR(originalImage, image, x, y, width, height, out double mse);
        }

        public static double PSNR(Image<Pixel32> originalImage, Image<Pixel32> image, int x, int y, int width, int height, out double mse)
        {
            mse = MSE(originalImage, image, x, y, width, height);
            return PSNRFromMSE(mse);
        }

        private static double PSNRFromMSE(double mse)
        {
            return 10d * Math.Log10(255d * 255d / mse);
        }
    }
}
