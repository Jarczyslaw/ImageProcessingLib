using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class SwapExtension
    {
        public static Image<TPixelType> Swap<TPixelType>(this Image<TPixelType> image, int sourceX, int sourceY, int destinationX, int destinationY)
        {
            var sourcePixel = image.Get(sourceX, sourceY);
            var destinationPixel = image.Get(destinationX, destinationY);
            image.Set(sourceX, sourceY, destinationPixel);
            image.Set(destinationX, destinationY, sourcePixel);
            return image;
        }
    }
}
