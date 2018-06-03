using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public class LowPassFilter2 : LinearFilter
    {
        public LowPassFilter2() : base(1d / 10d,
            new int[,]
            {
                { 1, 1, 1 },
                { 1, 2, 1 },
                { 1, 1, 1 }
            })
        { }
    }
}
