using ImageProcessingLib;
using ImageProcessingLib.Wrappers.WF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLibExamples.Examples
{
    public class PrewittFilter : ExampleBase
    {
        public override void AddExampleImages(Dictionary<string, ImageWrapper> images, Image<Pixel32> originalImage)
        {
            var image = originalImage.Copy();
            image.ApplyFilter(new ImageProcessingLib.PrewittFilter());
            images.Add("PrewittFilter_Accurate", new ImageWrapper(image));
            image = originalImage.Copy();
            image.ApplyFilter(new ImageProcessingLib.PrewittFilter(true));
            images.Add("PrewittFilter_Approximation", new ImageWrapper(image));
        }
    }
}
