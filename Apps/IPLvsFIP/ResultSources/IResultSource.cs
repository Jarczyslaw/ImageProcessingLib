using ImageProcessingLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPLvsFIP.ResultSources
{
    public interface IResultSource
    {
        Bitmap GetFIPResults(FIP.FIP fip, Bitmap originalImage);
        Image<Pixel32> GetIPLResult(Image<Pixel32> originalImage);
    }
}
