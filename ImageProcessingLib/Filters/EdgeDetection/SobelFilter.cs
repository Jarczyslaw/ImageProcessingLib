using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public class SobelFilter : DirectionalFilter
    {
        public SobelFilter()
            : this(false) { }

        public SobelFilter(bool useApproximation) : 
            base (
                new int[,]
                {
                    { 1, 2, 1 },
                    { 0, 0, 0 },
                    { -1, -2, -1 }
                }, 
                new int[,]
                {
                    { 1, 0, -1 },
                    { 2, 0, -2 },
                    { 1, 0, -1 }
                }, 
            useApproximation) { }
    }
}
