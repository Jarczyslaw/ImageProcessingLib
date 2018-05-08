using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class ForExtension
    {
        public static Image<TPixelType> ForBlock<TPixelType>(this Image<TPixelType> image, int x, int y, int width, int height, ForHandler action)
            where TPixelType : struct, IPixel<TPixelType>
        {
            int widthEnd = x + width;
            int heightEnd = y + height;
            for (int i = y; i < heightEnd; i++)
                for (int j = x; j < widthEnd; j++)
                    action(j, i);
            return image;
        }

        public static Image<TPixelType> ForEach<TPixelType>(this Image<TPixelType> image, ForHandler action)
            where TPixelType : struct, IPixel<TPixelType>
        {
            return image.ForBlock(0, 0, image.Width, image.Height, action);
        }

        public static Image<TPixelType> ForStripe<TPixelType>(this Image<TPixelType> image, int segment, int segmentsCount, ForHandler action)
            where TPixelType : struct, IPixel<TPixelType>
        {
            float len = (float)image.Height / segmentsCount;
            int start = (int)Math.Round(segment * len);
            int end = (int)Math.Round((segment + 1) * len);
            return image.ForBlock(0, start, image.Width, end - start, action);
        }
    }
}
