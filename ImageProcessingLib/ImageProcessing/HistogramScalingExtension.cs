using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class HistogramScalingExtension
    {
        public static Image<Pixel8> HistogramScaling(this Image<Pixel8> image)
        {
            return image.HistogramScaling(MathUtils.Normalize);
        }

        public static Image<Pixel8> HistogramScalingLog10(this Image<Pixel8> image)
        {
            return image.HistogramScaling(MathUtils.NormalizeLog10);
        }

        public static Image<Pixel8> HistogramScaling(this Image<Pixel8> image, Func<double, double, double> scaling)
        {
            var histogram = image.Histogram();
            Pixel8 pixelOperator(Pixel8 pixel)
            {
                var value = MathUtils.RoundToByte(scaling(pixel.Value, histogram.Max.Value));
                return new Pixel8(value);
            };
            return image.HistogramScaling(pixelOperator);
        }

        public static Image<Pixel32> HistogramScaling(this Image<Pixel32> image)
        {
            return image.HistogramScaling(MathUtils.Normalize);
        }

        public static Image<Pixel32> HistogramScalingLog10(this Image<Pixel32> image)
        {
            return image.HistogramScaling(MathUtils.NormalizeLog10);
        }

        public static Image<Pixel32> HistogramScaling(this Image<Pixel32> image, Func<double, double, double> scaling)
        {
            var histogram = image.Histogram();
            Pixel32 pixelOperator(Pixel32 pixel)
            {
                var r = MathUtils.RoundToByte(scaling(pixel.R, histogram.R.Max.Value));
                var g = MathUtils.RoundToByte(scaling(pixel.G, histogram.G.Max.Value));
                var b = MathUtils.RoundToByte(scaling(pixel.B, histogram.B.Max.Value));
                return new Pixel32(pixel.A, r, g, b);
            };
            return image.HistogramScaling(pixelOperator);
        }

        private static Image<TPixelType> HistogramScaling<TPixelType>(this Image<TPixelType> image, PixelOperator<TPixelType> pixelOperator)
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
