using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class ClearExtension
    {
        public static Image<TPixelType> Clear<TPixelType>(this Image<TPixelType> image)
            where TPixelType : struct, IPixel<TPixelType>
        {
            image.Clear(new TPixelType().Blank);
            return image;
        }

        public static Image<TPixelType> Clear<TPixelType>(this Image<TPixelType> image, TPixelType pixel)
            where TPixelType : struct, IPixel<TPixelType>
        {
            int value = pixel.Data;
            int len = image.DataLength;
            for (int i = 0; i < len; i++)
                image.Data[i] = value;
            return image;
        }
    }
}
