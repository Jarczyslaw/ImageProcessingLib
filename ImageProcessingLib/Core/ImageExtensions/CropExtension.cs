using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class CropExtension
    {
        public static Image<TPixelType> Crop<TPixelType>(this Image<TPixelType> image, int x, int y, int width, int height)
            where TPixelType : struct, IPixel<TPixelType>
        {
            if (x + width > image.Width || y + height > image.Height)
                throw new ArgumentException("Cropped area extends beyond the boundaries of the image");

            var originalImage = image.Copy();
            image.InitializeNew(width, height);
            image.ForEach((i, j) =>
            {
                var pixel = originalImage.Get(x + i, y + j);
                image.Set(i, j, pixel);
            });
            return image;
        }
    }
}
