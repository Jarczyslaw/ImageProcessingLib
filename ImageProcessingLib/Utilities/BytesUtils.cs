using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImageProcessingLib.Utilities
{
    public static class BytesUtils
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetDataFromArgb(byte a, byte r, byte g, byte b)
        {
            return a << 24 | r << 16 | g << 8 | b;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetArgbFromData(int data, out byte a, out byte r, out byte g, out byte b)
        {
            a = (byte)((data >> 24) & 0xFF);
            r = (byte)((data >> 16) & 0xFF);
            g = (byte)((data >> 8) & 0xFF);
            b = (byte)(data & 0xFF);
        }
    }
}
