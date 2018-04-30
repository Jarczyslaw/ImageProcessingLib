using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;

namespace TestApps.Apps.ImageTest.ImagesCollectionSources
{
    public abstract class SourceBase : IImageCollectionSource
    {
        public ImagesCollection GetCollection(Image<Pixel32> image)
        {
            var collection = new ImagesCollection();
            collection.Add("Original", image);
            AddImages(collection, image);
            return collection;
        }

        public abstract void AddImages(ImagesCollection collection, Image<Pixel32> originalImage);
    }
}
