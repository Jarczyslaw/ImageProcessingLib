﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FIP;
using ImageProcessingLib;

namespace ImageProcessingLibToFIPComparison.Comparisons
{
    public class Erosion : IComparison
    {
        private int maskSize = 3;

        public Bitmap GetFIPResults(FIP.FIP fip, Bitmap originalImage)
        {
            return fip.ImageErosionFilterGS(originalImage, maskSize);
        }

        public Image<Pixel32> GetIPLResult(Image<Pixel32> originalImage)
        {
            var inputImage = originalImage.CopyAs(p => p.ToPixel1());
            inputImage.Erosion(maskSize);
            return inputImage.CopyAs(p => p.ToPixel32());
        }
    }
}
