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
            C = MathUtils.Clamp(c, 0d, 100d);
            M = MathUtils.Clamp(m, 0d, 100d);
            Y = MathUtils.Clamp(y, 0d, 100d);
            K = MathUtils.Clamp(k, 0d, 100d);
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
            var q = 1d - K / 100d;
            var r = MathUtils.RoundToByte(255d * (1d - C / 100d) * q);
            var g = MathUtils.RoundToByte(255d * (1d - M / 100d) * q);
            var b = MathUtils.RoundToByte(255d * (1d - Y / 100d) * q);
            return new Pixel32(alpha, r, g, b);
        }

        private double GetComponent(double nc, double den)
        {
            return MathUtils.Clamp(100d * (-nc / den + 1d), 0d, 100d);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is CMYK))
                return false;

            var other = (CMYK)obj;
            return MathUtils.AreEqual(C, other.C) && 
                MathUtils.AreEqual(M, other.M) && 
                MathUtils.AreEqual(Y, other.Y) &&
                MathUtils.AreEqual(K, other.K);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
