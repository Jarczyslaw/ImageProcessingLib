using ImageProcessingLib.Utilities;
using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ImageProcessingLib
{
    public class Image<TPixelType> : IEquatable<Image<TPixelType>>
    {
        public TPixelType[] Pixels { get; protected set; }
        public int Width { get; protected set; }
        public int Height { get; protected set; }
        public int Size
        {
            get
            {
                return Width * Height;
            }
        }
        
        public Image(int width, int height)
        {
            Initialize(width, height);
        }

        public Image(int width, int height, TPixelType clearPixel)
        {
            Initialize(width, height, clearPixel);
        }

        public Image(Image<TPixelType> image) : this(image.Width, image.Height)
        {
            Pixels = (TPixelType[])image.Pixels.Clone();
        }

        public void Initialize(int width, int height)
        {
            Width = width;
            Height = height;
            Pixels = new TPixelType[Size];
        }

        public void Initialize(int width, int height, TPixelType clearPixel)
        {
            Initialize(width, height);
            ClearExtension.Clear(this, clearPixel);
        }

        public TPixelType Get(int i)
        {
            return Pixels[i];
        }

        public TPixelType Get(int x, int y)
        {
            var index = GetIndex(x, y);
            return Pixels[index];
        }

        public TPixelType[] GetNeighbourhood(int x, int y, int range)
        {
            var size = 1 + 2 * range;
            var result = new TPixelType[size * size];

            var startX = x - range;
            var endX = x + range;
            var startY = y - range;
            var endY = y + range;
            int index = 0;
            for (int i = startY; i <= endY; i++)
                for (int j = startX; j <= endX; j++)
                    result[index++] = Get(ClampWidth(j), ClampHeight(i));
            return result;
        }

        public void Set(int i, TPixelType pixel)
        {
            Pixels[i] = pixel;
        }

        public void Set(int x, int y, TPixelType pixel)
        {
            var index = GetIndex(x, y);
            Pixels[index] = pixel;
        }

        public TPixelType this[int i]
        {
            get { return Get(i); }
            set { Set(i, value); }
        }

        public TPixelType this[int x, int y]
        {
            get { return Get(x, y); }
            set { Set(x, y, value); }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected int GetIndex(int x, int y)
        {
            return x + y * Width;
        }

        public int ClampWidth(int value)
        {
            return MathUtils.Clamp(value, 0, Width - 1);
        }

        public int ClampHeight(int value)
        {
            return MathUtils.Clamp(value, 0, Height - 1);
        }

        public bool ExceedsWidth(int value)
        {
            return value < 0 || value >= Width;
        }

        public bool ExceedsHeight(int value)
        {
            return value < 0 || value >= Height;
        }

        public void GetCenter(out int x, out int y)
        {
            x = Width / 2;
            y = Height / 2;
        }

        public bool Equals(Image<TPixelType> other)
        {
            if (other.Width != Width || other.Height != Height)
                return false;
            return Enumerable.SequenceEqual(other.Pixels, Pixels);
        }

        public override bool Equals(object obj)
        {
            var img = obj as Image<TPixelType>;
            if (obj == null)
                return false;
            return Equals(img);
        }

        public override int GetHashCode()
        {
            int hash = 0;
            int len = Pixels.Length;
            for (int i = 0; i < len; i++)
                hash ^= Pixels[i].GetHashCode();
            return hash;
        }

        public override string ToString()
        {
            return string.Format("Image<{0}> {1}x{2}", nameof(TPixelType), Width, Height);
        }
    }
}
