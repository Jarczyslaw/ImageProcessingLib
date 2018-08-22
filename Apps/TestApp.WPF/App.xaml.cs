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

namespace TestApp.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var bitmapSource = ConverterWFWPF.IPLConverter.FromBitmap(Images.Lena);
            var image = ConverterWPF.IPLConverter.CreateImageFromBitmap(bitmapSource);
            var result = ConverterWPF.IPLConverter.CreateBitmapFromImage(image);
            Run(result);
        }

        private void Run(BitmapSource bitmap)
        {
            var testWindow = new TestWindow(bitmap);
            testWindow.Show();
        }
    }
}
