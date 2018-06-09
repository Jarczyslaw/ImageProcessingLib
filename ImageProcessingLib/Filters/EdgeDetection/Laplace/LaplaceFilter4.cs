using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public class LaplaceFilter4 : LinearFilter
    {
        public LaplaceFilter4() : base(1d,
            new int[,]
            {
                { -1, -1, -1, -1, -1 },
                { -1, -1, -1, -1, -1 },
                { -1, -1, 24, -1, -1 },
                { -1, -1, -1, -1, -1 },
                { -1, -1, -1, -1, -1 }
            })
        { }
    }
}
