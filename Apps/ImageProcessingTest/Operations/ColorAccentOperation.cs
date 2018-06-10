using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;
using ImageProcessingLib.GDI;

namespace ImageProcessingTest.Operations
{
    public class ColorAccentOperation : OperationBase
    {
        public override void AddImages(Dictionary<string, GDImage32> images, Image<Pixel32> originalImage)
        {
            var image = originalImage.Copy();
            images.Add("ColorAccent", new GDImage32(image.ColorAccent(Pixel32.Red, 40d)));
        }
    }
}
