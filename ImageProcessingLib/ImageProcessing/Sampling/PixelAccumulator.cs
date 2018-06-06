using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    internal class PixelAccumulator
    {
        public int Count { get; private set; }
        public int A { get; private set; }
        public int R { get; private set; }
        public int G { get; private set; }
        public int B { get; private set; }

        public void Add(Pixel32 pixel)
        {
            Count++;
            A += pixel.A;
            R += pixel.R;
            G += pixel.G;
            B += pixel.B;
        }

        public Pixel32 GetAverage()
        {
            var meanA = MathUtils.RoundToByte(A / Count);
            var meanR = MathUtils.RoundToByte(R / Count);
            var meanG = MathUtils.RoundToByte(G / Count);
            var meanB = MathUtils.RoundToByte(B / Count);
            return new Pixel32(meanA, meanR, meanG, meanB);
        }

        public void Reset()
        {
            Count = 0;
            A = R = G = B = 0;
        }
    }
}
