using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class CartoonExtension
    {
        public static Image<Pixel32> Cartoon(this Image<Pixel32> image, int size, int levels, byte threshold = 127)
        {
            var edges = image.CopyAs(p => p.ToPixel8())
                .ApplyFilter(new SobelFilter(true))
                .BlackAndWhite(threshold)
                .Inversion();
            image.OilPaint(size, levels);

            var blackEdge = Pixel8.Black;
            var imageBlack = Pixel32.Black;
            image.ForEach((x, y) =>
            {
                if (edges.Get(x, y).Value == blackEdge.Value)
                    image.Set(x, y, imageBlack);
            });
            return image;
        }
    }
}
