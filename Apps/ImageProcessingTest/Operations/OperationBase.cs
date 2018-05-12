using ImageProcessingLib;
using ImageProcessingLib.GDI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingTest.Operations
{
    public abstract class OperationBase
    {
        public Dictionary<string, GDImage32> Images { get; private set; } = new Dictionary<string, GDImage32>();
        public GDImage32 OriginalImage { get; private set; }

        public void ApplyOperation(Bitmap bitmap)
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

        public abstract void AddImages(Dictionary<string, GDImage32> images, Image<Pixel32> originalImage);
    }
}
