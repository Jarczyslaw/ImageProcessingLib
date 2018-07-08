using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;
using ImageProcessingLib.GDI;

namespace ImageProcessingLibExamples.Examples
{
    public class ColorFiltration : ExampleBase
    {
        public override void AddExampleImages(Dictionary<string, GDImage32> images, Image<Pixel32> originalImage)
        {
            var filters = Enum.GetValues(typeof(ColorFilter)).Cast<ColorFilter>();
            foreach(var filter in filters)
            {
                var image = originalImage.Copy();
                image.ColorFiltration(filter);
                images.Add("ColorFiltration" + filter.ToString(), new GDImage32(image));
            }
        }
    }
}
