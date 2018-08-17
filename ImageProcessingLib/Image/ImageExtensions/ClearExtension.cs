using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class ClearExtension
    {
        public static Image<TPixelType> Clear<TPixelType>(this Image<TPixelType> image, TPixelType pixel)
        {
            for (int i = 0; i < image.Size; i++)
                image.Set(i, pixel);
            return image;
        }
    }
}
