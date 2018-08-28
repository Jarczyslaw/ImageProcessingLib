using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class OpeningExtension
    {
        public static Image<Pixel1> Opening(this Image<Pixel1> image, int maskSize = 3)
        {
            return image.Erosion(maskSize)
                .Dilation(maskSize);
        }
    }
}
