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
            images.Add("Rotation_Clockwise", new ImageWrapper(image));
            image = originalImage.Copy();
            image.RotationCounterClockwise();
            images.Add("Rotation_CounterClockwise", new ImageWrapper(image));
            image = originalImage.Copy();
            image.Rotation(30);
            images.Add("Rotation_Degress30", new ImageWrapper(image));
            image = originalImage.Copy();
            image.Rotation(-30);
            images.Add("Rotation_Degrees-30", new ImageWrapper(image));
        }
    }
}
