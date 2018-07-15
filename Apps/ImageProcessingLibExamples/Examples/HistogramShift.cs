using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;
using ImageProcessingLib.GDI;

namespace ImageProcessingLibExamples.Examples
{
    public class HistogramShift : ExampleBase
    {
        public override void AddExampleImages(Dictionary<string, GDImage32> images, Image<Pixel32> originalImage)
        {
            var offsets = new int[] { 20, 40, 80 };
            foreach (var offset in offsets)
            {
                var image = originalImage.Copy();
                image.HistogramShift(offset);
                images.Add(string.Format("HistogramShift{0}", offset), new GDImage32(image));
            }
        }
    }
}
