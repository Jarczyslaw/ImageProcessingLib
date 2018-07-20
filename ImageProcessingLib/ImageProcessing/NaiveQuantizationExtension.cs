using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class NaiveQuantizationExtension
    {
        public static Image<Pixel8> NaiveQuantize(this Image<Pixel8> image, int levels)
        {
            var lookupTable = GetLookupTable(levels);
            Pixel8 pixelOperator(Pixel8 pixel)
            {
                var val = lookupTable[pixel.Value];
                return new Pixel8(val);
            };
            return image.NaiveQuantize(pixelOperator, levels);
        }

        public static Image<Pixel32> NaiveQuantize(this Image<Pixel32> image, int levels)
        {
            var lookupTable = GetLookupTable(levels);
            Pixel32 pixelOperator(Pixel32 pixel)
            {
                var r = lookupTable[pixel.R];
                var g = lookupTable[pixel.G];
                var b = lookupTable[pixel.B];
                return new Pixel32(pixel.A, r, g, b);
            };
            return image.NaiveQuantize(pixelOperator, levels);
        }

        private static Image<TPixelType> NaiveQuantize<TPixelType>(this Image<TPixelType> image, PixelOperator<TPixelType> pixelOperator, int levels)
            where TPixelType : struct, IPixel<TPixelType>
        {
            Validate(levels);
            image.ForEach((x, y) =>
            {
                var pixel = image.Get(x, y);
                var newPixel = pixelOperator(pixel);
                image.Set(x, y, newPixel);
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
