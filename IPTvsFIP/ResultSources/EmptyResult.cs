using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;

namespace IPTvsFIP.ResultSources
{
    public class EmptyResult : IResultSource
    {
        public Bitmap GetFIPResults(Bitmap originalImage)
        {
            return originalImage;
        }

        public Image<Pixel32> GetIPTResult(Image<Pixel32> originalImage)
        {
            return originalImage;
        }
    }
}
