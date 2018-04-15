using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLib
{
    public abstract class ImageBase : IDisposable, IEquatable<ImageBase>
    {
        public int Width { get; protected set; }
        public int Height { get; protected set; }
        public int Size { get { return Width * Height; } }
        public int DataSize { get { return data.Length; } }
        public Bitmap Bitmap { get; protected set; }

        protected int[] data;
        public ReadOnlyCollection<int> Data
        {
            get { return Array.AsReadOnly(data); }
        }

        private GCHandle dataHandle;
        private bool disposed;

        public void Graphics(Action<Graphics> action)
        {
            using (var graphics = System.Drawing.Graphics.FromImage(Bitmap))
            {
                action(graphics);
            }
        }

        public void ToFile(string filePath)
        {
            ToFile(filePath, ImageFormat.Bmp);
        }

        public void ToFile(string filePath, ImageFormat format)
        {
            Bitmap.Save(filePath, format);
        }

        public void ForEach(Action<int, int> action)
        {
            for (int i = 0; i < Height; i++)
                for (int j = 0; j < Width; j++)
                    action(j, i);
        }

        public void ForSegment(int segment, int segmentsCount, Action<int, int> action)
        {
            float len = (float)Height / segmentsCount;
            int start = (int)Math.Round(segment * len);
            int end = (int)Math.Round((segment + 1) * len);
            for (int i = start; i < end; i++)
            {
                for (int j = 0; j < Width; j++)
                    action(j, i);
            }
        }

        protected void CreateNew(int width, int height)
        {
            SetSizes(width, height);
            var data = new int[width * height];
            Initialize(data);
        }

        protected void CreateFromExisting(ImageBase img)
        {
            SetSizes(img.Width, img.Height);
            var data = new int[img.Size];
            img.Data.CopyTo(data, 0);
            Initialize(data);
        }

        protected void SetSizes(int width, int height)
        {
            Width = width;
            Height = height;
        }

        protected void Initialize(int[] data)
        {
            this.data = data;
            dataHandle = GCHandle.Alloc(this.data, GCHandleType.Pinned);
            Bitmap = new Bitmap(Width, Height, Width * 4, PixelFormat.Format32bppArgb, dataHandle.AddrOfPinnedObject());
        }

        public void Clear()
        {
            Clear(RGBSet.Black.Value);
        }

        public void Clear(int value)
        {
            int len = data.Length;
            for (int i = 0; i < len; i++)
                data[i] = value;
        }

        public void RemoveAlpha()
        {
            int mask = 0xFF << 24;
            int len = data.Length;
            for (int i = 0; i < len; i++)
                data[i] |= mask;
        }

        protected void SetValue(int x, int y, RGBSet value)
        {
            int index = x + y * Width;
            data[index] = value.Value;
        }

        protected void SetValue(int x, int y, byte value)
        {
            int index = x + y * Width;
            data[index] = RGBSet.FromValue(value).Value;
        }

        protected RGBSet GetValue(int x, int y)
        {
            int index = x + y * Width;
            return RGBSet.FromValue(data[index]);
        }

        public void Swap(int sourceX, int sourceY, int destinationX, int destinationY)
        {
            int sourceIndex = sourceX + sourceY * Width;
            int destinationIndex = destinationX + destinationY * Width;
            var temp = data[sourceIndex];
            data[sourceIndex] = data[destinationIndex];
            data[destinationIndex] = temp;
        }

        public void Dispose()
        {
            if (disposed)
                return;

            Bitmap.Dispose();
            dataHandle.Free();
            disposed = true;
        }

        public bool Equals(ImageBase other)
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

            var other = (ImageBase)obj;
            if (other.Width != Width || other.Height != Height)
                return false;
            return Enumerable.SequenceEqual(other.data, data);
        }

        public override int GetHashCode()
        {
            int hash = 0;
            int len = data.Length;
            for (int i = 0; i < len; i++)
                hash ^= data[i].GetHashCode();
            return hash;
        }

        public static bool operator ==(ImageBase image1, ImageBase image2)
        {
            return image1.Equals(image2);
        }

        public static bool operator !=(ImageBase image1, ImageBase image2)
        {
            return !(image1 == image2);
        }
    }
}
