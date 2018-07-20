using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class HistogramExtension
    {
        public static Histogram Histogram(this Image<Pixel8> image)
        {
            var result = new Histogram();
            image.ForEach((x, y) =>
            {
                var pixel = image.Get(x, y);
                result.Add(pixel.Value);
            });
            return result;
        }

        public static RGBHistogram Histogram(this Image<Pixel32> image)
        {
            var result = new RGBHistogram();
            image.ForEach((x, y) =>
            {
                var pixel = image.Get(x, y);
                result.R.Add(pixel.R);
                result.G.Add(pixel.G);
                result.B.Add(pixel.B);
            });
            return result;
        }
    }
}
