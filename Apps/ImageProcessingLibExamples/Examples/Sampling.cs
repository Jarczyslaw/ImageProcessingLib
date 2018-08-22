using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;

namespace ImageProcessingLibExamples.Examples
{
    public class Sampling : ExampleBase
    {
        public override void AddExampleImages(Dictionary<string, ImageWrapper> images, Image<Pixel32> originalImage)
        {
            var sizes = new int[] { 4, 16, 32 };
            foreach (var size in sizes)
            {
                var image = originalImage.Copy();
                image.Sampling(size);
                images.Add("Rotation_Size" + size, new ImageWrapper(image));
            }
        }
    }
}
