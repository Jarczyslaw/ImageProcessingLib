using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib.ImageProcessing
{
    public static class NaiveQuantizationExtension
    {
        public static Image<Pixel32> NaiveQuantize(this Image<Pixel32> image, int levels)
        {
            Validate(levels);

            var lookupTable = GetLookupTable(levels);
            image.ForEach((x, y) =>
            {
                var pixel = image.Get(x, y);
                var newR = lookupTable[pixel.R];
                var newG = lookupTable[pixel.G];
                var newB = lookupTable[pixel.B];
                image.Set(x, y, new Pixel32(pixel.A, newR, newG, newB));
            });
            return image;
        }

        private static void Validate(int levels)
        {
            if (levels < 2 || levels > 256)
                throw new ArgumentException("Levels should be between 2 and 256");
        }

        private static byte[] GetLookupTable(int levels)
        {
            byte[] table = new byte[256];
            double maxValue = 255d;
            double quantum = maxValue / (levels - 1);
            int interval = table.Length / levels;
            for (int i = 0; i < table.Length; i++)
            {
                var val = i / interval * quantum;
                if (val > maxValue)
                    val = maxValue;
                table[i] = (byte)val;
            }
            return table;
        }
    }
}
