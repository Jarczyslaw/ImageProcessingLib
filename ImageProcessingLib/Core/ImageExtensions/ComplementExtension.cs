using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class ComplementExtension
    {
        public static Image<TPixelType> Complement<TPixelType>(this Image<TPixelType> image, int width, int height)
            where TPixelType : struct, IPixel<TPixelType>
        {
            return image.Complement(width, height, new TPixelType().Blank);
        }

        public static Image<TPixelType> Complement<TPixelType>(this Image<TPixelType> image, int width, int height, TPixelType fillColor)
            where TPixelType : struct, IPixel<TPixelType>
        {
            if (image.Width > width || image.Height > height)
                throw new ArgumentException("Complemented image should be larger than original one");

            int startX = (width - image.Width) / 2;
            int startY = (height - image.Height) / 2;
            var originalImage = image.Copy();
            image.InitializeNew(width, height);
            image.Clear(fillColor);
            originalImage.ForEach((x, y) =>
            {
                var pixel = originalImage.Get(x, y);
                image.Set(startX + x, startY + y, pixel);
            });
            return image;
        }
    }
}
