using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public class LaplaceFilter1 : LinearFilter
    {
        public LaplaceFilter1() : base(1d,
            new int[,]
            {
                { 0, -1, 0 },
                { -1, 4, -1 },
                { 0, -1, 0 }
            })
        { }
    }
}
