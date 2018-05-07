using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;
using ImageProcessingLib.GDI;

namespace ImageProcessingTest.Operations
{
    public class RotationOperation : OperationBase
    {
        public override void AddImages(Dictionary<string, GDImage32> images, Image<Pixel32> originalImage)
        {
            var image = originalImage.Copy();
            image.RotationClockwise();
            images.Add("Clockwise", new GDImage32(image));
            image = originalImage.Copy();
            image.RotationCounterClockwise();
            images.Add("CounterClockwise", new GDImage32(image));
            image = originalImage.Copy();
            image.Rotation(30);
            images.Add("By30Degrees", new GDImage32(image));
            image = originalImage.Copy();
            image.Rotation(-30);
            images.Add("By-30Degrees", new GDImage32(image));
        }
    }
}
