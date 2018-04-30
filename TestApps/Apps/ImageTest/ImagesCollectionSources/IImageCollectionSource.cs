using ImageProcessingLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApps.Apps.ImageTest.ImagesCollectionSources
{
    public interface IImageCollectionSource
    {
        ImagesCollection GetCollection(Image<Pixel32> image);
    }
}
