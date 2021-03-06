﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;

namespace ImageProcessingLibExamples.Examples
{
    public class HistogramScaling : ExampleBase
    {
        public override void AddExampleImages(Dictionary<string, ImageWrapper> images, Image<Pixel32> originalImage)
        {
            var image = originalImage.Copy();
            image.HistogramScaling();
            images.Add("HistogramScaling_LinearScale", new ImageWrapper(image));
            image = originalImage.Copy();
            image.HistogramScalingLog10();
            images.Add("HistogramScaling_Log10", new ImageWrapper(image));
        }
    }
}
