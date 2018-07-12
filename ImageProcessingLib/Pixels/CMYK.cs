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
            K = MathUtils.Clamp(100d * K, 0d, 100d);
        }

        public Pixel32 GetPixel(byte alpha = 255)
        {
            var q = 100d - K;
            var r = MathUtils.RoundToByte(255d * (100d - C) * q);
            var g = MathUtils.RoundToByte(255d * (100d - M) * q);
            var b = MathUtils.RoundToByte(255d * (100d - Y * q));
            return new Pixel32(alpha, r, g, b);
        }

        private double GetComponent(double nc, double den)
        {
            return MathUtils.Clamp(100d * (-nc / den + 1d), 0d, 100d);
        }
    }
}
