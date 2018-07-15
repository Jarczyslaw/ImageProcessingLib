﻿using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class HistogramShiftExtension
    {
        public static Image<Pixel32> HistogramShift(this Image<Pixel32> image, int offset)
        {
            return image.HistogramShift(offset, offset, offset);
        }

        public static Image<Pixel32> HistogramShift(this Image<Pixel32> image, int redOffset, int greenOffset, int blueOffset)
        {
            image.ForEach((x, y) =>
            {
                var pixel = image.Get(x, y);
                var r = MathUtils.ByteClamp(pixel.R + redOffset);
                var g = MathUtils.ByteClamp(pixel.G + greenOffset);
                var b = MathUtils.ByteClamp(pixel.B + blueOffset);
                image.Set(x, y, new Pixel32(pixel.A, r, g, b));
            });
            return image;
        }
    }
}
