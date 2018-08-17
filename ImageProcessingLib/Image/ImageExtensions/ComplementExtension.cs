using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class ComplementExtension
    {
        public static Image<TPixelType> Complement<TPixelType>(this Image<TPixelType> image, int width, int height, TPixelType fillColor)
        {
            Validate(image, width, height);

            int startX = (width - image.Width) / 2;
            int startY = (height - image.Height) / 2;
            var result = new Image<TPixelType>(width, height, fillColor);
            image.ForEach((x, y) =>
            {
                var pixel = image.Get(x, y);
                result.Set(startX + x, startY + y, pixel);
            });
            return result;
        }

        private static void Validate<TPixelType>(this Image<TPixelType> image, int width, int height)
        {
            if (image.Width > width || image.Height > height)
                throw new ArgumentException("Complemented image should be larger than original one");
        }
    }
}
