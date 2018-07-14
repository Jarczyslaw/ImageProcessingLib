using ImageProcessingLib;
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
        private IMainView mainView;

        public ColorCalculatorPresenter(IMainView mainView, IColorCalculatorView view)
        {
            this.view = view;
            this.mainView = mainView;
        }

        public void ShowView()
        {
            if (!view.Visible)
                view.ShowView(mainView);
            else
                view.BringToFront();
        }

        public void UpdateColor(int x, int y, Pixel32 pixel)
        {
            view.SetCoordinates(x, y);
            view.SetPixel(pixel);
        }
    }
}
