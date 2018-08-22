using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;

namespace ImageProcessingLibExamples.Examples
{
    public class SobelFilter : ExampleBase
    {
        public override void AddExampleImages(Dictionary<string, ImageWrapper> images, Image<Pixel32> originalImage)
        {
            var image = originalImage.Copy();
            image.ApplyFilter(new ImageProcessingLib.SobelFilter());
            images.Add("SobelFilter_Accurate", new ImageWrapper(image));
            image = originalImage.Copy();
            image.ApplyFilter(new ImageProcessingLib.SobelFilter(true));
            images.Add("SobelFilter_Approximation", new ImageWrapper(image));
        }
    }
}
