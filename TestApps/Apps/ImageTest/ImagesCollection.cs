using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;
using ImageProcessingLib.GDI;

namespace TestApps.Apps
{
    public class ImagesCollection
    {
        private int imagePtr = 0;
        public List<ImageEntry> Images { get; private set; } = new List<ImageEntry>();

        public void Add(string title, Image<Pixel32> image)
        {
            var gdi = new GDImage32(image);
            Images.Add(new ImageEntry() {
                Title = title,
                GDImage = gdi
            });
        }

        public GDImage32 GetFirstImage()
        {
            return Images.First().GDImage;
        }

        public GDImage32 NextImage()
        {
            imagePtr++;
            if (imagePtr >= Images.Count)
                imagePtr = 0;
            return Images[imagePtr].GDImage;
        }

        public GDImage32 PreviousImage()
        {
            imagePtr--;
            if (imagePtr < 0)
                imagePtr = Images.Count - 1;
            return Images[imagePtr].GDImage;
        }

        public void Dispose()
        {
            foreach (var entry in Images)
                entry.GDImage.Dispose();
        }

        public void Save(string path)
        {
            foreach(var entry in Images)
            {
                var filePath = Path.Combine(path, entry.Title + ".bmp");
                entry.GDImage.ToFile(filePath);
            }
        }
    }
}
