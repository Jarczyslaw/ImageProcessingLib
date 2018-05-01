using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;

namespace TestApps.Apps.ImageTest.ImagesCollectionSources
{
    public class RotationSource : SourceBase
    {
        public override void AddImages(ImagesCollection collection, Image<Pixel32> originalImage)
        {
            var image = originalImage.Copy();
            image.RotateClockwise();
            collection.Add("Clockwise", image);
            image = image.Copy();
            image.RotateCounterClockwise();
            collection.Add("CounterClockwise", image);
            image = image.Copy();
            image.Rotate(30);
            collection.Add("By45Degrees", image);
        }
    }
}
