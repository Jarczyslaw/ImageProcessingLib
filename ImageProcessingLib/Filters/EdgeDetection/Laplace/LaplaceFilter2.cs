using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public class LaplaceFilter2 : LinearFilter
    {
        public LaplaceFilter2() : base(1d,
            new int[,]
            {
                { 1, -2, 1 },
                { -2, 4, -2 },
                { 1, -2, 1 }
            })
        { }
    }
}
