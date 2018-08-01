using ImageProcessingLib;
using ImageProcessingLib.Converters.WF.WPF;
using ImageProcessingLib.Wrappers.WPF;
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
            var bitmapSource = ImageConverter.FromBitmap(Images.Lena);
            var wrapper = new ImageWrapper(bitmapSource);
            var targetWrapper = new ImageWrapper(wrapper.Image32);
            Run(targetWrapper);
        }

        private void Run(ImageWrapper imageWrapper)
        {
            var testWindow = new TestWindow(imageWrapper);
            testWindow.Show();
        }
    }
}
