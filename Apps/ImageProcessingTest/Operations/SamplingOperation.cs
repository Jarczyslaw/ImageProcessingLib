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
    public class SamplingOperation : OperationBase
    {
        public override void AddImages(Dictionary<string, GDImage32> images, Image<Pixel32> originalImage)
        {
            var sizes = new int[] { 4, 16, 32 };
            foreach (var size in sizes)
            {
                var image = originalImage.Copy();
                image.Sampling(size);
                images.Add("BlockSize-" + size, new GDImage32(image));
            }
        }
    }
}
