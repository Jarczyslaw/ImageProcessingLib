﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;

namespace ImageProcessingLibToFIPComparison.Comparisons
{
    public class LaplaceFilter : IComparison
    {
        public Bitmap GetFIPResults(FIP.FIP fip, Bitmap originalImage)
        {
            return fip.ImageFilterColor(originalImage, fip.LaplaceF4());
        }

        public Image<Pixel32> GetIPLResult(Image<Pixel32> originalImage)
        {
            return originalImage.ApplyFilter(new LaplaceFilter4());
        }
    }
}
