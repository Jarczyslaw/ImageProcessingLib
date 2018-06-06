using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class AlphaRemovalExtension
    {
        public static Image<Pixel32> AlphaRemoval(this Image<Pixel32> image)
        {
            return image.ForEach((x, y) =>
            {
                var pixel = image.Get(x, y);
                image.Set(x, y, pixel.SetAlpha(255));
            });
        }
    }
}
