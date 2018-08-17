using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public struct Pixel1 : IEquatable<Pixel1>
    {
        public bool Value { get; }

        public Pixel1(bool value)
        {
            Value = value;
        }

        public Pixel1(Pixel1 pixel) : this(pixel.Value) { }

        public Pixel1 Blank
        {
            get { return Black; }
        }

        public static Pixel1 White
        {
            get { return new Pixel1(true); }
        }

        public static Pixel1 Black
        {
            get { return new Pixel1(false); }
        }

        public bool Equals(Pixel1 other)
        {
            return other.Value == Value;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Pixel1))
                return false;

            return Equals((Pixel1)obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(Pixel1 set1, Pixel1 set2)
        {
            return set1.Equals(set2);
        }

        public static bool operator !=(Pixel1 set1, Pixel1 set2)
        {
            return !(set1 == set2);
        }

        public override string ToString()
        {
            return string.Format("Pixel1 - Value: {0}", Value);
        }

        public Pixel8 ToPixel8()
        {
            byte val = Value ? byte.MaxValue : byte.MinValue;
            return new Pixel8(val);
        }

        public Pixel32 ToPixel32(byte alpha = 255)
        {
            byte val = Value ? byte.MaxValue : byte.MinValue;
            return new Pixel32(alpha, val, val, val);
        }
    }
}
