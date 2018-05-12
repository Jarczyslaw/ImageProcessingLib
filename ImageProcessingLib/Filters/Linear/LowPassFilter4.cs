using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public class LowPassFilter4 : LinearFilter
    {
        public LowPassFilter4() : base(1d / 273d,
            new int[,]
            {
                { 1, 4, 7, 4, 1 },
                { 4, 16, 26, 16, 4 },
                { 7, 26, 41, 26, 7},
                { 4, 16, 26, 16, 4 },
                { 1, 4, 7, 4, 1 }
            })
        { }
    }
}
