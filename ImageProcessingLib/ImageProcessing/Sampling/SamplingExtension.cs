using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib.ImageProcessing
{
    public static class SamplingExtension
    {
        public static Image<Pixel32> Sampling(this Image<Pixel32> image, int blockSize)
        {
            return image.Sampling(blockSize, blockSize);
        }

        public static Image<Pixel32> Sampling(this Image<Pixel32> image, int blockWidth, int blockHeight)
        {
            ValidateInput(image, blockWidth, blockHeight);

            var accumulator = new PixelAccumulator();
            int widthBlocksCount = image.Width / blockWidth;
            int heightBlocksCount = image.Height / blockHeight;
            for (int i = 0; i < heightBlocksCount; i++)
            {
                for (int j = 0; j < widthBlocksCount; j++)
                {
                    accumulator.Reset();
                    int xStart = j * blockWidth;
                    int yStart = i * blockHeight;
                    image.ForBlock(xStart, yStart, blockWidth, blockHeight, (x, y) => accumulator.Add(image.Get(x, y)));
                    var averagePixel = accumulator.GetAverage();
                    image.ForBlock(xStart, yStart, blockWidth, blockHeight, (x, y) => image.Set(x, y, averagePixel));
                }
            }
            return null;
        }

        private static void ValidateInput(Image<Pixel32> image, int widthDivide, int heightDivide)
        {
            if (image.Width % widthDivide != 0)
                throw new ArgumentException("Invalid width division. The width must be divided without rest");

            if (image.Height % heightDivide != 0)
                throw new ArgumentException("Invalid height division. The height must be divided without rest");
        }
    }
}
