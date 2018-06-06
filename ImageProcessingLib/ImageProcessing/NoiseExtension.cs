using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class NoiseExtension
    {
        private static RandomEx random = new RandomEx();

        public static Image<Pixel32> AddUniformNoise(this Image<Pixel32> image, double intensity, int range)
        {
            ApplyNoise(image, intensity, (i) =>
            {
                var pixel = image.Get(i);
                var noisedR = MathUtils.ByteClamp(pixel.R + random.Next(-range, range));
                var noisedG = MathUtils.ByteClamp(pixel.G + random.Next(-range, range));
                var noisedB = MathUtils.ByteClamp(pixel.B + random.Next(-range, range));
                return new Pixel32(pixel.A, noisedR, noisedG, noisedB);
            });
            return image;
        }

        public static Image<Pixel32> AddGaussianNoise(this Image<Pixel32> image, double intensity, double stdDev)
        {
            return image.AddGaussianNoise(intensity, 0d, stdDev);
        }

        public static Image<Pixel32> AddGaussianNoise(this Image<Pixel32> image, double intensity, double meanValue, double stdDev)
        {
            ApplyNoise(image, intensity, (i) =>
            {
                var pixel = image.Get(i);
                var noisedR = MathUtils.ByteClamp(pixel.R + random.NextGaussian(meanValue, stdDev));
                var noisedG = MathUtils.ByteClamp(pixel.G + random.NextGaussian(meanValue, stdDev));
                var noisedB = MathUtils.ByteClamp(pixel.B + random.NextGaussian(meanValue, stdDev));
                return new Pixel32(pixel.A, noisedR, noisedG, noisedB);
            });
            return image;
        }

        public static Image<Pixel32> AddSaltAndPepper(this Image<Pixel32> image, double intensity)
        {
            ApplyNoise(image, intensity, (i) => random.NextBool() ? Pixel32.White : Pixel32.Black);
            return image;
        }

        private static void ApplyNoise(Image<Pixel32> image, double intensity, Func<int, Pixel32> noiseFunc)
        {
            var steps = GetNoiseSteps(image, intensity);
            var dataLength = image.DataLength;
            for (double i = 0; i < dataLength; i += steps)
            {
                var index = MathUtils.Clamp(MathUtils.RoundToInt(random.NextDouble(i, i + steps)), 0, dataLength - 1);
                var noisedPixel = noiseFunc(index);
                image.Set(index, noisedPixel);
            }
        }

        private static double GetNoiseSteps(Image<Pixel32> image, double intensity)
        {
            intensity = MathUtils.Clamp(intensity, 0d, 100d);
            return 100d / intensity;
        }
    }
}
