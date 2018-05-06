﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;
using ImageProcessingLib.ImageProcessing;
using ImageProcessingLib.GDI;

namespace ImageProcessingTest.Operations
{
    public class GammaCorrectionOperation : OperationBase
    {
        public override void AddImages(Dictionary<string, GDImage32> images, Image<Pixel32> originalImage)
        {
            var gammas = new double[] { 0.25d, 0.5d, 0.75d, 1.5d, 2d };
            foreach(var gamma in gammas)
            {
                var image = originalImage.Copy();
                image.GammaCorrection(gamma);
                images.Add("Gamma-" + gamma, new GDImage32(image));
            }
        }
    }
}
