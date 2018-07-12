using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public struct HSV
    {
        public double H { get; private set; }
        public double S { get; private set; }
        public double V { get; private set; }

        public HSV(double h, double s, double v)
        {
            H = MathUtils.Clamp(h, 0d, 360d);
            S = MathUtils.Clamp(s, 0d, 100d);
            V = MathUtils.Clamp(v, 0d, 100d);
        }

        public HSV(Pixel32 pixel)
        {
            var r = pixel.R;
            var g = pixel.G;
            var b = pixel.B;

            var cmin = MathUtils.Min(r, g, b);
            var cmax = MathUtils.Max(r, g, b);
            var delta = cmax - cmin;

            H = 0d;
            if (delta == 0)
                H = 0d;
            else if (cmax == r)
                H = (((g - b) / (double)delta) % 6) * 60;
            else if (cmax == g)
                H = (((b - r) / (double)delta) + 2) * 60;
            else if (cmax == b)
                H = (((r - g) / (double)delta) + 4) * 60;
            H = MathUtils.Clamp(H, 0d, 360d);

            S = 0d;
            if (cmax != 0)
                S = MathUtils.Clamp(100d * delta / cmax, 0d, 100d);

            V = MathUtils.Clamp(100d * cmax / 255d, 0d, 100d);
        }

        public Pixel32 GetPixel(byte alpha = 255)
        {
            var C = (S / 100d) * (V / 100d);
            var X = C * (1d - Math.Abs((H / 60d) % 2d - 1d));
            var m = V / 100d - C;

            double rp, gp, bp;
            if (H < 60d)
            {
                rp = C;
                gp = X;
                bp = 0d;
            }
            else if (H < 120d)
            {
                rp = X;
                gp = C;
                bp = 0d;
            }
            else if (H < 180d)
            {
                rp = 0d;
                gp = C;
                bp = X;
            }
            else if (H < 240d)
            {
                rp = 0d;
                gp = X;
                bp = C;
            }
            else if (H < 300d)
            {
                rp = X;
                gp = 0d;
                bp = C;
            }
            else
            {
                rp = C;
                gp = 0d;
                bp = X;
            }
            var r = MathUtils.RoundToByte(255 * (rp + m));
            var g = MathUtils.RoundToByte(255 * (gp + m));
            var b = MathUtils.RoundToByte(255 * (bp + m));
            return new Pixel32(alpha, r, g, b);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is HSV))
                return false;

            var other = (HSV)obj;
            return MathUtils.AreEqual(H, other.H) &&
                MathUtils.AreEqual(S, other.S) &&
                MathUtils.AreEqual(V, other.V);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
