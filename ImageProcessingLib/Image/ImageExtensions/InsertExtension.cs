using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class InsertExtension
    {
        public static Image<TPixelType> Insert<TPixelType>(this Image<TPixelType> image, Image<TPixelType> insertedImage, int x, int y)
            where TPixelType : struct, IPixel<TPixelType>
        {
            insertedImage.ForEach((i, j) =>
            {

            });
            return image;
        }
    }
}
