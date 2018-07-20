using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public class Pixel8Accumulator : IPixelAccumulator<Pixel8>
    {
        public int Count { get; private set; }
        public int Value { get; private set; }

        public void Add(Pixel8 pixel)
        {
            Count++;
            Value += pixel.Value;
        }

        public Pixel8 GetAverage()
        {
            var mean = MathUtils.RoundToByte(Value / Count);
            return new Pixel8(mean);
        }

        public void Reset()
        {
            Count = 0;
            Value = 0;
        }
    }
}
