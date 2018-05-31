using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib.Utilities
{
    public static class GeometricUtils
    {
        public static bool SectionsCommon(int a, int b, int c, int d)
        {
            return SectionsCommon(a, b, c, d, out int m, out int n);
        }

        public static bool SectionsCommon(int a, int b, int c, int d,
            out int m, out int n)
        {
            m = Math.Max(a, c);
            n = Math.Min(b, d);
            return m <= n;
        }
    }
}
