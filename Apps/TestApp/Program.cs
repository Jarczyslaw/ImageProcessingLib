using ImageProcessingLib.Wrappers.WF;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var img = new ImageWrapper(ImagesFolder.Images.Lena);
            var x = img.Image32;

            Run(img.Bitmap);   
        }

        private static void Run(Bitmap bitmap)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TestForm(bitmap));
        }
    }
}
