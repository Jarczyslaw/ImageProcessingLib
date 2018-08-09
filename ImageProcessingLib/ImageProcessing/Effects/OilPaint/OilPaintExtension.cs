using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ImageProcessingLib
{
    public static class OilPaintExtension
    {
        public static Image<Pixel32> OilPaint(this Image<Pixel32> image, int size, int levels)
        {
            Validate(size, levels);

            var range = size / 2;
            var original = image.Copy();
            original.ForEachNeighbourhood(range, (x, y, neighbourhood) =>
            {
                var pixel = original.Get(x, y);
                var accumulator = new OilPaintLookup(levels);
                for (int i = 0; i < neighbourhood.Length; i++)
                    accumulator.Add(neighbourhood[i]);
                image.Set(x, y, accumulator.GetResult(pixel.A));
            });
            return image;
        }

        private static void Validate(int range, int levels)
        {
            ValidationUtils.IsMaskSize(range);

            if (levels <= 0)
                throw new ArgumentException("Levels value has to be positive");
        }
    }
}
