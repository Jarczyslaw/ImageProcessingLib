using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public struct HSVSet
    {
        public double Hue { get; private set; }
        public double Saturation { get; private set; }
        public double Value { get; private set; }

        public HSVSet(double h, double s, double v)
        {
            Hue = h;
            Saturation = s;
            Value = v;
        }

        public HSVSet(Pixel32 pixel)
        {
            var r = pixel.R;
            var g = pixel.G;
            var b = pixel.B;

            var cmin = MathUtils.Min(r, g, b);
            var cmax = MathUtils.Max(r, g, b);
            var delta = cmax - cmin;

            Hue = 0d;
            if (delta == 0)
                Hue = 0d;
            else if (cmax == r)
                Hue = (((g - b) / (double)delta) % 6) * 60;
            else if (cmax == g)
                Hue = (((b - r) / (double)delta) + 2) * 60;
            else if (cmax == b)
                Hue = (((r - g) / (double)delta) + 4) * 60;

            Saturation = 0d;
            if (cmax != 0)
                Saturation = 100d * delta / cmax;

            Value = 100d * cmax / 255d;
        }
    }
}
