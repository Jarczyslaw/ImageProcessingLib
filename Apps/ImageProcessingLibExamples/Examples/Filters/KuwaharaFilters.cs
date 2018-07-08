using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;
using ImageProcessingLib.GDI;

namespace ImageProcessingLibExamples.Examples
{
    public class KuwaharaFiltersExample : ExampleBase
    {
        public override void AddExampleImages(Dictionary<string, GDImage32> images, Image<Pixel32> originalImage)
        {
            var filters = new List<IFilter>() { new KuwaharaFilter3(), new KuwaharaFilter5() };
            foreach (var filter in filters)
            {
                var image = originalImage.Copy();
                image.ApplyFilter(filter);
                images.Add(filter.GetType().Name, new GDImage32(image));
            }
        }
    }
}
