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
    public class GDImage : IDisposable
    {
        public Image32 Image { get; private set; }
        public Bitmap Bitmap { get; private set; }

        private GCHandle dataHandle;

        private bool disposed = false;

        public GDImage(int width, int height)
        {
            Image = new Image32(width, height);
            Initialize();
        }

        public GDImage(Image32 image)
        {
            Image = image;
            Initialize();
        }

        public GDImage(string filePath)
        {
            using (var bmp = new Bitmap(filePath))
            {
                FromBitmap(bmp);
            }
        }

        public GDImage(Bitmap bitmap)
        {
            FromBitmap(bitmap);
        }

        private void FromBitmap(Bitmap bitmap)
        {
            Image = new Image32(bitmap.Width, bitmap.Height);
            Initialize();
            GraphicsUtils.Copy(bitmap, Bitmap);
        }

        private void Initialize()
        {
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

            dataHandle.Free();
            Bitmap.Dispose();
            disposed = true;
        }
    }
}
