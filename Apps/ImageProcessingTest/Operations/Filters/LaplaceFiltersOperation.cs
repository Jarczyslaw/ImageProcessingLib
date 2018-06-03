using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;
using ImageProcessingLib.GDI;
using ImageProcessingLib.ImageProcessing;

namespace ImageProcessingTest.Operations
{
    public class LaplaceFiltersOperation : OperationBase
    {
        public override void AddImages(Dictionary<string, GDImage32> images, Image<Pixel32> originalImage)
        {
            var filters = new List<IFilter>() { new LaplaceFilter1(), new LaplaceFilter2(), new LaplaceFilter3(), new LaplaceFilter4() };
            foreach (var filter in filters)
            {
                var image = originalImage.Copy();
                image.ApplyFilter(filter);
                images.Add(filter.GetType().Name, new GDImage32(image));
            }
        }
    }
}
