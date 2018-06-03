using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public class GaussianFilter1 : LinearFilter
    {
        public GaussianFilter1() : base(1d / 16d,
            new int[,]
            {
                { 1, 2, 1 },
                { 2, 4, 2 },
                { 1, 2, 1 }
            })
        { }
    }
}
