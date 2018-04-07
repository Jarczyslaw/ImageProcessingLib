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
    public abstract class ImageBase : IDisposable
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

        public void ForEach(Action<int, int> action)
        {
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    action(j, i);
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
            int pixel = data[index];
            return RGBSet.FromValue(pixel);
        }

        public void Dispose()
        {
            if (disposed)
                return;
            disposed = true;
            bitmap.Dispose();
            dataHandle.Free();
        }
    }
}
