using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    internal class OilPaintIntensity
    {
        public int Count { get; private set; } = 0;
        public double RedSum { get; private set; } = 0d;
        public double GreenSum { get; private set; } = 0d;
        public double BlueSum { get; private set; } = 0d;

        public void Add(Pixel32 pixel)
        {
            Count++;
            RedSum += pixel.R;
            GreenSum += pixel.G;
            BlueSum += pixel.B;
        }

        public Pixel32 GetResult(byte alpha)
        {
            var r = MathUtils.RoundToByte(RedSum / Count);
            var g = MathUtils.RoundToByte(GreenSum / Count);
            var b = MathUtils.RoundToByte(BlueSum / Count);
            return new Pixel32(alpha, r, g, b);
        }
    }
}
