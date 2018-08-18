using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;
using ImageProcessingLib.Wrappers.WF;
using ImageProcessingLibExamples.Examples.Parameters;

namespace ImageProcessingLibExamples.Examples
{
    public class Crop : ExampleBase
    {
        public override void AddExampleImages(Dictionary<string, ImageWrapper> images, Image<Pixel32> originalImage)
        {
            var width = originalImage.Width;
            var height = originalImage.Height;
            var halfWidth = width / 2;
            var halfHeight = height / 2;

            var cropParams = new List<RectangleParameter>()
            {
                new RectangleParameter("Crop_TopLeft", -halfWidth, -halfHeight, width, height),
                new RectangleParameter("Crop_TopRight", halfWidth, -halfHeight, width, height),
                new RectangleParameter("Crop_BottomLeft", -halfWidth, halfHeight, width, height),
                new RectangleParameter("Crop_BottomRight", halfWidth, halfHeight, width, height),
                new RectangleParameter("Crop_Center", halfWidth / 2, halfHeight / 2, halfWidth, halfHeight)
            };

            foreach (var cropParam in cropParams)
            {
                var image = originalImage.Copy();
                image.Crop(cropParam.X, cropParam.Y, cropParam.Width, cropParam.Height);
                images.Add(cropParam.Title, new ImageWrapper(image));
            }
        }
    }
}
