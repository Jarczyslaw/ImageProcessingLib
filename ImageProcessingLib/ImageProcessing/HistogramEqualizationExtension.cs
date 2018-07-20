using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ImageProcessingLib
{
    public static class HistogramEqualizationExtension
    {
        public static Image<Pixel8> HistogramEqualization(this Image<Pixel8> image)
        {
            var histogram = image.Histogram();
            var valTable = GetProbabilityTable(histogram.GetCummulativeData(), image.Size);
            Pixel8 pixelOperator(Pixel8 pixel)
            {
                var val = Equalization(pixel.Value, valTable);
                return new Pixel8(val);
            };
            return image.HistogramEqualization(pixelOperator);
        }

        public static Image<Pixel32> HistogramEqualization(this Image<Pixel32> image)
        {
            var histogram = image.Histogram();
            var rTable = GetProbabilityTable(histogram.R.GetCummulativeData(), image.Size);
            var gTable = GetProbabilityTable(histogram.G.GetCummulativeData(), image.Size);
            var bTable = GetProbabilityTable(histogram.B.GetCummulativeData(), image.Size);
            Pixel32 pixelOperator(Pixel32 pixel)
            {
                var r = Equalization(pixel.R, rTable);
                var g = Equalization(pixel.G, gTable);
                var b = Equalization(pixel.B, bTable);
                return new Pixel32(pixel.A, r, g, b);
            };
            return image.HistogramEqualization(pixelOperator);
        }

        private static Image<TPixelType> HistogramEqualization<TPixelType>(this Image<TPixelType> image, PixelOperator<TPixelType> pixelOperator)
            where TPixelType : struct, IPixel<TPixelType>
        {
            image.ForEach((x, y) =>
            {
                var pixel = image.Get(x, y);
                var newPixel = pixelOperator(pixel);
                image.Set(x, y, newPixel);
            });
            return image;
        }

        private static double[] GetProbabilityTable(int[] cummulativeData, int div)
        {
            var result = new double[cummulativeData.Length];
            for (int i = 0; i < cummulativeData.Length; i++)
                result[i] = (double)cummulativeData[i] / div;
            return result;
        }

        private static byte Equalization(byte component, double[] probabilityTable)
        {
            return MathUtils.FloorToByte(byte.MaxValue * probabilityTable[component]);
        }
    }
}
