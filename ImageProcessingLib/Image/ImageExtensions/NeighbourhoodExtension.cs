using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class NeighbourhoodExtension
    {
        public static Image<TPixelType> ForBlockNeighbourhood<TPixelType>(this Image<TPixelType> image, int x, int y, int width, int height, int range, ForNeighbourhoodHandler<TPixelType> action)
            where TPixelType : struct, IPixel<TPixelType>
        {
            ValidateForBlockNeighbourhood(image, x, y, width, height);

            int widthEnd = x + width;
            int heightEnd = y + height;
            for (int i = y; i < heightEnd; i++)
            {
                for (int j = x; j < widthEnd; j++)
                {
                    var neighbourhood = image.GetNeighbourhood(j, i, range);
                    action(j, i, neighbourhood);
                }
            }
            return image;
        }

        private static void ValidateForBlockNeighbourhood<TPixelType>(Image<TPixelType> image, int x, int y, int width, int height)
            where TPixelType : struct, IPixel<TPixelType>
        {
            if (image.ExceedsWidth(x) || image.ExceedsWidth(x + width) || image.ExceedsHeight(y) || image.ExceedsHeight(y + height))
                throw new ArgumentException("Given arguments exceeds image's area");
        }

        public static Image<TPixelType> ForEachNeighbourhood<TPixelType>(this Image<TPixelType> image, int range, ForNeighbourhoodHandler<TPixelType> action)
            where TPixelType : struct, IPixel<TPixelType>
        {
            return image.ForBlockNeighbourhood(0, 0, image.Width, image.Height, range, action);
        }
    }
}
