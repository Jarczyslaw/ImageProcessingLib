using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib.ImageProcessing
{
    public class HistogramResult
    {
        public int[] R { get; private set; }
        public int[] G { get; private set; }
        public int[] B { get; private set; }

        public HistogramResult()
        {
            var len = 256;
            R = new int[len];
            G = new int[len];
            B = new int[len];
        }
    }
}
