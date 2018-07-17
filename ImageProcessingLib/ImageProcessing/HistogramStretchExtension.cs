using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class HistogramStretchExtension
    {
        public static Image<Pixel32> HistogramStretch(this Image<Pixel32> image, byte min, byte max)
        {
            return image.HistogramStretch(min, max, min, max, min, max);
        }

        public static Image<Pixel32> HistogramStretch(this Image<Pixel32> image, byte rMin, byte rMax, byte gMin, byte gMax, byte bMin, byte bMax)
        {
            Validate(rMin, rMax, gMin, gMax, bMin, bMax);

            MathUtils.Orientate(ref rMin, ref rMax);
            MathUtils.Orientate(ref gMin, ref gMax);
            MathUtils.Orientate(ref bMin, ref bMax);

            var histogram = image.Histogram();
            image.ForEach((x, y) =>
            {
                var pixel = image.Get(x, y);
                var r = Stretch(pixel.R, histogram.R.Min, histogram.R.Max, rMin, rMax);
                var g = Stretch(pixel.G, histogram.G.Min, histogram.G.Max, gMin, gMax);
                var b = Stretch(pixel.B, histogram.B.Min, histogram.B.Max, bMin, bMax);
                image.Set(x, y, new Pixel32(pixel.A, r, g, b));
            });
            return image;
        }

        private static byte Stretch(byte pixelValue, byte? histMin, byte? histMax, byte min, byte max)
        {
            if (histMin == null || histMax == null)
                return pixelValue;

            return MathUtils.RoundToByte(MathUtils.Rescale(pixelValue, histMin.Value, histMax.Value, min, max));
        }

        private static void Validate(byte rMin, byte rMax, byte gMin, byte gMax, byte bMin, byte bMax)
        {
            if (rMin == rMax || gMin == gMax || bMin == bMax)
                throw new ArgumentException("Minimum and maximum values for pixel component can not be equal");
        }
    }
}
