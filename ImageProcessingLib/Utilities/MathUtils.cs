using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLib.Utilities
{
    public class MathUtils
    {
        public static byte RoundToByte(double value)
        {
            return ByteClamp(Math.Round(value));
        }

        public static int RoundToInt(double value)
        {
            return (int)Math.Round(value);
        }

        public static byte CeilToByte(double value)
        {
            return ByteClamp(Math.Ceiling(value));
        }

        public static int CeilToInt(double value)
        {
            return (int)Math.Ceiling(value);
        }

        public static byte FloorToByte(double value)
        {
            return ByteClamp(Math.Floor(value));
        }

        public static int FloorToInt(double value)
        {
            return (int)Math.Floor(value);
        }

        public static byte Max(byte val1, byte val2, byte val3)
        {
            return Math.Max(val1, Math.Max(val2, val3));
        }

        public static byte Min(byte val1, byte val2, byte val3)
        {
            return Math.Min(val1, Math.Min(val2, val3));
        }

        public static int Clamp(int value, int min, int max)
        {
            if (value > max)
                return max;
            if (value < min)
                return min;
            return value;
        }

        public static double Clamp(double value, double min, double max)
        {
            if (value > max)
                return max;
            if (value < min)
                return min;
            return value;
        }

        public static byte ByteClamp(int value)
        {
            return (byte)Clamp(value, byte.MinValue, byte.MaxValue);
        }

        public static byte ByteClamp(double value)
        {
            return (byte)Clamp(value, byte.MinValue, byte.MaxValue);
        }

        public static double DegToRad(double deg)
        {
            return deg * Math.PI / 180d;
        }

        public static double RadToDeg(double rad)
        {
            return rad * 180d / Math.PI;
        }

        public static void IsMaskSize(int maskSize)
        {
            if (maskSize < 3 || maskSize % 2 == 0)
                throw new ArgumentException("Mask size must be odd and not less than 3");
        }
    }
}
