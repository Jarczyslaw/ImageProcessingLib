using ImageProcessingLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLibExamples.Views
{
    public interface IColorCalculatorView : IView
    {
        void SetCoordinates(int? x, int? y);
        void LoadPixel(Pixel32 pixel);
    }
}
