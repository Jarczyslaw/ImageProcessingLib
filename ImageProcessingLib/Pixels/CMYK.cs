using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public struct CMYK
    {
        public double C { get; private set; }
        public double M { get; private set; }
        public double Y { get; private set; }
        public double K { get; private set; }

        public CMYK(double c, double m, double y, double k)
        {
            C = c;
            M = m;
            Y = y;
            K = k;
        }

        public CMYK(Pixel32 pixel)
        {
            var nr = pixel.R / 255d;
            var ng = pixel.G / 255d;
            var nb = pixel.B / 255d;

            K = 1d - MathUtils.Max(nr, ng, nb);
            var den = 1d - K;
            C = M = Y = 0d;
            if (den != 0d)
            {
                C = GetComponent(nr, den);
                M = GetComponent(ng, den);
                Y = GetComponent(nb, den);
            }
            K = 100d * K;
        }

        private double GetComponent(double nc, double den)
        {
            return 100d * (-nc / den + 1d);
        }
    }
}
