using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public class HighPassFilter3 : LinearFilter
    {
        public HighPassFilter3() : base(1d,
            new int[,]
            {
                { 1, -2, 1 },
                { -2, 9, -2 },
                { 1, -2, 1 }
            })
        { }
    }
}
