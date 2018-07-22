using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLib.Wrappers.WF
{
    public class DynamicImageWrapper : IDisposable
    {
        public Image<Pixel32> Image { get; private set; }
        public Bitmap Bitmap { get; private set; }

        public bool Disposed { get; private set; } = false;
        private GCHandle dataHandle;

        public DynamicImageWrapper(int width, int height)
        {
            Image = new Image<Pixel32>(width, height);
            Initialize(Image);
        }

        public DynamicImageWrapper(string filePath)
        {
            using (var bmp = new Bitmap(filePath))
                FromBitmap(bmp);
        }

        public DynamicImageWrapper(Bitmap bitmap)
        {
            FromBitmap(bitmap);
        }

        public DynamicImageWrapper(Image<Pixel32> image)
        {
            Initialize(image);
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
                action(graphics);
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
            if (Disposed)
                return;

            ReleaseResources();
            Disposed = true;
        }

        private void ReleaseResources()
        {
            if (dataHandle != null && dataHandle.IsAllocated)
                dataHandle.Free();
            Bitmap?.Dispose();
        }
    }
}
