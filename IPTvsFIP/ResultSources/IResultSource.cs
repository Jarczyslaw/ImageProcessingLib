using ImageProcessingLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPTvsFIP.ResultSources
{
    public interface IResultSource
    {
        Bitmap GetFIPResults(Bitmap originalImage);
        Image<Pixel32> GetIPTResult(Image<Pixel32> originalImage);
    }
}
