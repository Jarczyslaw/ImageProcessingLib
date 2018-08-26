using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace ImageProcessingLib.Converter.WF.WPF
{
    public static class ImageProcessingLibConverter
    {
        public static BitmapSource FromBitmap(Bitmap bitmap)
        {
            var bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(bitmap.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            return bitmapSource;
        }

        public static Bitmap FromBitmapSource(BitmapSource bitmapSource)
        {
            var format = PixelFormat.Format32bppArgb;
            var bitmap = new Bitmap(bitmapSource.PixelWidth, bitmapSource.PixelHeight, format);
            var bitmapData = bitmap.LockBits(new Rectangle(System.Drawing.Point.Empty, bitmap.Size), ImageLockMode.WriteOnly, format);
            bitmapSource.CopyPixels(Int32Rect.Empty, bitmapData.Scan0, bitmapData.Stride * bitmapData.Height, bitmapData.Stride);
            bitmap.UnlockBits(bitmapData);
            return bitmap;
        }
    }
}
