using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;
using ImageProcessingLib.Wrappers.WF;

namespace ImageProcessingLibExamples.Examples
{
    public class BlackAndWhite : ExampleBase
    {
        public override void AddExampleImages(Dictionary<string, ImageWrapper> images, Image<Pixel32> originalImage)
        {
            var thresholds = new byte[] { 32, 64, 128, 192 };
            foreach(var threshold in thresholds)
            {
                var image = originalImage.Copy();
                image.BlackAndWhite(threshold);
                images.Add("BlackAndWhite_Threshold" + threshold, new ImageWrapper(image));
            }
        }
    }
}
