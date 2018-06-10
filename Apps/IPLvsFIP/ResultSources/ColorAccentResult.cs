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
    public class ColorAccentResult : IResultSource
    {
        double hue = 270d;
        double range = 50d;

        public Bitmap GetFIPResults(FIP.FIP fip, Bitmap originalImage)
        {
            return fip.ColorAccent(originalImage, hue, range);
        }

        public Image<Pixel32> GetIPLResult(Image<Pixel32> originalImage)
        {
            return originalImage.ColorAccent(hue, range);
        }
    }
}
