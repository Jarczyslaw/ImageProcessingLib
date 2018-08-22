using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;
using ImageProcessingLibExamples.Examples.Parameters;

namespace ImageProcessingLibExamples.Examples
{
    public class HistogramStretch : ExampleBase
    {
        public override void AddExampleImages(Dictionary<string, ImageWrapper> images, Image<Pixel32> originalImage)
        {
            var ranges = new List<MinMaxParameter>
            {
                new MinMaxParameter(0, 255),
                new MinMaxParameter(64, 255),
                new MinMaxParameter(0, 192),
            };
            foreach (var range in ranges)
            {
                var image = originalImage.Copy();
                image.HistogramStretch(range.Min, range.Max);
                images.Add(string.Format("HistogramStretch_Min{0}_Max{1}", range.Min, range.Max), new ImageWrapper(image));
            }
        }
    }
}
