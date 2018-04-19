using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLib.ImageProcessing
{
    public static class FlipHorizontalExtension
    {
        public static Image<Pixel32> FlipHorizontal(this Image<Pixel32> image)
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
            return image;
        }
    }
}
