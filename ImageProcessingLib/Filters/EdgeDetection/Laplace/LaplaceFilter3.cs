using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public class LaplaceFilter3 : LinearFilter
    {
        public LaplaceFilter3() : base(1d,
            new int[,]
            {
                { -1, -1, -1 },
                { -1, 8, -1 },
                { -1, -1, -1 }
            })
        { }
    }
}
