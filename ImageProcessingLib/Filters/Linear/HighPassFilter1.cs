using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public class HighPassFilter1 : LinearFilter
    {
        public HighPassFilter1() : base(1d,
            new int[,]
            {
                { -1, -1, -1 },
                { -1, 9, -1 },
                { -1, -1, -1 }
            })
        { }
    }
}
