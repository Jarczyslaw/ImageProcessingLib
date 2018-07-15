using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class ContrastStretchExtension
    {
        public static Image<Pixel32> ContrastStretch(this Image<Pixel32> image, byte min, byte max)
        {
            return image.ContrastStretch(min, max, min, max, min, max);
        }

        public static Image<Pixel32> ContrastStretch(this Image<Pixel32> image, byte rMin, byte rMax, byte gMin, byte gMax, byte bMin, byte bMax)
        {
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
            if (histMin == null)
                histMin = min;
            if (histMax == null)
                histMax = max;

            return MathUtils.RoundToByte(MathUtils.Rescale(pixelValue, histMin.Value, histMax.Value, min, max));
        }
    }
}
