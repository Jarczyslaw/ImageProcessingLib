using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class SkeletonizationExtension
    {
        public static Image<Pixel1> Skeletonization(this Image<Pixel1> image)
        {
            Validate(image);

            var width = image.Width;
            var height = image.Height;
            var table = new int[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (image.Get(i, j).Value)
                        table[i, j] = 1;
                }
            }

            SkeletonizationRecursive(table, width, height, 1);

            return image;
        }

        private static void Validate(Image<Pixel1> image)
        {
            if (image.Width < 3 || image.Height < 3)
                throw new ArgumentException("Image for skeletonization has to be larger than 3x3");
        }

        private static void SkeletonizationRecursive(int[,] table, int width, int height, int skeleValue)
        {
            var nextIteration = false;
            for (int i = 1; i < width - 1; i++)
            {
                for (int j = 1; j < height - 1; j++)
                {
                    if (table[i, j] == skeleValue)
                    {
                        table[i, j] = Math.Min(Math.Min(table[i - 1, j], table[i + 1, j]), Math.Min(table[i, j - 1], table[i, j + 1])) + 1;
                        nextIteration = true;
                    }
                }
            }
            if (nextIteration)
                SkeletonizationRecursive(table, width, height, skeleValue + 1);
        }
    }
}
