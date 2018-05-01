using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib.ImageProcessing
{
    public static class HistogramExtension
    {
        public static HistogramResult Histogram(this Image<Pixel32> image)
        {
            var result = new HistogramResult();
            image.ForEach((x, y) =>
            {
                var pixel = image.Get(x, y);
                result.R[pixel.R]++;
                result.G[pixel.G]++;
                result.B[pixel.B]++;
            });
            return result;
        }
    }
}
