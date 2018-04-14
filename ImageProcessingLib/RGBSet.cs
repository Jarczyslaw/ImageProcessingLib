using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLib
{
    public struct RGBSet : IEquatable<RGBSet>
    {
        public int Value { get; }
        public byte R { get; }
        public byte G { get; }
        public byte B { get; }


        public RGBSet(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
            Value = 0xFF << 24 | r << 16 | g << 8 | b;
        }

        public RGBSet(int r, int g, int b) : this((byte)r, (byte)g, (byte)b) { }

        public RGBSet(byte value) : this(value, value, value) { }

        public RGBSet(int value)
        {
            Value = value | (0xFF << 24);
            R = (byte)((value >> 16) & 0xFF);
            G = (byte)((value >> 8) & 0xFF);
            B = (byte)(value & 0xFF);
        }

        public RGBSet ToGrayscale()
        {
            var grayscale = MathUtils.RoundToByte(0.3d * R + 0.59d * G + 0.11d * B);
            return FromValue(grayscale);
        }

        public static RGBSet Red
        {
            get { return new RGBSet(255, 0, 0); }
        }

        public static RGBSet Green
        {
            get { return new RGBSet(0, 255, 0); }
        }

        public static RGBSet Blue
        {
            get { return new RGBSet(0, 0, 255); }
        }

        public static RGBSet White
        {
            get { return new RGBSet(255); }
        }

        public static RGBSet Black
        {
            get { return new RGBSet(0); }
        }

        public static RGBSet FromValue(byte value)
        {
            return new RGBSet(value, value, value);
        }

        public static RGBSet FromValue(int value)
        {
            return new RGBSet(value);
        }

        public static RGBSet FromValue(byte r, byte g, byte b)
        {
            return new RGBSet(r, g, b);
        }

        public static RGBSet FromValue(int r, int g, int b)
        {
            return new RGBSet(r, g, b);
        }

        public bool Equals(RGBSet other)
        {
            return Equals((object)other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;
            if (ReferenceEquals(obj, this))
                return true;
            if (obj.GetType() != GetType())
                return false;

            var other = (RGBSet)obj;
            return other.Value == Value;
        }

        public override int GetHashCode()
        {
            return Value;
        }

        public static bool operator ==(RGBSet set1, RGBSet set2)
        {
            return set1.Equals(set2);
        }

        public static bool operator !=(RGBSet set1, RGBSet set2)
        {
            return !(set1 == set2);
        }

        public override string ToString()
        {
            return string.Format("Red: {0}, Green: {1}, Blue: {2}, HEX: 0x{3:X8}", R, G, B, Value);
        }
    }
}
