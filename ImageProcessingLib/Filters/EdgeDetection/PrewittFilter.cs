using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public class PrewittFilter : DirectionalFilter
    {
        public PrewittFilter()
            : this(false) { }

        public PrewittFilter(bool useApproximation) :
            base(
                new int[,]
                {
                    { 1, 1, 1 },
                    { 0, 0, 0 },
                    { -1, -1, -1 }
                },
                new int[,]
                {
                    { 1, 0, -1 },
                    { 1, 0, -1 },
                    { 1, 0, -1 }
                },
            useApproximation)
        { }
    }
}
