using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ImageProcessingLib.Converter.WPF
{
    public static class IPLConverter
    {
        public static BitmapSource CreateBitmapFromImage(Image<Pixel32> image)
        {
            var data = GetDataFromImage(image);
            var dpi = 96;
            var stride = image.Width * 4;
            return BitmapSource.Create(image.Width, image.Height, dpi, dpi, PixelFormats.Bgra32, null, data, stride);
        }

        public static Image<Pixel32> CreateImageFromBitmap(BitmapSource bitmap)
        {
            if (bitmap.Format != PixelFormats.Bgra32)
                throw new ArgumentException("Only Brga32 format is allowed");

            var width = bitmap.PixelWidth;
            var height = bitmap.PixelHeight;
            var stride = width * 4;
            var data = new byte[stride * height];
            bitmap.CopyPixels(data, stride, 0);
            return CreateImageFromData(data, width, height);
        }

        private static Image<Pixel32> CreateImageFromData(byte[] data, int width, int height)
        {
            var image = new Image<Pixel32>(width, height);
            for (int i = 0; i < image.Size; i++)
            {
                int index = i * 4;
                var b = data[index];
                var g = data[index + 1];
                var r = data[index + 2];
                var a = data[index + 3];
                image.Set(i, new Pixel32(a, r, g, b));
            }
            return image;
        }

        private static byte[] GetDataFromImage(Image<Pixel32> image)
        {
            var data = new byte[image.Size * 4];
            for (int i = 0; i < image.Size; i++)
            {
                int index = i * 4;
                var pixel = image.Get(i);
                data[index] = pixel.B;
                data[index + 1] = pixel.G;
                data[index + 2] = pixel.R;
                data[index + 3] = pixel.A;
            }
            return data;
        }
    }
}
