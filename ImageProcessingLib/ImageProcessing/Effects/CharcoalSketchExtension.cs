using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class CharcoalSketchExtension
    {
        public static Image<Pixel32> CharcoalSketch(this Image<Pixel32> image, byte inversion = 127)
        {
            image.ApplyFilter(new SobelFilter())
                .Grayscale()
                .Inversion(inversion)
                .ApplyFilter(new MedianFilter3());
            return image;
        }
    }
}
