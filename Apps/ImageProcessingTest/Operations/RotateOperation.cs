using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;
using ImageProcessingLib.GDI;

namespace ImageProcessingTest.Operations
{
    public class RotateOperation : OperationBase
    {
        public override void AddImages(Dictionary<string, GDImage32> images, Image<Pixel32> originalImage)
        {
            var image = originalImage.Copy();
            image.RotateClockwise();
            images.Add("Clockwise", new GDImage32(image));
            image = originalImage.Copy();
            image.RotateCounterClockwise();
            images.Add("CounterClockwise", new GDImage32(image));
            image = originalImage.Copy();
            image.Rotate(30);
            images.Add("By30Degrees", new GDImage32(image));
        }
    }
}
