﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;
using ImageProcessingLibExamples.Examples.Parameters;

namespace ImageProcessingLibExamples.Examples
{
    public class Insert : ExampleBase
    {
        public override void AddExampleImages(Dictionary<string, ImageWrapper> images, Image<Pixel32> originalImage)
        {
            var width = originalImage.Width;
            var height = originalImage.Height;
            var quarterWidth = width / 4;
            var quarterHeight = height / 4;

            var insertParams = new List<PointParameter>()
            {
                new PointParameter("Insert_TopLeft", -quarterWidth, -quarterHeight),
                new PointParameter("Insert_TopRight", width - quarterWidth, -quarterHeight),
                new PointParameter("Insert_BottomLeft", -quarterWidth, height - quarterHeight),
                new PointParameter("Insert_BottomRight", width - quarterWidth, height - quarterHeight),
                new PointParameter("Insert_Center", quarterWidth, quarterHeight)
            };

            var imageToInsert = originalImage.Copy().Resize(originalImage.Width / 2, originalImage.Height / 2);
            foreach (var param in insertParams)
            {
                var image = originalImage.Copy();
                images.Add(param.Title, new ImageWrapper(image.Insert(imageToInsert, param.X, param.Y)));
            }
        }
    }
}
