using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;
using ImageProcessingLib.GDI;

namespace ImageProcessingLibExamples.Examples
{
    public class Grayscale : ExampleBase
    {
        public override void AddExampleImages(Dictionary<string, GDImage32> images, Image<Pixel32> originalImage)
        {
            var methods = Enum.GetValues(typeof(GrayscaleMethod)).Cast<GrayscaleMethod>();
            foreach (var method in methods)
            {
                var image = originalImage.Copy();
                image.Grayscale(method);
                images.Add(method.ToString(), new GDImage32(image));
            }
        }
    }
}
