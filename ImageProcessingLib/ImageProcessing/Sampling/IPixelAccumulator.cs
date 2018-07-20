using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public interface IPixelAccumulator<TPixelType>
    {
        void Add(TPixelType pixel);
        TPixelType GetAverage();
        void Reset();
    }
}
