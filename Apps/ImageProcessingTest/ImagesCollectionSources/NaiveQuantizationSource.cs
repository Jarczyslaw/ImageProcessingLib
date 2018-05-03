using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;
using ImageProcessingLib.ImageProcessing;

namespace ImageProcessingTest
{
    public class NaiveQuantizationSource : SourceBase
    {
        public override void AddImages(ImagesCollection collection, Image<Pixel32> originalImage)
        {
            var levels = new int[] { 256, 64, 16, 8, 4, 2 };
            foreach (var level in levels)
            {
                var image = originalImage.Copy();
                image.NaiveQuantize(level);
                collection.Add("NaiveQuantization" + level, image);
            }
        }
    }
}
