using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class ComplementExtension
    {
        public static Image<TPixelType> Complement<TPixelType>(this Image<TPixelType> image, int width, int height, TPixelType fillPixel)
        {
            Validate(image, width, height);

            int startX = (width - image.Width) / 2;
            int startY = (height - image.Height) / 2;
            var originalImage = image.Copy();
            image.Initialize(width, height, fillPixel);
            originalImage.ForEach((x, y) =>
            {
                var pixel = originalImage.Get(x, y);
                image.Set(startX + x, startY + y, pixel);
            });
            return image;
        }

        private static void Validate<TPixelType>(this Image<TPixelType> image, int width, int height)
        {
            if (image.Width > width || image.Height > height)
                throw new ArgumentException("Complemented image should be larger than original one");
        }
    }
}
