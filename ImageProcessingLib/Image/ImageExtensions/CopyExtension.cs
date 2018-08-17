using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class CopyExtension
    {
        public static Image<TNewPixelType> CopyAs<TPixelType, TNewPixelType>(this Image<TPixelType> image, PixelConverter<TPixelType, TNewPixelType> converter)
        {
            var result = new Image<TNewPixelType>(image.Width, image.Height);
            for (int i = 0; i < image.Height; i++)
            {
                for (int j = 0; j < image.Width; j++)
                {
                    var newValue = converter(image.Get(j, i));
                    result.Set(j, i, newValue);
                }
            }
            return result;
        }

        public static Image<TPixelType> Copy<TPixelType>(this Image<TPixelType> image)
        {
            return new Image<TPixelType>(image);
        }
    }
}
