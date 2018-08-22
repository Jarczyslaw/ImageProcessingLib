using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;

namespace ImageProcessingLibExamples.Examples
{
    public class LowPassFilters : ExampleBase
    {
        public override void AddExampleImages(Dictionary<string, ImageWrapper> images, Image<Pixel32> originalImage)
        {
            IFilter[] filters = new IFilter[] { new LowPassFilter1(), new LowPassFilter2(), new LowPassFilter3(), new LowPassFilter4() };
            foreach(var filter in filters)
            {
                var image = originalImage.Copy();
                image.ApplyFilter(filter);
                images.Add(filter.GetType().Name, new ImageWrapper(image));
            }
        }
    }
}
