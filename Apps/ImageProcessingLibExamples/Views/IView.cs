using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLibExamples.Views
{
    public interface IView
    {
        void ShowView();
        void ShowViewAsDialog();
        void CloseView();
    }
}
