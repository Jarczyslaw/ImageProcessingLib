using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;
using ImageProcessingLib.ImageProcessing;

namespace ImageProcessingTest
{
    public class ResizeSource : SourceBase
    {
        public override void AddImages(ImagesCollection collection, Image<Pixel32> originalImage)
        {
            var size = 1024;
            var image = originalImage.Copy();
            image.Resize(size, size);
            collection.Add("NearestNeighbour", image);
            image = originalImage.Copy();
            image.Resize(size, size, ResizeMethod.BilinearInterpolation);
            collection.Add("BilinearInterpolation", image);
        }
    }
}
