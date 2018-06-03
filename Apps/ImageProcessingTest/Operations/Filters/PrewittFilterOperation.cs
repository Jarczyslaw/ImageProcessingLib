using ImageProcessingLib;
using ImageProcessingLib.GDI;
using ImageProcessingLib.ImageProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingTest.Operations
{
    public class PrewittFilterOperation : OperationBase
    {
        public override void AddImages(Dictionary<string, GDImage32> images, Image<Pixel32> originalImage)
        {
            var image = originalImage.Copy();
            image.ApplyFilter(new PrewittFilter());
            images.Add("SobelFilterAccurate", new GDImage32(image));
            image = originalImage.Copy();
            image.ApplyFilter(new PrewittFilter(true));
            images.Add("SobelFilterApproximation", new GDImage32(image));
        }
    }
}
