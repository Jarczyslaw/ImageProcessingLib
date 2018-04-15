using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLib.ImageProcessing
{
    public static class FlipHorizontalExtension
    {
        public static Image8 FlipHorizontal(this Image8 image)
        {
            Flip(image);
            return image;
        }

        public static Image24 FlipHorizontal(this Image24 image)
        {
            Flip(image);
            return image;
        }

        private static void Flip(ImageBase image)
        {
            int width = image.Width;
            int height = image.Height;
            int halfHeight = image.Height / 2;
            for (int i = 0; i < halfHeight; i++)
            {
                var tempHeight = image.Height - i - 1;
                for (int j = 0; j < width; j++)
                    image.Swap(j, i, j, tempHeight);
            }
        }
    }
}
