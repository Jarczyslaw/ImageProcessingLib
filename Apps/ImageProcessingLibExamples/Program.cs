using ImageProcessingLibExamples.Presenters;
using ImageProcessingLibExamples.Views;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessingLibExamples
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ChangeCultureSettings();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IImagesSource imagesSource = new ImagesSource();
            IExamplesSource examplesSource = new ExamplesSource();
            IMainView mainView = new MainView();
            var mainPresenter = new MainPresenter(mainView, imagesSource, examplesSource);
            Application.Run(mainView as Form);
        }

        private static void ChangeCultureSettings()
        {
            var customCulture = (CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            Thread.CurrentThread.CurrentCulture = customCulture;
        }
    }
}
