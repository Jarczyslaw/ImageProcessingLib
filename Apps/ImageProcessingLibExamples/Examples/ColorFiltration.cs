using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;
using ImageProcessingLib.Wrappers.WF;

namespace ImageProcessingLibExamples.Examples
{
    public class ColorFiltration : ExampleBase
    {
        public override void AddExampleImages(Dictionary<string, ImageWrapper> images, Image<Pixel32> originalImage)
        {
            var filters = Enum.GetValues(typeof(ColorFilter)).Cast<ColorFilter>();
            foreach(var filter in filters)
            {
                var image = originalImage.Copy();
                image.ColorFiltration(filter);
                images.Add("ColorFiltration_Filter" + filter.ToString(), new ImageWrapper(image));
            }
        }
    }
}
