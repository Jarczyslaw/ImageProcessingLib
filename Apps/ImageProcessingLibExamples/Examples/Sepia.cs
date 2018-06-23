﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;
using ImageProcessingLib.GDI;

namespace ImageProcessingLibExamples.Examples
{
    public class Sepia : ExampleBase
    {
        public override void AddImages(Dictionary<string, GDImage32> images, Image<Pixel32> originalImage)
        {
            var levels = new int[] { 10, 20, 30, 40, 80 };
            foreach(var level in levels)
            {
                var image = originalImage.Copy();
                image.Sepia(level);
                images.Add("Sepia" + level, new GDImage32(image));
            }
        }
    }
}