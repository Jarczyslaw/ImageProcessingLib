using System;

namespace ImageProcessingLib
{
    public static class SkeletonizationExtension
    {
        public static Image<Pixel1> Skeletonization(this Image<Pixel1> image)
        {
            Validate(image);

            var width = image.Width;
            var height = image.Height;

            var data = GetImageData(image);
            var skeletonizationTable = SkeletonizationAlgorithm(data, width, height);
            var skeleton = ExtractSkeleton(skeletonizationTable, width, height);
            return image.ForEach((x, y) =>
            {
                image.Set(x, y, new Pixel1(skeleton[x, y]));
            });
        }

        private static void Validate(Image<Pixel1> image)
        {
            if (image.Width < 3 || image.Height < 3)
                throw new ArgumentException("Image for skeletonization has to be larger than 3x3");
        }

        private static int[,] GetImageData(Image<Pixel1> image)
        {
            var width = image.Width;
            var height = image.Height;
            var data = new int[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (image.Get(i, j).Value)
                        data[i, j] = 1;
                }
            }
            return data;
        }

        private static int[,] SkeletonizationAlgorithm(int[,] table, int width, int height)
        {
            bool nextIteration;
            int skeleValue = 0;
            do
            {
                nextIteration = false;
                skeleValue++;

                var newTable = (int[,])table.Clone();
                for (int i = 1; i < width - 1; i++)
                {
                    for (int j = 1; j < height - 1; j++)
                    {
                        if (table[i, j] == skeleValue)
                        {
                            newTable[i, j] = Math.Min(Math.Min(table[i - 1, j], table[i + 1, j]), Math.Min(table[i, j - 1], table[i, j + 1])) + 1;
                            nextIteration = true;
                        }
                    }
                }
                table = newTable;
            }
            while (nextIteration);
            return table;
        }

        private static bool[,] ExtractSkeleton(int[,] table, int width, int height)
        {
            var result = new bool[width, height];
            for (int i = 1; i < width - 1; i++)
            {
                for (int j = 1; j < height - 1; j++)
                {
                    var current = table[i, j];
                    var max = Math.Max(Math.Max(table[i - 1, j], table[i + 1, j]), Math.Max(table[i, j - 1], table[i, j + 1]));
                    if (current == max && current != 0)
                        result[i, j] = true;
                }
            }
            return result;
        }
    }
}
