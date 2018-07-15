using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;
using ImageProcessingLib.GDI;

namespace ImageProcessingLibExamples.Examples
{
    public class ContrastStretch : ExampleBase
    {
        public override void AddExampleImages(Dictionary<string, GDImage32> images, Image<Pixel32> originalImage)
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
                image.ContrastStretch(range.Item1, range.Item2);
                images.Add(string.Format("ContrastStretch{0}-{1}", range.Item1, range.Item2), new GDImage32(image));
            }
        }
    }
}
