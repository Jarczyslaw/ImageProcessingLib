using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;
using ImageProcessingLib.Wrappers.WF;

namespace ImageProcessingLibExamples.Examples
{
    public class Rotation : ExampleBase
    {
        public override void AddExampleImages(Dictionary<string, ImageWrapper> images, Image<Pixel32> originalImage)
        {
            var image = originalImage.Copy();
            image.RotationClockwise();
            images.Add("Clockwise", new ImageWrapper(image));
            image = originalImage.Copy();
            image.RotationCounterClockwise();
            images.Add("CounterClockwise", new ImageWrapper(image));
            image = originalImage.Copy();
            image.Rotation(30);
            images.Add("Degress30", new ImageWrapper(image));
            image = originalImage.Copy();
            image.Rotation(-30);
            images.Add("Degrees-30", new ImageWrapper(image));
        }
    }
}
