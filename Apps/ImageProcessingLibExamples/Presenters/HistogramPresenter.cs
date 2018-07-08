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

        public HistogramPresenter(IHistogramView view, Image<Pixel32> image)
        {
            this.view = view;
            view.ShowViewAsDialog();
        }
    }
}
