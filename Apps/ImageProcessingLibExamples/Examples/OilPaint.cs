using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;
using ImageProcessingLibExamples.Examples.Parameters;

namespace ImageProcessingLibExamples.Examples
{
    public class OilPaint : ExampleBase
    {
        public override void AddExampleImages(Dictionary<string, ImageWrapper> images, Image<Pixel32> originalImage)
        {
            var parameters = new List<OilPaintParameter>
            {
                new OilPaintParameter(3, 10),
                new OilPaintParameter(5, 10),
                new OilPaintParameter(3, 15),
                new OilPaintParameter(5, 15)
            };
            foreach (var parameter in parameters)
            {
                var image = originalImage.Copy();
                image.OilPaint(parameter.Size, parameter.Levels);
                images.Add(string.Format("OilPaint_Size{0}_Levels{1}", parameter.Size, parameter.Levels), new ImageWrapper(image));
            }
        }
    }
}
