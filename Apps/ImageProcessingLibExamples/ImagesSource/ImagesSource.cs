using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLibExamples
{
    public class ImagesSource : IImagesSource
    {
        public Dictionary<string, Bitmap> Images { get; private set; } 

        public ImagesSource()
        {
            Images = new Dictionary<string, Bitmap>();
            var imagesFolder = ImagesFolder.Images.AllBitmaps;
            foreach (var pair in imagesFolder)
                Images.Add(pair.Key, pair.Value);
        }

        public void AddImage(string title, Bitmap image)
        {
            Images.Add(title, image);
        }
    }
}
