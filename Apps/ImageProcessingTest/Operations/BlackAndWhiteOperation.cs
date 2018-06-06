using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;
using ImageProcessingLib.GDI;

namespace ImageProcessingTest.Operations
{
    public class BlackAndWhiteOperation : OperationBase
    {
        public override void AddImages(Dictionary<string, GDImage32> images, Image<Pixel32> originalImage)
        {
            var thresholds = new byte[] { 32, 64, 128, 192 };
            foreach(var threshold in thresholds)
            {
                var image = originalImage.Copy();
                image.BlackAndWhite(threshold);
                images.Add("Threshold" + threshold, new GDImage32(image));
            }
        }
    }
}
