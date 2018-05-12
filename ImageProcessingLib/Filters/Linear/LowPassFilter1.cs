using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public class LowPassFilter1 : LinearFilter
    {
        public LowPassFilter1() : base(1d / 9d,
            new int[,]
            {
                { 1, 1, 1 },
                { 1, 1, 1 },
                { 1, 1, 1 }
            })
        { }
    }
}
