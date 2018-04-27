using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static partial class ResizeExtension
    {
        public static Image<TPixelType> Resize<TPixelType>(this Image<TPixelType> image, int width, int height)
            where TPixelType : struct, IPixel<TPixelType>
        {
            var originalImage = new Image<TPixelType>(image);
            image.InitializeNew(width, height);
            var rw = (double)originalImage.Width / image.Width;
            var rh = (double)originalImage.Height / image.Height;
            image.ForEach((x, y) =>
            {
                var x0 = originalImage.ClampWidth(MathUtils.RoundToInt(x * rw));
                var y0 = originalImage.ClampHeight(MathUtils.RoundToInt(y * rh));
                var nearestPixel = originalImage.Get(x0, y0);
                image.Set(x, y, nearestPixel);
            });
            image.InvokeResize();
            return image;
        }
    }
}
