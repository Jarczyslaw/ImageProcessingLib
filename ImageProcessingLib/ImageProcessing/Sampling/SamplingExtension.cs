using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class SamplingExtension
    {
        public static Image<Pixel8> Sampling(this Image<Pixel8> image, int blockSize)
        {
            var accumulator = new Pixel8Accumulator();
            return image.Sampling(accumulator, blockSize, blockSize);
        }

        public static Image<Pixel8> Sampling(this Image<Pixel8> image, int blockWidth, int blockHeight)
        {
            var accumulator = new Pixel8Accumulator();
            return image.Sampling(accumulator, blockWidth, blockHeight);
        }

        public static Image<Pixel32> Sampling(this Image<Pixel32> image, int blockSize)
        {
            var accumulator = new Pixel32Accumulator();
            return image.Sampling(accumulator, blockSize, blockSize);
        }

        public static Image<Pixel32> Sampling(this Image<Pixel32> image, int blockWidth, int blockHeight)
        {
            var accumulator = new Pixel32Accumulator();
            return image.Sampling(accumulator, blockWidth, blockHeight);
        }

        private static Image<TPixelType> Sampling<TPixelType>(this Image<TPixelType> image, IPixelAccumulator<TPixelType> pixelAccumulator, int blockWidth, int blockHeight)
            where TPixelType : struct, IPixel<TPixelType>
        {
            ValidateInput(image, blockWidth, blockHeight);

            int widthBlocksCount = image.Width / blockWidth;
            int heightBlocksCount = image.Height / blockHeight;
            for (int i = 0; i < heightBlocksCount; i++)
            {
                for (int j = 0; j < widthBlocksCount; j++)
                {
                    pixelAccumulator.Reset();
                    int xStart = j * blockWidth;
                    int yStart = i * blockHeight;
                    image.ForBlock(xStart, yStart, blockWidth, blockHeight, (x, y) => pixelAccumulator.Add(image.Get(x, y)));
                    var averagePixel = pixelAccumulator.GetAverage();
                    image.ForBlock(xStart, yStart, blockWidth, blockHeight, (x, y) => image.Set(x, y, averagePixel));
                }
            }
            return null;
        }

        private static void ValidateInput<TPixelType>(Image<TPixelType> image, int widthDivide, int heightDivide)
             where TPixelType : struct, IPixel<TPixelType>
        {
            if (image.Width % widthDivide != 0)
                throw new ArgumentException("Invalid width division. The width must be divided without rest");

            if (image.Height % heightDivide != 0)
                throw new ArgumentException("Invalid height division. The height must be divided without rest");
        }
    }
}
