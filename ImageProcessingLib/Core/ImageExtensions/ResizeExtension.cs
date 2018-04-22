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
            var imageCopy = new Image<TPixelType>(image);
            image.InitializeNew(width, height);
            var rw = (double)imageCopy.Width / image.Width;
            var rh = (double)imageCopy.Height / image.Height;
            image.ForEach((x, y) =>
            {
                var sourceX = MathUtils.RoundToInt(x * rw);
                sourceX = MathUtils.Clamp(sourceX, 0, imageCopy.Width);
                var sourceY = MathUtils.RoundToInt(y * rh);
                sourceY = MathUtils.Clamp(sourceY, 0, imageCopy.Height);
                var nearestPixel = imageCopy.Get(sourceX, sourceY);
                image.Set(x, y, nearestPixel);
            });
            image.InvokeResize();
            return image;
        }
    }
}
