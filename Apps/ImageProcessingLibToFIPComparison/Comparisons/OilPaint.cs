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
    public class OilPaint : IComparison
    {
        private int range = 3;
        private int levels = 5;

        public Bitmap GetFIPResults(FIP.FIP fip, Bitmap originalImage)
        {
            return fip.OilPaint(originalImage, range, levels);
        }

        public Image<Pixel32> GetIPLResult(Image<Pixel32> originalImage)
        {
            return originalImage.OilPaint(range, levels);
        }
    }
}
