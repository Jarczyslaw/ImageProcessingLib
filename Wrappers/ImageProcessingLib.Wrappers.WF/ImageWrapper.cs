using ImageProcessingLib.Utilities;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

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

        public static Bitmap CreateBitmap(Image<Pixel32> image)
        {
            var data = new int[image.Size];
            for (int i = 0; i < data.Length; i++)
            {
                var pixel = image.Get(i);
                data[i] = BytesUtils.GetDataFromArgb(pixel.A, pixel.R, pixel.G, pixel.B);
            }
            return CreateBitmapFromData(data, image.Width, image.Height);
        }

        private static Bitmap CreateBitmapFromData(int[] data, int width, int height)
        {
            var bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            var bmpData = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            Marshal.Copy(data, 0, bmpData.Scan0, width * height);
            bmp.UnlockBits(bmpData);
            return bmp;
        }

        public static Image<Pixel32> CreateImage(Bitmap bmp)
        {
            var bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            var length = bmp.Width * bmp.Height;
            var data = new int[length];
            Marshal.Copy(bmpData.Scan0, data, 0, length);
            bmp.UnlockBits(bmpData);
            return CreateImageFromData(data, bmp.Width, bmp.Height);
        }

        private static Image<Pixel32> CreateImageFromData(int[] data, int width, int height)
        {
            var result = new Image<Pixel32>(width, height);
            for (int i = 0; i < data.Length; i++)
            {
                BytesUtils.GetArgbFromData(data[i], out byte a, out byte r, out byte g, out byte b);
                result.Set(i, new Pixel32(a, r, g, b));
            }
            return result;
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
