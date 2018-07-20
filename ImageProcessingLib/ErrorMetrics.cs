using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class ErrorMetrics
    {
        public delegate double PixelMSEOperator<TPixelType>(TPixelType originalPixel, TPixelType pixel);

        public static double MSE(Image<Pixel8> originalImage, Image<Pixel8> image)
        {
            return MSE(originalImage, image, 0, 0, originalImage.Width, originalImage.Height);
        }

        public static double MSE(Image<Pixel8> originalImage, Image<Pixel8> image, int x, int y, int width, int height)
        {
            double pixelOperator(Pixel8 originalPixel, Pixel8 pixel)
            {
                return Math.Pow(originalPixel.Value - pixel.Value, 2d);
            };
            return MSE(originalImage, image, pixelOperator, 3d, x, y, width, height);
        }

        public static double PSNR(Image<Pixel8> originalImage, Image<Pixel8> image)
        {
            return PSNR(originalImage, image, out double mse);
        }

        public static double PSNR(Image<Pixel8> originalImage, Image<Pixel8> image, out double mse)
        {
            mse = MSE(originalImage, image, 0, 0, originalImage.Width, originalImage.Height);
            return PSNRFromMSE(mse);
        }

        public static double PSNR(Image<Pixel8> originalImage, Image<Pixel8> image, int x, int y, int width, int height)
        {
            return PSNR(originalImage, image, x, y, width, height, out double mse);
        }

        public static double PSNR(Image<Pixel8> originalImage, Image<Pixel8> image, int x, int y, int width, int height, out double mse)
        {
            mse = MSE(originalImage, image, x, y, width, height);
            return PSNRFromMSE(mse);
        }

        public static double MSE(Image<Pixel32> originalImage, Image<Pixel32> image)
        {
            return MSE(originalImage, image, 0, 0, originalImage.Width, originalImage.Height);
        }

        public static double MSE(Image<Pixel32> originalImage, Image<Pixel32> image, int x, int y, int width, int height)
        {
            double pixelOperator(Pixel32 originalPixel, Pixel32 pixel)
            {
                var error = 0d;
                error += Math.Pow(originalPixel.R - pixel.R, 2d);
                error += Math.Pow(originalPixel.G - pixel.G, 2d);
                error += Math.Pow(originalPixel.B - pixel.B, 2d);
                return error;
            };
            return MSE(originalImage, image, pixelOperator, 3d, x, y, width, height);
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

        public static double MSE<TPixelType>(Image<TPixelType> originalImage, Image<TPixelType> image, PixelMSEOperator<TPixelType> pixelOperator, double divider,
            int x, int y, int width, int height)
            where TPixelType : struct, IPixel<TPixelType>
        {
            Validate(originalImage, image);

            var error = 0d;
            image.ForBlock(x, y, width, height, (i, j) =>
            {
                var originalPixel = originalImage.Get(i, j);
                var pixel = image.Get(i, j);
                error += pixelOperator(originalPixel, pixel);
            });
            return (error) / (image.Size * divider);
        }

        private static void Validate<TPixelType>(Image<TPixelType> originalImage, Image<TPixelType> image)
            where TPixelType : struct, IPixel<TPixelType>
        {
            if (originalImage.Width != image.Width || originalImage.Height != image.Height)
                throw new ArgumentException("Can not calculate metrics for images with different sizes");
        }

        private static double PSNRFromMSE(double mse)
        {
            return 10d * Math.Log10(255d * 255d / mse);
        }
    }
}
