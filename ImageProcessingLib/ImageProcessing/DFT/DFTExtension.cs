using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class DFTExtension
    {
        public static ComplexNumber[,] DFT(double[,] imageData)
        {
            var rows = imageData.GetLength(0);
            var cols = imageData.GetLength(1);
            var sizeSqrt = Math.Sqrt(rows * cols);
            var result = new ComplexNumber[rows, cols];
            var q = -ComplexNumber.ImaginaryOne * 2d * Math.PI;
            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < cols; y++)
                {
                    var sum = ComplexNumber.Zero;
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            var phi = (double)x * i / rows + (double)y * j / cols;
                            sum += imageData[i, j] * ComplexNumber.Exp(ComplexNumber.Mul(q, phi));
                        }
                    }
                    result[x, y] = sum / sizeSqrt;
                }
            }
            return result;
        }

        public static Image<Pixel32> SDFT(this Image<Pixel32> image)
        {
            image.Grayscale();
            var data = Shift(image);
            return ImageDFT(data);
        }

        public static Image<Pixel32> DFT(this Image<Pixel32> image)
        {
            image.Grayscale();
            var data = GetImageData(image);
            return ImageDFT(data);
        }

        private static Image<Pixel32> ImageDFT(double[,] imageData)
        {
            var dft = DFT(imageData);
            var magnitudes = GetMagnitudes(dft);
            var resultData = ArrayUtils.NormalizeWithLog10(magnitudes);
            return Image32Utils.GetGrayscaleImageFromArray(resultData);
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

        private static double[,] PrepareDataFromImage(Image<Pixel32> image)
        {
            image.Grayscale();
            var shiftedImage = Shift(image);
            return shiftedImage;
        }

        private static double[,] Shift(Image<Pixel32> image)
        {
            var width = image.Width;
            var height = image.Height;
            var shifted = new double[height, width];
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    shifted[i, j] = Math.Pow(-1d, i + j) * image.Get(j, i).R;
            return shifted;
        }

        private static double[,] GetImageData(Image<Pixel32> image)
        {
            var width = image.Width;
            var height = image.Height;
            var data = new double[height, width];
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    data[i, j] = image.Get(j, i).R;
            return data;
        }
    }
}
