using ImageProcessingLib.Converter.WF;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApp.WF
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var bmp = ImagesFolder.Images.Lena;
            var image = ImageProcessingLibConverter.CreateImageFromBitmap(bmp);
            var result = ImageProcessingLibConverter.CreateBitmapFromImage(image);
            Run(result);
        }

        private static void Run(Bitmap bitmap)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TestForm(bitmap));
        }
    }
}
