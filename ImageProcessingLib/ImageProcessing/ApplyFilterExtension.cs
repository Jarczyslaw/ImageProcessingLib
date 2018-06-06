using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ImageProcessingLib
{
    public static class ApplyFilterExtension
    {
        public static Image<Pixel32> ApplyFilter(this Image<Pixel32> image, IFilter filter)
        {
            var originalImage = image.Copy();
            return originalImage.ForEachNeighbourhood(filter.Range, (x, y, neighbourhood) =>
            {
                var pixel = originalImage.Get(x, y);
                var r = filter.Apply(GetComponentsFromNeighbourhood(neighbourhood, (p) => p.R));
                var g = filter.Apply(GetComponentsFromNeighbourhood(neighbourhood, (p) => p.G));
                var b = filter.Apply(GetComponentsFromNeighbourhood(neighbourhood, (p) => p.B));
                image.Set(x, y, new Pixel32(pixel.A, r, g, b));
            });
        }

        private static byte[] GetComponentsFromNeighbourhood(Pixel32[] neightbourhood, Func<Pixel32, byte> extractFunc)
        {
            var len = neightbourhood.Length;
            var result = new byte[len];
            for (int i = 0; i < len; i++)
                result[i] = extractFunc(neightbourhood[i]);
            return result;
        }
    }
}
