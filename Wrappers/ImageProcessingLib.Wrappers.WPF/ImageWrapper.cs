using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ImageProcessingLib.Wrappers.WPF
{
    public class ImageWrapper
    {
        private BitmapSource bitmapSource = null;
        public BitmapSource BitmapSource
        {
            get
            {
                if (bitmapSource == null)
                    bitmapSource = CreateBitmapSource(image32);
                return bitmapSource;
            }
        }

        private Image<Pixel32> image32 = null;
        public Image<Pixel32> Image32
        {
            get
            {
                if (image32 == null)
                    image32 = CreateImage(bitmapSource);
                return image32;
            }
        }

        public ImageWrapper(string filePath)
        {
            bitmapSource = CreateBitmapSourceFromFile(filePath);
        }

        public ImageWrapper(BitmapSource bitmapSource)
        {
            this.bitmapSource = bitmapSource.Clone();
        }

        public ImageWrapper(Image<Pixel32> image)
        {
            image32 = image;
        }

        public void ToFile(string filePath)
        {
            var encoder = new BmpBitmapEncoder();
            ToFile(filePath, encoder);
        }

        public void ToFile(string filePath, BitmapEncoder encoder)
        {
            encoder.Frames.Add(BitmapFrame.Create(BitmapSource));
            using (var fileStream = new FileStream(filePath, FileMode.Create))
                encoder.Save(fileStream);
        }

        public static BitmapSource CreateBitmapSource(Image<Pixel32> img)
        {
            var bytes = new byte[img.Data.Length * 4];
            for (int i = 0; i < img.Data.Length; i++)
            {
                int index = i * 4;
                var pixel = img.Get(i);
                bytes[index] = pixel.B;
                bytes[index + 1] = pixel.G;
                bytes[index + 2] = pixel.R;
                bytes[index + 3] = pixel.A;
            }
            var dpi = 96;
            var stride = img.Width * 4;
            return BitmapSource.Create(img.Width, img.Height, dpi, dpi, PixelFormats.Bgra32, null, bytes, stride);
        }

        private BitmapSource CreateBitmapSourceFromFile(string filePath)
        {
            var bitmapImage = new BitmapImage(new Uri(filePath));

            var result = new FormatConvertedBitmap();
            result.BeginInit();
            result.Source = bitmapImage;
            result.DestinationFormat = PixelFormats.Bgra32;
            result.EndInit();
            return result;
        }

        public static Image<Pixel32> CreateImage(BitmapSource bmp)
        {
            if (bmp.Format != PixelFormats.Bgra32)
                throw new ArgumentException("Only Brga32 format is allowed");

            var width = bmp.PixelWidth;
            var height = bmp.PixelHeight;
            var stride = width * 4;
            var bytes = new byte[stride * height];
            bmp.CopyPixels(bytes, stride, 0);

            var img = new Image<Pixel32>(width, height);
            for (int i = 0; i < img.Size; i++)
            {
                int index = i * 4;
                var b = bytes[index];
                var g = bytes[index + 1];
                var r = bytes[index + 2];
                var a = bytes[index + 3];
                img.Set(i, new Pixel32(a, r, g, b));
            }
            return img;
        }
    }
}
