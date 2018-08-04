using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class PenSketchExtension
    {
        public static Image<Pixel32> PenSketch(this Image<Pixel32> image, byte threshold = 48)
        {
            image.ApplyFilter(new PrewittFilter())
                .BlackAndWhite(threshold)
                .Inversion()
                .ApplyFilter(new SDROMFilter3());
            return image;
        }
    }
}
