using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FIP;
using ImageProcessingLib;

namespace IPLvsFIP.ResultSources
{
    public class LowPassFilterResult : IResultSource
    {
        public Bitmap GetFIPResults(FIP.FIP fip, Bitmap originalImage)
        {
            return fip.ImageFilterColor(originalImage, fip.LPF4Kernel(), fip.LPF4Coeff);
        }

        public Image<Pixel32> GetIPLResult(Image<Pixel32> originalImage)
        {
            return originalImage.ApplyFilter(new LowPassFilter4());
        }
    }
}
