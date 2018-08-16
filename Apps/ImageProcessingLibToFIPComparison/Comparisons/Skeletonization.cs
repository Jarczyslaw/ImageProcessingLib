using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FIP;
using ImageProcessingLib;

namespace ImageProcessingLibToFIPComparison.Comparisons
{
    public class Skeletonization : IComparison
    {
        public Bitmap GetFIPResults(FIP.FIP fip, Bitmap originalImage)
        {
            return fip.Skeletonization(originalImage);
        }

        public Image<Pixel32> GetIPLResult(Image<Pixel32> originalImage)
        {
            var input = originalImage.CopyAs(p => p.ToPixel1());
            input.Skeletonization();
            return input.CopyAs(p => p.ToPixel32());
        }
    }
}
