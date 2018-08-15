using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class ClosingExtension
    {
        public static Image<Pixel1> Closing(this Image<Pixel1> image, int maskSize)
        {
            return image.Dilation(maskSize)
                .Erosion(maskSize);
        }
    }
}
