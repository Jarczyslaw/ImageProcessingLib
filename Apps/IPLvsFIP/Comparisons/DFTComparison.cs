﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FIP;
using ImageProcessingLib;

namespace IPLvsFIP.Comparisons
{
    public class DFTComparison : IComparison
    {
        public Bitmap GetFIPResults(FIP.FIP fip, Bitmap originalImage)
        {
            var data = fip.SDFT(originalImage);
            var mag = fip.Magnitude(data);
            return fip.Matrix2ImageLog(mag);
        }

        public Image<Pixel32> GetIPLResult(Image<Pixel32> originalImage)
        {
            return originalImage.SDFT();
        }
    }
}
