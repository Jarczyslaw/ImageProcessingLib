using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;
using ImageProcessingLib.Wrappers.WF;

namespace ImageProcessingLibExamples.Examples
{
    public class Skeletonization : ExampleBase
    {
        public override void AddExampleImages(Dictionary<string, ImageWrapper> images, Image<Pixel32> originalImage)
        {
            var image = originalImage.CopyAs(p => p.ToPixel1());
            image.Skeletonization();
            images.Add("Skeletonization", new ImageWrapper(image.CopyAs(p => p.ToPixel32())));
        }
    }
}
