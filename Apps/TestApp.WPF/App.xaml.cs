using ImageProcessingLib;
using ConverterWFWPF = ImageProcessingLib.Converter.WF.WPF;
using ConverterWPF = ImageProcessingLib.Converter.WPF;
using ImagesFolder;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using TestApp.WPF.Services;

namespace TestApp.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var bitmapSource = ConverterWFWPF.ImageProcessingLibConverter.FromBitmap(Images.Lena);
            var image = ConverterWPF.ImageProcessingLibConverter.CreateImageFromBitmap(bitmapSource);
            var result = ConverterWPF.ImageProcessingLibConverter.CreateBitmapFromImage(image);
            Run(result);
        }

        private void Run(BitmapSource bitmap)
        {
            IDialogService dialogService = new DialogService();
            var viewModel = new TestViewModel(bitmap, dialogService);
            var window = new TestWindow(viewModel);
            window.Show();
        }
    }
}
