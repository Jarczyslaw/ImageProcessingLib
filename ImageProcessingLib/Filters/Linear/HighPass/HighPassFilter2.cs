using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public class HighPassFilter2 : LinearFilter
    {
        public HighPassFilter2() : base(1d,
            new int[,]
            {
                { 0, -1, 0 },
                { -1, 5, -1 },
                { 0, -1, 0 }
            })
        { }
    }
}
