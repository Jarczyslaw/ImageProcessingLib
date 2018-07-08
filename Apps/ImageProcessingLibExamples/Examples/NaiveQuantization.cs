using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;
using ImageProcessingLib.GDI;

namespace ImageProcessingLibExamples.Examples
{
    public class NaiveQuantization : ExampleBase
    {
        public override void AddExampleImages(Dictionary<string, GDImage32> images, Image<Pixel32> originalImage)
        {
            var levels = new int[] { 256, 64, 16, 8, 4, 2 };
            foreach (var level in levels)
            {
                var image = originalImage.Copy();
                image.NaiveQuantize(level);
                images.Add("NaiveQuantization" + level, new GDImage32(image));
            }
        }
    }
}
