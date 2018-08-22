using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;

namespace ImageProcessingLibExamples.Examples
{
    public class BlackAndWhite : ExampleBase
    {
        public override void AddExampleImages(Dictionary<string, ImageWrapper> images, Image<Pixel32> originalImage)
        {
            var thresholds = new List<byte>();
            for (int i = 32; i < byte.MaxValue; i += 32)
                thresholds.Add((byte)i);

            foreach(var threshold in thresholds)
            {
                var image = originalImage.Copy();
                image.BlackAndWhite(threshold);
                images.Add("BlackAndWhite_Threshold" + threshold, new ImageWrapper(image));
            }
        }
    }
}
