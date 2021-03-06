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
    public class KuwaharaFilter : IComparison
    {
        public Bitmap GetFIPResults(FIP.FIP fip, Bitmap originalImage)
        {
            return fip.ImageKuwaharaFilterColor(originalImage, 3);
        }

        public Image<Pixel32> GetIPLResult(Image<Pixel32> originalImage)
        {
            return originalImage.ApplyFilter(new KuwaharaFilter5());
        }
    }
}
