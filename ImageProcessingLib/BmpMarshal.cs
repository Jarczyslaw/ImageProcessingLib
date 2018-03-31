using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ImageProcessingLib
{
    public class BmpMarshal
    {
        public static byte[] DataFromBmp(Bitmap bmp)
        {
            var bitmapData = bmp.LockBits(BitmapRectangle(bmp), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            var length = 3 * bmp.Width * bmp.Height;
            var data = new byte[length];
            Marshal.Copy(bitmapData.Scan0, data, 0, length);
            bmp.UnlockBits(bitmapData);
            return data;
        }

        public static Bitmap DataToBmp(byte[] data, int width, int height)
        {
            var bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            var bitmapData = bmp.LockBits(BitmapRectangle(bmp), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            Marshal.Copy(data, 0, bitmapData.Scan0, data.Length);
            bmp.UnlockBits(bitmapData);
            return bmp;
        }

        private static Rectangle BitmapRectangle(Bitmap bmp)
        {
            return new Rectangle(Point.Empty, new Size(bmp.Width, bmp.Height));
        }
    }
}
