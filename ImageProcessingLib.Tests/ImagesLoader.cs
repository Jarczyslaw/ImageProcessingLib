using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLib.Tests
{
    public class ImagesLoader
    {
        public static string TestImagesPath
        {
            get
            {
                var currentDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());
                var solutionDirectory = currentDirectory.Parent.Parent.Parent.FullName;
                return Path.Combine(solutionDirectory, "SolutionItems", "TestImages");
            }
        }

        public static Bitmap LoadFile(string fileName)
        {
            var lenaPath = Path.Combine(TestImagesPath, fileName);
            return new Bitmap(lenaPath);
        }

        public static Bitmap LoadLena()
        {
            return LoadFile("lena.bmp");  
        }

        public static Bitmap LoadLenaTrans()
        {
            return LoadFile("lena_trans.png");
        }

        public static Bitmap LoadLenaGrayscale()
        {
            return LoadFile("lena_gray.bmp");
        }
    }
}
