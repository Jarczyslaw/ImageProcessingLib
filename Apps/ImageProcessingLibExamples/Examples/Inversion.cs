using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;
using ImageProcessingLib.Wrappers.WF;

namespace ImageProcessingLibExamples.Examples
{
    public class Inversion : ExampleBase
    {
        public override void AddExampleImages(Dictionary<string, ImageWrapper> images, Image<Pixel32> originalImage)
        {
            var conversionPoints = new byte[] { 64, 128, 196 };
            foreach(var conversionPoint in conversionPoints)
            {
                var image = originalImage.Copy();
                image.Inversion(conversionPoint);
                images.Add("Inversion" + conversionPoint, new ImageWrapper(image));
            }
        }
    }
}
