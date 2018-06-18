using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;
using ImageProcessingLib.GDI;
using ImageProcessingLibExamples.Examples.Parameters;

namespace ImageProcessingLibExamples.Examples
{
    public class Insert : ExampleBase
    {
        public override void AddImages(Dictionary<string, GDImage32> images, Image<Pixel32> originalImage)
        {
            var width = originalImage.Width;
            var height = originalImage.Height;
            var quarterWidth = width / 4;
            var quarterHeight = height / 4;

            var insertParams = new List<PointParameter>()
            {
                new PointParameter("InsertTopLeft", -quarterWidth, -quarterHeight),
                new PointParameter("InsertTopRight", width - quarterWidth, -quarterHeight),
                new PointParameter("InsertBottomLeft", -quarterWidth, height - quarterHeight),
                new PointParameter("InsertBottomRight", width - quarterWidth, height - quarterHeight),
                new PointParameter("InsertCenter", quarterWidth, quarterHeight)
            };

            var imageToInsert = originalImage.Copy().Resize(originalImage.Width / 2, originalImage.Height / 2);
            foreach (var param in insertParams)
            {
                var image = originalImage.Copy();
                images.Add(param.Title, new GDImage32(image.Insert(imageToInsert, param.X, param.Y)));
            }
        }
    }
}
