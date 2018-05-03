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
        public Dictionary<Bitmap, Dictionary<string, GDImage32>> Images { get; private set; } = new Dictionary<Bitmap, Dictionary<string, GDImage32>>();

        public Dictionary<string, GDImage32> ApplyOperation(Bitmap bitmap, out bool needsInitialization)
        {
            if (Images.TryGetValue(bitmap, out Dictionary<string, GDImage32> value))
            {
                needsInitialization = false;
                return value;
            } 

            var originalImage = new GDImage32(bitmap);
            var images = new Dictionary<string, GDImage32>();
            images.Add("Original", originalImage);
            AddImages(images, originalImage.Image);
            Images.Add(bitmap, images);
            needsInitialization = true;
            return images;
        }

        public void Dispose()
        {
            foreach (var val in Images.Values)
                foreach (var gdimage in val.Values)
                    gdimage.Dispose();

            foreach (var val in Images.Keys)
                val.Dispose();
        }

        public abstract void AddImages(Dictionary<string, GDImage32> images, Image<Pixel32> originalImage);
    }
}
