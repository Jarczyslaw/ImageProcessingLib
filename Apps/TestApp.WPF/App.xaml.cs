using ImageProcessingLib;
using ImageProcessingLib.Wrappers.WPF;
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
            var img = new Image<Pixel32>(500, 500, Pixel32.Red);
            var wrapper = new ImageWrapper(img);
            Run(wrapper.BitmapSource);
        }

        private void Run(BitmapSource bitmapSource)
        {
            var testWindow = new TestWindow(bitmapSource);
            testWindow.Show();
        }
    }
}
