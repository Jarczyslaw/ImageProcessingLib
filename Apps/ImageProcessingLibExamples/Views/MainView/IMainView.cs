using ImageProcessingLib.GDI;
using ImageProcessingLibExamples.Examples;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLibExamples.Views
{
    public interface IMainView : IView
    {
        event Action OnExampleRun;

        event Action<string> OnCurrentImageSave;
        event Action<string> OnImagesSave;
        event Action OnMetricsShow;
        event Action<IHistogramView> OnHistogramShow;
        event Action<IColorCalculatorView> OnColorCalculatorShow;

        Bitmap SelectedSourceImage { get; }
        ExampleBase SelectedExample { get; }
        GDImage32 SelectedResultImage { get; set; }

        bool IsBusy { get; set; }

        void SetSummary(string exampleName, double elapsedMilliseconds);
        void ShowMetrics(double mse, double psnr);
        void AllImagesSaveInfo(int count, string path);
        void CurrentImageSaveInfo(string path);

        void SetImages(Dictionary<string, Bitmap> images);
        void SetExamples(Dictionary<string, ExampleBase> examples);
        void SetResultImages(Dictionary<string, GDImage32> resultImages);

        void ShowInfo(string info);
        void ShowException(Exception exception);
    }
}
