using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class NoiseExtension
    {
        private static RandomEx random = new RandomEx();

        public static Image<Pixel8> AddUniformNoise(this Image<Pixel8> image, double intensity, int range)
        {
            Pixel8 pixelOperator(Pixel8 pixel)
            {
                var val = MathUtils.ByteClamp(pixel.Value + random.Next(-range, range));
                return new Pixel8(val);
            };
            return image.Noise(pixelOperator, intensity);
        }

        public static Image<Pixel8> AddGaussianNoise(this Image<Pixel8> image, double intensity, double stdDev)
        {
            return image.AddGaussianNoise(intensity, 0d, stdDev);
        }

        public static Image<Pixel8> AddGaussianNoise(this Image<Pixel8> image, double intensity, double meanValue, double stdDev)
        {
            Pixel8 pixelOperator(Pixel8 pixel)
            {
                var val = MathUtils.ByteClamp(pixel.Value + random.NextGaussian(meanValue, stdDev));
                return new Pixel8(val);
            };
            return image.Noise(pixelOperator, intensity);
        }

        public static Image<Pixel32> AddUniformNoise(this Image<Pixel32> image, double intensity, int range)
        {
            Pixel32 pixelOperator(Pixel32 pixel)
            {
                var r = MathUtils.ByteClamp(pixel.R + random.Next(-range, range));
                var g = MathUtils.ByteClamp(pixel.G + random.Next(-range, range));
                var b = MathUtils.ByteClamp(pixel.B + random.Next(-range, range));
                return new Pixel32(pixel.A, r, g, b);
            };
            return image.Noise(pixelOperator, intensity);
        }

        public static Image<Pixel32> AddGaussianNoise(this Image<Pixel32> image, double intensity, double stdDev)
        {
            return image.AddGaussianNoise(intensity, 0d, stdDev);
        }

        public static Image<Pixel32> AddGaussianNoise(this Image<Pixel32> image, double intensity, double meanValue, double stdDev)
        {
            Pixel32 pixelOperator(Pixel32 pixel)
            {
                var r = MathUtils.ByteClamp(pixel.R + random.NextGaussian(meanValue, stdDev));
                var g = MathUtils.ByteClamp(pixel.G + random.NextGaussian(meanValue, stdDev));
                var b = MathUtils.ByteClamp(pixel.B + random.NextGaussian(meanValue, stdDev));
                return new Pixel32(pixel.A, r, g, b);
            };
            return image.Noise(pixelOperator, intensity);
        }

        public static Image<Pixel32> AddSaltAndPepper(this Image<Pixel32> image, double intensity)
        {
            Pixel32 pixelOperator(Pixel32 pixel)
            {
                return random.NextBool() ? Pixel32.White : Pixel32.Black;
            };
            return image.Noise(pixelOperator, intensity);
        }

        private static Image<TPixelType> Noise<TPixelType>(this Image<TPixelType> image, PixelOperator<TPixelType> pixelOperator, double intensity)
            where TPixelType : struct, IPixel<TPixelType>
        {
            var steps = GetNoiseSteps(image, intensity);
            var dataLength = image.DataLength;
            for (double i = 0; i < dataLength; i += steps)
            {
                var index = MathUtils.Clamp(MathUtils.RoundToInt(random.NextDouble(i, i + steps)), 0, dataLength - 1);
                var pixel = image.Get(index);
                var newPixel = pixelOperator(pixel);
                image.Set(index, newPixel);
            }
            return image;
        }

        private static double GetNoiseSteps<TPixelType>(Image<TPixelType> image, double intensity)
            where TPixelType : struct, IPixel<TPixelType>
        {
            intensity = MathUtils.Clamp(intensity, 0d, 100d);
            return 100d / intensity;
        }
    }
}
