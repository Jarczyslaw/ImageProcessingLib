using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;

namespace ImageProcessingLibExamples.Examples
{
    public class Opening : ExampleBase
    {
        public override void AddExampleImages(Dictionary<string, ImageWrapper> images, Image<Pixel32> originalImage)
        {
            var masks = new int[] { 3, 5, 7, 11 };
            var inputImage = originalImage.CopyAs(p => p.ToPixel1());
            foreach (var mask in masks)
            {
                var image = inputImage.Copy();
                image.Opening(mask);
                images.Add("Opening_Mask" + mask, new ImageWrapper(image.CopyAs(p => p.ToPixel32())));
            }
        }
    }
}
