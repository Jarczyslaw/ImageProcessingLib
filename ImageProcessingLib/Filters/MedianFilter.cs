using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageProcessingLib
{
    public class MedianFilter : IFilter
    {
        public int Range { get; private set; }
        public int Center { get; private set; }

        public MedianFilter(int maskSize)
        {
            MathUtils.IsMaskSize(maskSize);

            Range = maskSize / 2;
            Center = maskSize * maskSize / 2;
        }

        public byte Apply(byte[] neighbourhood)
        {
            var sorted = neighbourhood.OrderBy(n => n).ToArray();
            return sorted[Center];
        }
    }
}
