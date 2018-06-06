using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;
using ImageProcessingLib.GDI;

namespace ImageProcessingTest.Operations
{
    public class LowPassFiltersOperation : OperationBase
    {
        public override void AddImages(Dictionary<string, GDImage32> images, Image<Pixel32> originalImage)
        {
            IFilter[] filters = new IFilter[] { new LowPassFilter1(), new LowPassFilter2(), new LowPassFilter3(), new LowPassFilter4() };
            foreach(var filter in filters)
            {
                var image = originalImage.Copy();
                image.ApplyFilter(filter);
                images.Add(filter.GetType().Name, new GDImage32(image));
            }
        }
    }
}
