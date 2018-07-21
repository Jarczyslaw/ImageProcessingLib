using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLib
{
    public struct Pixel8 : IPixel<Pixel8>, IEquatable<Pixel8>
    {
        public int Data { get; }
        public byte Value { get; }

        public Pixel8(byte value)
        {
            Value = value;
            Data = BytesUtils.GetDataFromArgb(byte.MaxValue, value, value, value);
        }

        public Pixel8(Pixel8 pixel) : this(pixel.Value) { }

        public Pixel8 Blank
        {
            get { return Black; }
        }

        public Pixel8 From(int data)
        {
            var value = BytesUtils.GetValueFromData(data);
            return new Pixel8(value);
        }

        public Pixel8 White
        {
            get { return new Pixel8(255); }
        }

        public Pixel8 Black
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
            return string.Format("Pixel8 - Data: {0}, Value: {1}", Data, Value);
        }

        public Pixel1 ToPixel1()
        {
            return new Pixel1(Value > 127);
        }

        public Pixel32 ToPixel32()
        {
            return new Pixel32(byte.MaxValue, Value, Value, Value);
        }
    }
}
