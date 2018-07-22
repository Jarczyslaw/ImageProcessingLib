using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;
using ImageProcessingLib.Wrappers.WF;

namespace ImageProcessingLibExamples.Examples
{
    public class Flip : ExampleBase
    {
        public override void AddExampleImages(Dictionary<string, ImageWrapper> images, Image<Pixel32> originalImage)
        {
            var image = originalImage.Copy();
            image.FlipVertical();
            images.Add("FlipVertical", new ImageWrapper(image));
            image = originalImage.Copy();
            image.FlipHorizontal();
            images.Add("FlipHorizontal", new ImageWrapper(image));
            image = originalImage.Copy();
            image.FlipHorizontal().FlipVertical();
            images.Add("FlipHorizontalVertical", new ImageWrapper(image));
        }
    }
}
