using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;
using ImageProcessingLib.GDI;

namespace ImageProcessingLibExamples.Examples
{
    public class Flip : ExampleBase
    {
        public override void AddImages(Dictionary<string, GDImage32> images, Image<Pixel32> originalImage)
        {
            var image = originalImage.Copy();
            image.FlipVertical();
            images.Add("FlipVertical", new GDImage32(image));
            image = originalImage.Copy();
            image.FlipHorizontal();
            images.Add("FlipHorizontal", new GDImage32(image));
            image = originalImage.Copy();
            image.FlipHorizontal().FlipVertical();
            images.Add("FlipHorizontalVertical", new GDImage32(image));
        }
    }
}
