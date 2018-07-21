using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public class Pixel1 : IPixel<Pixel1>, IEquatable<Pixel1>
    {
        public int Data { get; }
        public bool Value { get; }

        public Pixel1(bool value)
        {
            Value = value;
            var val = value ? byte.MaxValue : byte.MinValue;
            Data = BytesUtils.GetDataFromArgb(255, val, val, val);
        }

        public Pixel1(Pixel1 pixel) : this(pixel.Value) { }

        public Pixel1 Blank
        {
            get { return Black; }
        }

        public Pixel1 From(int data)
        {
            var val = BytesUtils.GetValueFromData(data);
            return new Pixel1(val > 127);
        }

        public Pixel1 White
        {
            get { return new Pixel1(true); }
        }

        public Pixel1 Black
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
            return string.Format("Pixel1 - Data: {0}, Value: {1}", Data, Value);
        }

        public Pixel8 ToPixel8()
        {
            byte val = Value ? byte.MaxValue : byte.MinValue;
            return new Pixel8(val);
        }

        public Pixel32 ToPixel32()
        {
            byte val = Value ? byte.MaxValue : byte.MinValue;
            return new Pixel32(byte.MaxValue, val, val, val);
        }
    }
}
