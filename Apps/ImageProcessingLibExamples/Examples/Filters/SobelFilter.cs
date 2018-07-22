using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;
using ImageProcessingLib.Wrappers.WF;

namespace ImageProcessingLibExamples.Examples
{
    public class SobelFilter : ExampleBase
    {
        public override void AddExampleImages(Dictionary<string, ImageWrapper> images, Image<Pixel32> originalImage)
        {
            var image = originalImage.Copy();
            image.ApplyFilter(new ImageProcessingLib.SobelFilter());
            images.Add("SobelFilterAccurate", new ImageWrapper(image));
            image = originalImage.Copy();
            image.ApplyFilter(new ImageProcessingLib.SobelFilter(true));
            images.Add("SobelFilterApproximation", new ImageWrapper(image));
        }
    }
}
