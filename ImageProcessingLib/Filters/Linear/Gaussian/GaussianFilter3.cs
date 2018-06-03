using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public class GaussianFilter3 : LinearFilter
    {
        public GaussianFilter3() : base(1d / 140d,
            new int[,]
            {
                { 1, 1, 2, 2, 2, 1, 1 },
                { 1, 2, 2, 4, 2, 2, 1 },
                { 2, 2, 4, 8, 4, 2, 2 },
                { 2, 4, 8, 16, 8, 4, 2 },
                { 2, 2, 4, 8, 4, 2, 2 },
                { 1, 2, 2, 4, 2, 2, 1 },
                { 1, 1, 2, 2, 2, 1, 1 }
            })
        { }
    }
}
