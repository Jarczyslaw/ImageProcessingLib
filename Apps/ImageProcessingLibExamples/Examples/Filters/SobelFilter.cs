using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;
using ImageProcessingLib.GDI;

namespace ImageProcessingLibExamples.Examples
{
    public class SobelFilter : ExampleBase
    {
        public override void AddImages(Dictionary<string, GDImage32> images, Image<Pixel32> originalImage)
        {
            var image = originalImage.Copy();
            image.ApplyFilter(new ImageProcessingLib.SobelFilter());
            images.Add("SobelFilterAccurate", new GDImage32(image));
            image = originalImage.Copy();
            image.ApplyFilter(new ImageProcessingLib.SobelFilter(true));
            images.Add("SobelFilterApproximation", new GDImage32(image));
        }
    }
}
