﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;
using ImageProcessingLib.GDI;

namespace ImageProcessingTest.Operations
{
    public class DFTOperation : OperationBase
    {
        public override void AddImages(Dictionary<string, GDImage32> images, Image<Pixel32> originalImage)
        {
            images.Add("DFT", new GDImage32(originalImage.DFT()));
            images.Add("SDFT", new GDImage32(originalImage.SDFT()));
        }
    }
}
