using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLib
{
    public struct RGBSet : IEquatable<RGBSet>
    {
        private int value;
        public int Value { get { return value; } }
        private byte r;
        public byte R { get { return r; } }
        private byte g;
        public byte G { get { return g; } }
        private byte b;
        public byte B { get { return b; } }


        public RGBSet(byte r, byte g, byte b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            value = 0xFF << 24 | r << 16 | g << 8 | b;
        }

        public RGBSet(int r, int g, int b) : this((byte)r, (byte)g, (byte)b) { }

        public RGBSet(byte value) : this(value, value, value) { }

        public RGBSet(int value)
        {
            this.value = value | (0xFF << 24);
            r = (byte)((value >> 16) & 0xFF);
            g = (byte)((value >> 8) & 0xFF);
            b = (byte)(value & 0xFF);
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
            return other.value == value;
        }

        public override int GetHashCode()
        {
            return value;
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
            return string.Format("Red: {0}, Green: {1}, Blue: {2}, HEX: 0x{3:X8}", r, g, b, value);
        }
    }
}
