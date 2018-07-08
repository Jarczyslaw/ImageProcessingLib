using ImageProcessingLib;
using ImageProcessingLib.GDI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLibExamples.Examples
{
    public abstract class ExampleBase
    {
        public Dictionary<string, GDImage32> Images { get; private set; } = new Dictionary<string, GDImage32>();
        public GDImage32 OriginalImage { get; private set; }

        public void ApplyExample(Bitmap bitmap)
        {
            Images = new Dictionary<string, GDImage32>();
            OriginalImage = new GDImage32(bitmap);
            Images.Add("Original", OriginalImage);
            AddImages(Images, OriginalImage.Image);
        }

        public void CleanUp()
        {
            foreach (var gdimage in Images.Values)
                gdimage.Dispose();
        }

        public void Save(string selectedPath)
        {
            foreach (var exampleResult in Images)
            {
                var fileName = exampleResult.Key;
                var image = exampleResult.Value;
                var filePath = Path.Combine(selectedPath, fileName + ".bmp");
                image.ToFile(filePath, ImageFormat.Bmp);
            }
        }

        public abstract void AddImages(Dictionary<string, GDImage32> images, Image<Pixel32> originalImage);
    }
}
