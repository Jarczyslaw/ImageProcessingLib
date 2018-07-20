using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class HistogramStretchExtension
    {
        public static Image<Pixel8> HistogramStretch(this Image<Pixel8> image, byte min, byte max)
        {
            return image.HistogramStretch(min, max, min, max, min, max);
        }

        public static Image<Pixel8> HistogramStretch(this Image<Pixel8> image, byte rMin, byte rMax, byte gMin, byte gMax, byte bMin, byte bMax)
        {
            var histogram = image.Histogram();
            Pixel8 pixelOperator(Pixel8 pixel)
            {
                var val = Stretch(pixel.Value, histogram.Min, histogram.Max, rMin, rMax);
                return new Pixel8(val);
            };
            return image.HistogramStretch(pixelOperator, rMin, rMax, gMin, gMax, bMin, bMax);
        }

        public static Image<Pixel32> HistogramStretch(this Image<Pixel32> image, byte min, byte max)
        {
            return image.HistogramStretch(min, max, min, max, min, max);
        }

        public static Image<Pixel32> HistogramStretch(this Image<Pixel32> image, byte rMin, byte rMax, byte gMin, byte gMax, byte bMin, byte bMax)
        {
            var histogram = image.Histogram();
            Pixel32 pixelOperator(Pixel32 pixel)
            {
                var r = Stretch(pixel.R, histogram.R.Min, histogram.R.Max, rMin, rMax);
                var g = Stretch(pixel.G, histogram.G.Min, histogram.G.Max, gMin, gMax);
                var b = Stretch(pixel.B, histogram.B.Min, histogram.B.Max, bMin, bMax);
                return new Pixel32(pixel.A, r, g, b);
            };
            return image.HistogramStretch(pixelOperator, rMin, rMax, gMin, gMax, bMin, bMax);
        }

        private static Image<TPixelType> HistogramStretch<TPixelType>(this Image<TPixelType> image, PixelOperator<TPixelType> pixelOperator, byte rMin, byte rMax, byte gMin, byte gMax, byte bMin, byte bMax)
             where TPixelType : struct, IPixel<TPixelType>
        {
            MathUtils.Orientate(ref rMin, ref rMax);
            MathUtils.Orientate(ref gMin, ref gMax);
            MathUtils.Orientate(ref bMin, ref bMax);

            Validate(rMin, rMax, gMin, gMax, bMin, bMax);

            image.ForEach((x, y) =>
            {
                var pixel = image.Get(x, y);
                var newPixel = pixelOperator(pixel);
                image.Set(x, y, newPixel);
            });
            return image;
        }

        private static byte Stretch(byte pixelValue, byte? histMin, byte? histMax, byte min, byte max)
        {
            return MathUtils.RoundToByte(MathUtils.Rescale(pixelValue, histMin.Value, histMax.Value, min, max));
        }

        private static void Validate(byte rMin, byte rMax, byte gMin, byte gMax, byte bMin, byte bMax)
        {
            if (rMin == rMax || gMin == gMax || bMin == bMax)
                throw new ArgumentException("Minimum and maximum values for pixel component can not be equal");
        }
    }
}
