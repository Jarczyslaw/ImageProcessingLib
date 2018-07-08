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
        private IHistogramView view;
        private Image<Pixel32> image;

        public HistogramPresenter(IHistogramView view, Image<Pixel32> image)
        {
            this.view = view;
            this.image = image;

            view.OnLoad += OnLoad;
            view.ShowViewAsDialog();
        }

        private void OnLoad()
        {
            var hist = image.Histogram();
            view.Histogram = hist;
        }
    }
}
