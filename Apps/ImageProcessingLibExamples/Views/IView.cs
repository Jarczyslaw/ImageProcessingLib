using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLibExamples.Views
{
    public interface IView
    {
        event Action OnViewLoad;
        event Func<bool> OnViewClosing;

        void BringToFront();
        void ShowView();
        void ShowView<T>(T owner);
        void ShowViewAsDialog();
        void ShowViewAsDialog<T>(T owner);
        void CloseView();

        bool Visible { get; }
        bool IsDisposed { get; }
    }
}
