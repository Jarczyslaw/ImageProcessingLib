using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;
using ImageProcessingLib.GDI;
using ImageProcessingLib.ImageProcessing;

namespace ImageProcessingTest.Operations
{
    public class InversionOperation : OperationBase
    {
        public override void AddImages(Dictionary<string, GDImage32> images, Image<Pixel32> originalImage)
        {
            var conversionPoints = new byte[] { 64, 128, 196 };
            foreach(var conversionPoint in conversionPoints)
            {
                var image = originalImage.Copy();
                image.Inversion(conversionPoint);
                images.Add("Inversion" + conversionPoint, new GDImage32(image));
            }
        }
    }
}
