using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;

namespace ImageProcessingLibExamples.Examples
{
    public class Rotation : ExampleBase
    {
        public override void AddExampleImages(Dictionary<string, ImageWrapper> images, Image<Pixel32> originalImage)
        {
            var blank = Pixel32.Black;
            var image = originalImage.Copy();
            image.RotationClockwise();
            images.Add("Rotation_Clockwise", new ImageWrapper(image));
            image = originalImage.Copy();
            image.RotationCounterClockwise();
            images.Add("Rotation_CounterClockwise", new ImageWrapper(image));
            image = originalImage.Copy();
            image.RotationWithSizePreserving(45d, blank);
            images.Add("Rotation_SizePreserving", new ImageWrapper(image));
            image = originalImage.Copy();
            image.Rotation(30d, blank);
            images.Add("Rotation_Degress30", new ImageWrapper(image));
            image = originalImage.Copy();
            image.Rotation(-30d, blank);
            images.Add("Rotation_Degrees-30", new ImageWrapper(image));
        }
    }
}
