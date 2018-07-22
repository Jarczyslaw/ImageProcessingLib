using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;
using ImageProcessingLib.Wrappers.WF;

namespace ImageProcessingLibExamples.Examples
{
    public class HistogramStretch : ExampleBase
    {
        public override void AddExampleImages(Dictionary<string, ImageWrapper> images, Image<Pixel32> originalImage)
        {
            var ranges = new List<Tuple<byte, byte>>
            {
                new Tuple<byte, byte>(0, 255),
                new Tuple<byte, byte>(64, 255),
                new Tuple<byte, byte>(0, 192)
            };
            foreach (var range in ranges)
            {
                var image = originalImage.Copy();
                image.HistogramStretch(range.Item1, range.Item2);
                images.Add(string.Format("HistogramStretch{0}-{1}", range.Item1, range.Item2), new ImageWrapper(image));
            }
        }
    }
}
