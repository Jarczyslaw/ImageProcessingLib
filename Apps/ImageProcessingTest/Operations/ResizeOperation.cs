using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;
using ImageProcessingLib.ImageProcessing;
using ImageProcessingLib.GDI;

namespace ImageProcessingTest.Operations
{
    public class ResizeOperation : OperationBase
    {
        public override void AddImages(Dictionary<string, GDImage32> images, Image<Pixel32> originalImage)
        {
            var size = 1024;
            var image = originalImage.Copy();
            image.Resize(size, size);
            images.Add("NearestNeighbour", new GDImage32(image));
            image = originalImage.Copy();
            image.Resize(size, size, ResizeMethod.BilinearInterpolation);
            images.Add("BilinearInterpolation", new GDImage32(image));
        }
    }
}
