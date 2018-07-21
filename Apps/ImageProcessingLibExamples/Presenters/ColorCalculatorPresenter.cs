using ImageProcessingLib;
using ImageProcessingLib.Utilities;
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

        public ColorCalculatorPresenter(IMainView mainView)
        {
            this.mainView = mainView;
        }

        public void ShowView(IColorCalculatorView view, bool showRandomPixel = false)
        {
            this.view = view;
            if (showRandomPixel)
            {
                var random = new RandomEx();
                view.SetPixel(random.NextPixel32());
            }    
        }

        public void UpdateColor(int x, int y, Pixel32 pixel)
        {
            if (view == null)
                return;

            view.SetCoordinates(x, y);
            view.SetPixel(pixel);
        }
    }
}
