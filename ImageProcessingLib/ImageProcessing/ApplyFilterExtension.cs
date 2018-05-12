using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ImageProcessingLib.ImageProcessing
{
    public static class ApplyFilterExtension
    {
        public static Image<Pixel32> ApplyFilter(this Image<Pixel32> image, IFilter filter)
        {
            return image.ForEachNeighbourhood(filter.Range, (x, y, neighbourhood) =>
            {
                var pixel = image.Get(x, y);
                var r = filter.Apply(neighbourhood.Select(p => p.R).ToArray());
                var g = filter.Apply(neighbourhood.Select(p => p.G).ToArray());
                var b = filter.Apply(neighbourhood.Select(p => p.B).ToArray());
                image.Set(x, y, new Pixel32(pixel.A, r, g, b));
            });
        }
    }
}
