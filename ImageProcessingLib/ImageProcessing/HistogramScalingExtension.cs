using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class HistogramScalingExtension
    {
        public static Image<Pixel32> HistogramScaling(this Image<Pixel32> image)
        {
            return image.HistogramScaling(MathUtils.Normalize);
        }

        public static Image<Pixel32> HistogramScalingLog10(this Image<Pixel32> image)
        {
            return image.HistogramScaling(MathUtils.NormalizeLog10);
        }

        private static Image<Pixel32> HistogramScaling(this Image<Pixel32> image, Func<double, double, double> scaling)
        {
            var histogram = image.Histogram();
            image.ForEach((x, y) =>
            {
                var pixel = image.Get(x, y);
                var r = MathUtils.RoundToByte(scaling(pixel.R, histogram.R.Max.Value));
                var g = MathUtils.RoundToByte(scaling(pixel.G, histogram.G.Max.Value));
                var b = MathUtils.RoundToByte(scaling(pixel.B, histogram.B.Max.Value));
                image.Set(x, y, new Pixel32(pixel.A, r, g, b));
            });
            return image;
        }
    }
}
