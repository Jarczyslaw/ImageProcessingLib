using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLib.Utilities
{
    public class BmpMarshal
    {
        public static int[] IntsFrom(Bitmap bmp)
        {
            var bytes = BytesFrom(bmp);
            var resultLen = bytes.Length / 3;
            var result = new int[resultLen];
            for(int i = 0; i < resultLen; i++)
            {
                var index = i * 3;
                result[i] = Color.FromArgb(255, bytes[i + 2], bytes[i + 1], bytes[i + 0]).ToArgb();
            }
            return result;
        }

        public static byte[] BytesFrom(Bitmap bmp)
        {
            var bitmapData = bmp.LockBits(BitmapRectangle(bmp), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            var length = 3 * bmp.Width * bmp.Height;
            var data = new byte[length];
            Marshal.Copy(bitmapData.Scan0, data, 0, length);
            bmp.UnlockBits(bitmapData);
            return data;
        }

        public static void BytesTo(Bitmap bmp, byte[] data)
        {
            var bitmapData = bmp.LockBits(BitmapRectangle(bmp), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            Marshal.Copy(data, 0, bitmapData.Scan0, data.Length);
            bmp.UnlockBits(bitmapData);
        }

        private static Rectangle BitmapRectangle(Bitmap bmp)
        {
            return new Rectangle(Point.Empty, new Size(bmp.Width, bmp.Height));
        }
    }
}
