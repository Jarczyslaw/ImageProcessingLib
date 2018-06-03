using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageProcessingLib
{
    public abstract class MedianFilter : IFilter
    {
        public int Range { get; private set; }
        public int Center { get; private set; }

        public MedianFilter(int maskSize)
        {
            Validate(maskSize);

            Range = maskSize / 2;
            Center = maskSize * maskSize / 2;
        }

        public byte Apply(byte[] neighbourhood)
        {
            var sorted = neighbourhood.OrderBy(n => n).ToArray();
            return sorted[Center];
        }

        private void Validate(int maskSize)
        {
            if (maskSize < 3 || maskSize % 2 == 0)
                throw new ArgumentException("Mask size must be odd and not less than 3");
        }
    }
}
