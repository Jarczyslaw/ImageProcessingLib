using ImageProcessingLib;
using ImageProcessingLib.Converter.WF;
using System;
using System.Drawing;

namespace ImageProcessingLibExamples
{
    public class ImageWrapper : IDisposable
    {
        public Image<Pixel32> Image { get; private set; }
        public Bitmap Bitmap { get; private set; }

        public ImageWrapper(Bitmap bitmap)
        {
            Bitmap = bitmap;
            Image = ImageProcessingLibConverter.CreateImageFromBitmap(bitmap);
        }

        public ImageWrapper(Image<Pixel32> image)
        {
            Image = image;
            Bitmap = ImageProcessingLibConverter.CreateBitmapFromImage(image);
        }

        public void Dispose()
        {
            Bitmap?.Dispose();
        }
    }
}
