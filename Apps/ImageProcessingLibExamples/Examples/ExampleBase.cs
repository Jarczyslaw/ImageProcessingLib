using ImageProcessingLib;
using ImageProcessingLib.Wrappers.WF;
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
        public Dictionary<string, ImageWrapper> Images { get; private set; } = new Dictionary<string, ImageWrapper>();
        public ImageWrapper OriginalImage { get; private set; }

        public void ApplyExample(Bitmap bitmap)
        {
            Images = new Dictionary<string, ImageWrapper>();
            OriginalImage = new ImageWrapper(bitmap);
            Images.Add("Original", OriginalImage);
            AddExampleImages(Images, OriginalImage.Image32);
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

        public abstract void AddExampleImages(Dictionary<string, ImageWrapper> images, Image<Pixel32> originalImage);
    }
}
