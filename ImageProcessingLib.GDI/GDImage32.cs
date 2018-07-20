using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLib.GDI
{
    public class GDImage32 : IDisposable
    {
        public Image<Pixel32> Image { get; private set; }
        public Bitmap Bitmap { get; private set; }

        private GCHandle dataHandle;

        private bool disposed = false;

        public GDImage32(int width, int height)
        {
            Image = new Image<Pixel32>(width, height);
            Initialize(Image);
        }

        public GDImage32(Image<Pixel8> image)
        {
            var image32 = image.CopyAs(p => p.ToPixel32());
            Initialize(image32);
        }

        public GDImage32(Image<Pixel32> image)
        {
            Initialize(image);
        }

        public GDImage32(string filePath)
        {
            using (var bmp = new Bitmap(filePath))
            {
                FromBitmap(bmp);
            }
        }

        public GDImage32(Bitmap bitmap)
        {
            FromBitmap(bitmap);
        }

        private void FromBitmap(Bitmap bitmap)
        {
            Image = new Image<Pixel32>(bitmap.Width, bitmap.Height);
            Initialize(Image);
            GraphicsUtils.Copy(bitmap, Bitmap);
        }

        private void Initialize(Image<Pixel32> image)
        {
            Image = image;
            Image.OnResize += CreateBitmap;
            CreateBitmap();
        }

        private void CreateBitmap()
        {
            ReleaseResources();
            dataHandle = GCHandle.Alloc(Image.Data, GCHandleType.Pinned);
            Bitmap = new Bitmap(Image.Width, Image.Height, Image.Width * 4, PixelFormat.Format32bppArgb, dataHandle.AddrOfPinnedObject());
        }

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

        public void Dispose()
        {
            if (disposed)
                return;

            ReleaseResources();
            disposed = true;
        }

        private void ReleaseResources()
        {
            if (dataHandle != null && dataHandle.IsAllocated)
                dataHandle.Free();
            Bitmap?.Dispose();
        }
    }
}
