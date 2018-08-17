using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class HistogramShiftExtension
    {
        public static Image<Pixel8> HistogramShift(this Image<Pixel8> image, int offset)
        {
            Pixel8 pixelOperator(Pixel8 pixel)
            {
                var val = MathUtils.ByteClamp(pixel.Value + offset);
                return new Pixel8(val);
            };
            return image.HistogramShift(pixelOperator);
        }

        public static Image<Pixel32> HistogramShift(this Image<Pixel32> image, int offset)
        {
            return image.HistogramShift(offset, offset, offset);
        }

        public static Image<Pixel32> HistogramShift(this Image<Pixel32> image, int redOffset, int greenOffset, int blueOffset)
        {
            Pixel32 pixelOperator(Pixel32 pixel)
            {
                var r = MathUtils.ByteClamp(pixel.R + redOffset);
                var g = MathUtils.ByteClamp(pixel.G + greenOffset);
                var b = MathUtils.ByteClamp(pixel.B + blueOffset);
                return new Pixel32(pixel.A, r, g, b);
            };
            return image.HistogramShift(pixelOperator);
        }

        private static Image<TPixelType> HistogramShift<TPixelType>(this Image<TPixelType> image, PixelOperator<TPixelType> pixelOperator)
        {
            image.ForEach((x, y) =>
            {
                var pixel = image.Get(x, y);
                var newPixel = pixelOperator(pixel);
                image.Set(x, y, newPixel);
            });
            return image;
        }
    }
}
