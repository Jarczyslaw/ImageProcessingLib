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
            H = h;
            S = s;
            V = v;
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
    }
}
