using ImageProcessingLib.Wrappers.WF;
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
            using (var wrapper = new ImageWrapper(bmp))
            {
                using (var result = new ImageWrapper(wrapper.Image32))
                    Run(result.Bitmap);
            }
        }

        private static void Run(Bitmap bitmap)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TestForm(bitmap));
        }
    }
}
