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
    class HistogramEqualization : IComparison
    {
        public Bitmap GetFIPResults(FIP.FIP fip, Bitmap originalImage)
        {
            return fip.HistoramEqualization(originalImage);
        }

        public Image<Pixel32> GetIPLResult(Image<Pixel32> originalImage)
        {
            originalImage.Grayscale();
            return originalImage.HistogramEqualization();
        }
    }
}
