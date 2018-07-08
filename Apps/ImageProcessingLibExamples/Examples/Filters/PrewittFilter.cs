using ImageProcessingLib;
using ImageProcessingLib.GDI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLibExamples.Examples
{
    public class PrewittFilter : ExampleBase
    {
        public override void AddExampleImages(Dictionary<string, GDImage32> images, Image<Pixel32> originalImage)
        {
            var image = originalImage.Copy();
            image.ApplyFilter(new ImageProcessingLib.PrewittFilter());
            images.Add("PrewittFilterAccurate", new GDImage32(image));
            image = originalImage.Copy();
            image.ApplyFilter(new ImageProcessingLib.PrewittFilter(true));
            images.Add("PrewittFilterApproximation", new GDImage32(image));
        }
    }
}
