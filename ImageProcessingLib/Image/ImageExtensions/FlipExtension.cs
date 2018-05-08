using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLib
{
    public static class FlipExtension
    {
        public static Image<TPixelType> FlipHorizontal<TPixelType>(this Image<TPixelType> image)
            where TPixelType : struct, IPixel<TPixelType>
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

        public static Image<TPixelType> FlipVertical<TPixelType>(this Image<TPixelType> image)
            where TPixelType : struct, IPixel<TPixelType>
        {
            int width = image.Width;
            int height = image.Height;
            int halfWidth = image.Width / 2;
            for (int i = 0; i < halfWidth; i++)
            {
                var tempWidth = image.Width - i - 1;
                for (int j = 0; j < height; j++)
                    image.Swap(i, j, tempWidth, j);
            }
            return image;
        }
    }
}
