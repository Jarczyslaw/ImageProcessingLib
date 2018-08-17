using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static partial class ResizeExtension
    {
        public static Image<TPixelType> Resize<TPixelType>(this Image<TPixelType> image, int width, int height)
        {
            var result = new Image<TPixelType>(width, height);
            var rw = (double)image.Width / image.Width;
            var rh = (double)image.Height / image.Height;
            result.ForEach((x, y) =>
            {
                var x0 = image.ClampWidth(MathUtils.RoundToInt(x * rw));
                var y0 = image.ClampHeight(MathUtils.RoundToInt(y * rh));
                var nearestPixel = image.Get(x0, y0);
                image.Set(x, y, nearestPixel);
            });
            return image;
        }
    }
}
