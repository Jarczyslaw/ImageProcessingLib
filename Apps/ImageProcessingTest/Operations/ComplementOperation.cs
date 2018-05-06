using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;
using ImageProcessingLib.GDI;

namespace ImageProcessingTest.Operations
{
    public class ComplementOperation : OperationBase
    {
        public override void AddImages(Dictionary<string, GDImage32> images, Image<Pixel32> originalImage)
        {
            var originalWidth = originalImage.Width;
            var originalHeight = originalImage.Height;
            var newSizes = new Tuple<int, int>[]
            {
                Tuple.Create(originalWidth, originalHeight),
                Tuple.Create(originalWidth + 50, originalHeight + 50),
                Tuple.Create(originalWidth + 23, originalHeight + 32)
            };

            var image = originalImage.Copy();
            image.Complement(originalWidth + 32, originalHeight + 32, Pixel32.Red);
            images.Add("RedComplement", new GDImage32(image));
            foreach (var size in newSizes)
            {
                image = originalImage.Copy();
                image.Complement(size.Item1, size.Item2);
                images.Add(string.Format("BlankComplement{0}x{1}", size.Item1, size.Item2), new GDImage32(image));
            }
        }
    }
}
