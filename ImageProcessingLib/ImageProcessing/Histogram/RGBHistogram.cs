using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ImageProcessingLib
{
    public class RGBHistogram
    {
        public Histogram R { get; private set; }
        public Histogram G { get; private set; }
        public Histogram B { get; private set; }

        public RGBHistogram()
        {
            R = new Histogram();
            G = new Histogram();
            B = new Histogram();
        }
    }
}
