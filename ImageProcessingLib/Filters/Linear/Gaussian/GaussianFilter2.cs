using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public class GaussianFilter2 : LinearFilter
    {
        public GaussianFilter2() : base(1d / 52d,
            new int[,]
            {
                { 1, 1, 2, 1, 1 },
                { 1, 2, 4, 2, 1 },
                { 2, 4, 8, 4, 2 },
                { 1, 2, 4, 2, 1 },
                { 1, 1, 2, 1, 1 }
            })
        { }
    }
}
