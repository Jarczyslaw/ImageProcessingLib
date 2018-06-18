﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class HistogramExtension
    {
        public static HistogramResult Histogram(this Image<Pixel32> image)
        {
            var result = new HistogramResult();
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
