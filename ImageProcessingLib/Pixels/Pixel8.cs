using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLib
{
    public struct Pixel8 : IEquatable<Pixel8>
    {
        public byte Value { get; }

        public Pixel8(byte value)
        {
            Value = value;
        }

        public Pixel8(Pixel8 pixel) : this(pixel.Value) { }

        public Pixel8 Blank
        {
            get { return Black; }
        }

        public static Pixel8 White
        {
            get { return new Pixel8(255); }
        }

        public static Pixel8 Black
        {
            get { return new Pixel8(0); }
        }

        public bool Equals(Pixel8 other)
        {
            return other.Value == Value;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Pixel8))
                return false;

            return Equals((Pixel8)obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(Pixel8 set1, Pixel8 set2)
        {
            return set1.Equals(set2);
        }

        public static bool operator !=(Pixel8 set1, Pixel8 set2)
        {
            return !(set1 == set2);
        }

        public override string ToString()
        {
            return string.Format("Pixel8 - Value: {0}", Value);
        }

        public Pixel1 ToPixel1()
        {
            return new Pixel1(Value > 127);
        }

        public Pixel32 ToPixel32(byte alpha = 255)
        {
            return new Pixel32(alpha, Value, Value, Value);
        }
    }
}
