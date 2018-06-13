using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class DFTExtension
    {
        public static ComplexNumber[,] DFT(this Image<Pixel32> image)
        {
            var width = image.Width;
            var height = image.Height;
            var size = width * height;
            var sizeSqrt = Math.Sqrt(size);
            var result = new ComplexNumber[width, height];
            image.Grayscale();
            image.ForEach((x, y) =>
            {
                var sum = ComplexNumber.Zero;
                image.ForEach((i, j) =>
                {
                    var phi = (double)x * i / width + (double)y * j / height;
                    sum += ComplexNumber.Exp(-ComplexNumber.ImaginaryOne * 2d * Math.PI * phi);
                });
                result[x, y] = sum / sizeSqrt;
            });
            return result;
        }

        public static Image<Pixel32> DFTImage(this Image<Pixel32> image)
        {
            var width = image.Width;
            var height = image.Height;
            var result = new Image<Pixel32>(width, height, Pixel32.Black);

            var dft = image.DFT();
            var magnitudes = GetMagnitudes(dft);
            var shiftedMagnitudes = Shift(magnitudes);
            var resultData = ArrayUtils.NormalizeWithLog10(shiftedMagnitudes);


            return result;
        }

        private static double[,] GetMagnitudes(ComplexNumber[,] dft)
        {
            var rows = dft.GetLength(0);
            var cols = dft.GetLength(1);
            var magnitudes = new double[rows, cols];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    magnitudes[i, j] = dft[i, j].Magnitude;
            return magnitudes;
        }

        private static double[,] Shift(double[,] data)
        {
            var rows = data.GetLength(0);
            var cols = data.GetLength(1);
            var shifted = new double[rows, cols];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    shifted[i, j] = Math.Pow(-1d, i + j) * data[i, j];
            return shifted;
        }
    }
}
