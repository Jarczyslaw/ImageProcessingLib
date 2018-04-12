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
        protected int width;
        public int Width
        {
            get { return width; }
        }

        protected int height;
        public int Height
        {
            get { return height; }
        }

        public int Size
        {
            get { return width * height; }
        }

        public int DataSize
        {
            get { return data.Length; }
        }

        protected int[] data;
        public ReadOnlyCollection<int> Data
        {
            get { return Array.AsReadOnly(data); }
        }

        protected Bitmap bitmap;
        public Bitmap Bitmap
        {
            get { return bitmap; }
        }

        private GCHandle dataHandle;
        private bool disposed;

        public void ToFile(string filePath)
        {
            ToFile(filePath, ImageFormat.Bmp);
        }

        public void ToFile(string filePath, ImageFormat format)
        {
            bitmap.Save(filePath, format);
        }

        public void ForEach(Action<int, int> action)
        {
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    action(j, i);
        }

        public void ForSegment(int segment, int segmentsCount, Action<int, int> action)
        {
            float len = (float)height / segmentsCount;
            int start = (int)Math.Round(segment * len);
            int end = (int)Math.Round((segment + 1) * len);
            for (int i = start; i < end; i++)
            {
                for (int j = 0; j < width; j++)
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
            this.width = width;
            this.height = height;
        }

        protected void Initialize(int[] data)
        {
            this.data = data;
            dataHandle = GCHandle.Alloc(this.data, GCHandleType.Pinned);
            bitmap = new Bitmap(width, height, width * 4, PixelFormat.Format32bppArgb, dataHandle.AddrOfPinnedObject());
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
            int index = x + y * width;
            data[index] = value.Value;
        }

        protected void SetValue(int x, int y, byte value)
        {
            int index = x + y * width;
            data[index] = RGBSet.FromValue(value).Value;
        }

        protected RGBSet GetValue(int x, int y)
        {
            int index = x + y * width;
            return RGBSet.FromValue(data[index]);
        }

        public void Dispose()
        {
            if (disposed)
                return;

            bitmap.Dispose();
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
            if (other.width != width || other.height != height)
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
