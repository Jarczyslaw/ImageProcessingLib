using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLib
{
    public struct Pixel8 : IPixel<Pixel8>
    {
        public int Data { get { return Value; } }
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

        public Pixel8 From(int data)
        {
            return new Pixel8((byte)data);
        }

        public Pixel8 White
        {
            get { return new Pixel8(255); }
        }

        public Pixel8 Black
        {
            get { return new Pixel8(0); }
        }
    }
}
