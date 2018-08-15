using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;
using ImageProcessingLib.Wrappers.WF;

namespace ImageProcessingLibExamples.Examples
{
    public class Morphology : ExampleBase
    {
        public override void AddExampleImages(Dictionary<string, ImageWrapper> images, Image<Pixel32> originalImage)
        {
            var maskSize = 3;
            var inputImage = originalImage.CopyAs(p => p.ToPixel1());
            var image = inputImage.Copy();
            image.Erosion(maskSize);
            images.Add("Erosion", new ImageWrapper(image.CopyAs(p => p.ToPixel32())));
            image = inputImage.Copy();
            image.Dilation(maskSize);
            images.Add("Dilation", new ImageWrapper(image.CopyAs(p => p.ToPixel32())));
            image = inputImage.Copy();
            image.Opening(maskSize);
            images.Add("Opening", new ImageWrapper(image.CopyAs(p => p.ToPixel32())));
            image = inputImage.Copy();
            image.Closing(maskSize);
            images.Add("Closing", new ImageWrapper(image.CopyAs(p => p.ToPixel32())));
            image = inputImage.Copy();
            image.Skeletonization();
            images.Add("Skeletonization", new ImageWrapper(image.CopyAs(p => p.ToPixel32())));
        }
    }
}
