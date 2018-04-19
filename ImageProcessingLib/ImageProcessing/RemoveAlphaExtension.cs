using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib.ImageProcessing
{
    public static class RemoveAlphaExtension
    {
        public static Image<Pixel32> RemoveAlpha(this Image<Pixel32> image)
        {
            return image.ForEach((x, y, pixel) =>
            {
                return pixel.SetAlpha(255);
            });
        }
    }
}
