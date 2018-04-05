using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLib.Extensions
{
    public static class GraphicsExtensions
    {
        public static void CopyTo(this Graphics graphics, Bitmap source, Bitmap destination)
        {
            if (source.Width != destination.Width || source.Height != destination.Height)
                throw new ArgumentException("Invalid bitmaps sizes. They have to be the same size");

            using (var g = Graphics.FromImage(destination))
            {
                var rect = new Rectangle(0, 0, source.Width, source.Height);
                g.DrawImage(source, rect, rect, GraphicsUnit.Pixel);
            }
        }
    }
}
