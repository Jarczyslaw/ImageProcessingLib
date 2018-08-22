using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;

namespace ImageProcessingLibExamples.Examples
{
    public class ColorAccent : ExampleBase
    {
        public override void AddExampleImages(Dictionary<string, ImageWrapper> images, Image<Pixel32> originalImage)
        {
            var hue = 40d;
            var image = originalImage.Copy();
            images.Add(string.Format("ColorAccent_Hue{0}", hue), new ImageWrapper(image.ColorAccent(Pixel32.Red, hue)));
        }
    }
}
