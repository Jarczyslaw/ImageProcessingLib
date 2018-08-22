using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;

namespace ImageProcessingLibExamples.Examples
{
    public class KuwaharaFilters : ExampleBase
    {
        public override void AddExampleImages(Dictionary<string, ImageWrapper> images, Image<Pixel32> originalImage)
        {
            var filters = new List<IFilter>() { new KuwaharaFilter3(), new KuwaharaFilter5() };
            foreach (var filter in filters)
            {
                var image = originalImage.Copy();
                image.ApplyFilter(filter);
                images.Add(filter.GetType().Name, new ImageWrapper(image));
            }
        }
    }
}
