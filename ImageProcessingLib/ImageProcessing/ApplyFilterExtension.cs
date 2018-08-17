using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ImageProcessingLib
{
    public static class ApplyFilterExtension
    {
        public delegate TPixelType PixelFilterOperator<TPixelType>(TPixelType[] neighbourhood, TPixelType currentPixel);

        public static Image<Pixel8> ApplyFilter(this Image<Pixel8> image, IFilter filter)
        {
            Pixel8 pixelFilterOperator(Pixel8[] neighbourhood, Pixel8 currentPixel)
            {
                var value = filter.Apply(GetComponentFromNeighbourhood(neighbourhood, p => p.Value));
                return new Pixel8(value);
            };
            return image.ApplyFilter(pixelFilterOperator, filter);
        }

        public static Image<Pixel32> ApplyFilter(this Image<Pixel32> image, IFilter filter)
        {
            Pixel32 pixelFilterOperator(Pixel32[] neighbourhood, Pixel32 currentPixel)
            {
                var r = filter.Apply(GetComponentFromNeighbourhood(neighbourhood, p => p.R));
                var g = filter.Apply(GetComponentFromNeighbourhood(neighbourhood, p => p.G));
                var b = filter.Apply(GetComponentFromNeighbourhood(neighbourhood, p => p.B));
                return new Pixel32(currentPixel.A, r, g, b);
            };
            return image.ApplyFilter(pixelFilterOperator, filter);
        }

        private static Image<TPixelType> ApplyFilter<TPixelType>(this Image<TPixelType> image, PixelFilterOperator<TPixelType> pixelOperator, IFilter filter)
        {
            var originalImage = image.Copy();
            originalImage.ForEachNeighbourhood(filter.Range, (x, y, neighbourhood) =>
            {
                var pixel = originalImage.Get(x, y);
                var newPixel = pixelOperator(neighbourhood, pixel);
                image.Set(x, y, newPixel);
            });
            return image;
        }

        private static byte[] GetComponentFromNeighbourhood<TPixelType>(TPixelType[] neightbourhood, Func<TPixelType, byte> extractFunc)
        {
            var len = neightbourhood.Length;
            var result = new byte[len];
            for (int i = 0; i < len; i++)
                result[i] = extractFunc(neightbourhood[i]);
            return result;
        }
    }
}
