using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;

namespace ImageProcessingLibExamples.Examples
{
    public class HistogramShift : ExampleBase
    {
        public override void AddExampleImages(Dictionary<string, ImageWrapper> images, Image<Pixel32> originalImage)
        {
            var offsets = new int[] { 20, 40, 80 };
            foreach (var offset in offsets)
            {
                var image = originalImage.Copy();
                image.HistogramShift(offset);
                images.Add(string.Format("HistogramShift_Offset{0}", offset), new ImageWrapper(image));
            }
        }
    }
}
