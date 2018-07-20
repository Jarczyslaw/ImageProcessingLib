using ImageProcessingLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLibExamples.Views
{
    public interface IHistogramView : IView
    {
        string ImageTitle { set; }
        RGBHistogram Histogram { set; }
    }
}
