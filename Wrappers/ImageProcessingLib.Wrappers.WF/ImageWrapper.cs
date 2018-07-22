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
    public class ImageWrapper : IDisposable
    {
        private Bitmap bitmap = null;
        public Bitmap Bitmap
        {
            get
            {
                if (bitmap == null)
                    bitmap = CreateBitmap(image32);
                return bitmap;
            }
        }

        private Image<Pixel32> image32 = null;
        public Image<Pixel32> Image32
        {
            get
            {
                if (image32 == null)
                    image32 = CreateImage(bitmap);
                return image32;
            }
        }

        public bool Disposed { get; private set; } = false;

        public ImageWrapper(string filePath)
        {
            bitmap = new Bitmap(filePath);
        }

        public ImageWrapper(Bitmap bitmap)
        {
            this.bitmap = new Bitmap(bitmap.Width, bitmap.Height, PixelFormat.Format32bppArgb);
            GraphicsUtils.Copy(bitmap, this.bitmap);
        }

        public ImageWrapper(Image<Pixel32> image)
        {
            image32 = image;
        }

        public void ToFile(string filePath)
        {
            ToFile(filePath, ImageFormat.Bmp);
        }

        public void ToFile(string filePath, ImageFormat format)
        {
            Bitmap.Save(filePath, format);
        }

        private Bitmap CreateBitmap(Image<Pixel32> image)
        {
            var bmp = new Bitmap(image.Width, image.Height, PixelFormat.Format32bppArgb);
            var bmpData = bmp.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            Marshal.Copy(image.Data, 0, bmpData.Scan0, image.Width * image.Height);
            bmp.UnlockBits(bmpData);
            return bmp;
        }

        private Image<Pixel32> CreateImage(Bitmap bitmap)
        {
            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            var length = bitmap.Width * bitmap.Height;
            var data = new int[length];
            Marshal.Copy(bitmapData.Scan0, data, 0, length);
            bitmap.UnlockBits(bitmapData);
            return new Image<Pixel32>(data, Bitmap.Width, Bitmap.Height);
        }

        public void Dispose()
        {
            if (Disposed)
                return;

            if (bitmap != null)
                bitmap.Dispose();
            Disposed = true;
        }
    }
}
