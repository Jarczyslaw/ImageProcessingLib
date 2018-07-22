﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;
using ImageProcessingLib.Wrappers.WF;
using ImageProcessingLibExamples.Examples.Parameters;

namespace ImageProcessingLibExamples.Examples
{
    public class Complement : ExampleBase
    {
        public override void AddExampleImages(Dictionary<string, ImageWrapper> images, Image<Pixel32> originalImage)
        {
            var originalWidth = originalImage.Width;
            var originalHeight = originalImage.Height;

            var sizes = new List<SizeParameter>()
            {
                new SizeParameter(originalWidth, originalHeight),
                new SizeParameter(originalWidth + 50, originalHeight + 50),
                new SizeParameter(originalWidth + 23, originalHeight + 32)
            };

            var image = originalImage.Copy();
            image.Complement(originalWidth + 32, originalHeight + 32, Pixel32.Red);
            images.Add("RedComplement", new ImageWrapper(image));
            foreach (var size in sizes)
            {
                image = originalImage.Copy();
                image.Complement(size.Width, size.Height);
                images.Add(string.Format("BlankComplement{0}x{1}", size.Width, size.Height), new ImageWrapper(image));
            }
        }
    }
}
