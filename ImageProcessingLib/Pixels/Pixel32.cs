using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLib
{
    public struct Pixel32 : IPixel<Pixel32>, IEquatable<Pixel32>
    {
        public int Data { get; }
        public byte A { get; }
        public byte R { get; }
        public byte G { get; }
        public byte B { get; }

        public Pixel32(byte a, byte r, byte g, byte b)
        {
            A = a;
            R = r;
            G = g;
            B = b;
            Data = a << 24 | r << 16 | g << 8 | b;
        }

        public Pixel32(byte r, byte g, byte b) : this(byte.MaxValue, r, g, b) { }

        public Pixel32(byte grayscale) : this(byte.MaxValue, grayscale, grayscale, grayscale) { }

        public Pixel32(byte alpha, byte grayscale) : this(alpha, grayscale, grayscale, grayscale) { }

        public Pixel32(int data)
        {
            Data = data;
            A = (byte)((data >> 24) & 0xFF);
            R = (byte)((data >> 16) & 0xFF);
            G = (byte)((data >> 8) & 0xFF);
            B = (byte)(data & 0xFF);
        }

        public Pixel32(Pixel32 pixel) : this(pixel.A, pixel.R, pixel.G, pixel.B) { }

        public Pixel32 From(int data)
        {
            return new Pixel32(data);
        }

        public Pixel32 SetAlpha(byte value)
        {
            return new Pixel32(value, R, G, B);
        }

        public Pixel32 SetR(byte value)
        {
            return new Pixel32(A, value, G, B);
        }

        public Pixel32 SetG(byte value)
        {
            return new Pixel32(A, R, value, B);
        }

        public Pixel32 SetB(byte value)
        {
            return new Pixel32(A, R, G, value);
        }

        public Pixel32 ToGrayscale()
        {
            var grayscale = MathUtils.RoundToByte(0.3d * R + 0.59d * G + 0.11d * B);
            return new Pixel32(grayscale, R, G, B);
        }

        public static Pixel32 Red
        {
            get { return new Pixel32(255, 0, 0); }
        }

        public static Pixel32 Green
        {
            get { return new Pixel32(0, 255, 0); }
        }

        public static Pixel32 Blue
        {
            get { return new Pixel32(0, 0, 255); }
        }

        public static Pixel32 White
        {
            get { return new Pixel32(255); }
        }

        public static Pixel32 Black
        {
            get { return new Pixel32(0); }
        }

        public Pixel32 Blank
        {
            get { return Black; }
        }

        public bool Equals(Pixel32 other)
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

            var other = (Pixel32)obj;
            return other.Data == Data;
        }

        public override int GetHashCode()
        {
            return Data;
        }

        public static bool operator ==(Pixel32 set1, Pixel32 set2)
        {
            return set1.Equals(set2);
        }

        public static bool operator !=(Pixel32 set1, Pixel32 set2)
        {
            return !(set1 == set2);
        }

        public override string ToString()
        {
            return string.Format("Red: {0}, Green: {1}, Blue: {2}, HEX: 0x{3:X8}", R, G, B, Data);
        }
    }
}
