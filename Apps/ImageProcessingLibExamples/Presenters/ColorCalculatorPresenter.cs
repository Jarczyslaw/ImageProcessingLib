using ImageProcessingLibExamples.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLibExamples.Presenters
{
    public class ColorCalculatorPresenter
    {
        private IColorCalculatorView view;

        public ColorCalculatorPresenter(IMainView mainView, IColorCalculatorView view)
        {
            this.view = view;
            view.ShowView(mainView);
        }
    }
}
