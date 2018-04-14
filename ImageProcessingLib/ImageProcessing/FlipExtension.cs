using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLib.ImageProcessing
{
    public static class FlipExtension
    {
        public static void FlipHorizontal(this Image24 image)
        {
            GetSizes(image, out int width, out int height, out int halfHeight);
            for (int i = 0; i < height; i++)
            {
                var tempHeight = image.Height - i;
                for (int j = 0; j < width; j++)
                    image.Swap(i, j, i, tempHeight);
            }
        }

        public static void FlipHorizontal(this Image8 image)
        {
            GetSizes(image, out int width, out int height, out int halfHeight);
            for (int i = 0; i < height; i++)
            {
                var tempHeight = image.Height - i;
                for (int j = 0; j < width; j++)
                    image.Swap(i, j, i, tempHeight);
            }
        }

        private static void GetSizes(ImageBase image, out int width, out int height, out int halfHeight)
        {
            width = image.Width;
            height = image.Height;
            halfHeight = image.Height / 2;
        }
    }
}
