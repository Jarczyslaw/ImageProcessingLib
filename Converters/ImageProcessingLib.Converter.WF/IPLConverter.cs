using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLib.Converter.WF
{
    public static class IPLConverter
    {
        public static Bitmap CreateBitmapFromImage(Image<Pixel32> image)
        {
            var data = new int[image.Size];
            for (int i = 0; i < data.Length; i++)
            {
                var pixel = image.Get(i);
                data[i] = BytesUtils.GetDataFromArgb(pixel.A, pixel.R, pixel.G, pixel.B);
            }
            return CreateBitmapFromData(data, image.Width, image.Height);
        }

        public static Image<Pixel32> CreateImageFromBitmap(Bitmap bitmap)
        {
            var bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            var length = bitmap.Width * bitmap.Height;
            var data = new int[length];
            Marshal.Copy(bmpData.Scan0, data, 0, length);
            bitmap.UnlockBits(bmpData);
            return CreateImageFromData(data, bitmap.Width, bitmap.Height);
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

        private static Bitmap CreateBitmapFromData(int[] data, int width, int height)
        {
            var bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            var bmpData = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            Marshal.Copy(data, 0, bmpData.Scan0, width * height);
            bmp.UnlockBits(bmpData);
            return bmp;
        }
    }
}
