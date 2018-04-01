using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ImageProcessingLib.Utilities
{
    public class BmpUtils
    {
        public static RGBValue[][] RGBValuesFrom(Bitmap bmp)
        {
            var data = BytesFrom(bmp, out int width, out int height);
            var result = JaggedArrayUtils.Create<RGBValue>(width, height);
            for(int i = 0; i < width; i++)
            {
                for(int j = 0; j < height; j++)
                {
                    var index = i * height + j;
                    var val = new RGBValue()
                    {
                        r = data[index + 2],
                        g = data[index + 1],
                        b = data[index]
                    };
                    result[i][j] = val;
                }
            }
            return result;
        }

        public static byte[] BytesFrom(Bitmap bmp, out int width, out int height)
        {
            width = bmp.Width;
            height = bmp.Height;
            var bitmapData = bmp.LockBits(BitmapRectangle(bmp), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            var length = 3 * bmp.Width * bmp.Height;
            var data = new byte[length];
            Marshal.Copy(bitmapData.Scan0, data, 0, length);
            bmp.UnlockBits(bitmapData);
            return data;
        }

        public static Bitmap RGBValuesTo(RGBValue[][] data, int width, int height)
        {
            var bytesData = new byte[3 * width * height];
            for(int i = 0;i < width;i++)
            {
                for(int j = 0;j < height; j++)
                {
                    var index = i * height + j;
                    var val = data[i][j];
                    bytesData[index] = val.r;
                    bytesData[index + 1] = val.g;
                    bytesData[index + 2] = val.b;
                }
            }
            return DataToBmp(bytesData, width, height);
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
