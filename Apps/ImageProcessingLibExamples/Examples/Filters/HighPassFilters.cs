﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;
using ImageProcessingLib.GDI;
using System.IO;

namespace ImageProcessingLibExamples.Examples
{
    public class HighPassFiltersExample : ExampleBase
    {
        public override void AddExampleImages(Dictionary<string, GDImage32> images, Image<Pixel32> originalImage)
        {
            IFilter[] filters = new IFilter[] { new HighPassFilter1(), new HighPassFilter2(), new HighPassFilter3(), new HighPassFilter4() };
            foreach (var filter in filters)
            {
                var image = originalImage.Copy();
                image.ApplyFilter(filter);
                images.Add(filter.GetType().Name, new GDImage32(image));
            }
        }
    }
}
