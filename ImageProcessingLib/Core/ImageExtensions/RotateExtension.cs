using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class RotateExtension
    {
        public static Image<TPixelType> RotateClockwise<TPixelType>(this Image<TPixelType> image)
            where TPixelType : struct, IPixel<TPixelType>
        {
            var originalImage = new Image<TPixelType>(image);
            image.InitializeNew(image.Height, image.Width);
            for (int i = 0; i < originalImage.Height; i++)
            {
                for (int j = 0; j < originalImage.Width; j++)
                {
                    var pixel = originalImage.Get(j, i);
                    image.Set(originalImage.Height - 1 - i, j, pixel);
                }
            }
            return image;
        }

        public static Image<TPixelType> RotateCounterClockwise<TPixelType>(this Image<TPixelType> image)
            where TPixelType : struct, IPixel<TPixelType>
        {
            var originalImage = new Image<TPixelType>(image);
            image.InitializeNew(image.Height, image.Width);
            for (int i = 0; i < originalImage.Height; i++)
            {
                for (int j = 0; j < originalImage.Width; j++)
                {
                    var pixel = originalImage.Get(j, i);
                    image.Set(i, originalImage.Width - 1 - j, pixel);
                }
            }
            return image;
        }
    }
}
