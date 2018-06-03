using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public class HighPassFilter4 : LinearFilter
    {
        public HighPassFilter4() : base(1d,
            new int[,]
            {
                { -1, -1, -1, -1, -1 },
                { -1, -1, -1, -1, -1 },
                { -1, -1, 25, -1, -1 },
                { -1, -1, -1, -1, -1 },
                { -1, -1, -1, -1, -1 }
            })
        { }
    }
}
