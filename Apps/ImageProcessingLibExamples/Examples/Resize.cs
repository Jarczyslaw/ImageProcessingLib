﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;

namespace ImageProcessingLibExamples.Examples
{
    public class Resize : ExampleBase
    {
        public override void AddExampleImages(Dictionary<string, ImageWrapper> images, Image<Pixel32> originalImage)
        {
            var size = 1024;
            var image = originalImage.Copy();
            image.Resize(size, size);
            images.Add("Resize_NearestNeighbour", new ImageWrapper(image));
            image = originalImage.Copy();
            image.Resize(size, size, ResizeMethod.BilinearInterpolation);
            images.Add("Resize_BilinearInterpolation", new ImageWrapper(image));
        }
    }
}
