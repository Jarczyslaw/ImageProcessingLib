using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;
using ImageProcessingLib.GDI;

namespace ImageProcessingLibExamples.Examples
{
    public class Rotation : ExampleBase
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
            images.Add("Degress30", new GDImage32(image));
            image = originalImage.Copy();
            image.Rotation(-30);
            images.Add("Degrees-30", new GDImage32(image));
        }
    }
}
