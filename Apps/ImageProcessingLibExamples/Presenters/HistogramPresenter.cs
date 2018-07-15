using ImageProcessingLib;
using ImageProcessingLibExamples.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLibExamples.Presenters
{
    public class HistogramPresenter
    {
        private IMainView mainView;

        public HistogramPresenter(IMainView mainView)
        {
            this.mainView = mainView;
        }

        public void ShowHistogram(IHistogramView histogramView, Image<Pixel32> image, string imageTitle)
        {
            var histogram = image.Histogram();

            histogramView.ImageTitle = imageTitle;
            histogramView.Histogram = histogram;
            histogramView.ShowView(mainView);
        }
    }
}
