using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public class LinearFilter : IFilter
    {
        public int Range { get; private set; }
        public int Size { get; private set; }
        public int KernelLength { get; private set; }
        public double[] Kernel { get; private set; }

        public LinearFilter(double multiplier, int[,] kernel)
        {
            Validate(kernel);

            Size = kernel.GetLength(0);
            Range = (int)Math.Ceiling(Size / 2d) - 1;
            KernelFlattening(multiplier, kernel);
            KernelLength = Kernel.Length;
        }

        public byte Apply(byte[] neighbourhood)
        {
            var result = 0d;
            for (int i = 0; i < KernelLength; i++)
                result += Kernel[i] * neighbourhood[i];
            return MathUtils.RoundToByte(result);
        }

        private void Validate(int[,] kernel)
        {
            if (kernel.GetLength(0) != kernel.GetLength(1))
                throw new ArgumentException("Kernel must to be a square matrix");

            if (kernel.GetLength(0) % 2 == 0)
                throw new ArgumentException("Kernel sizes must be odd");
        }

        private void KernelFlattening(double multiplier, int[,] kernel)
        {
            Kernel = new double[Size * Size];
            int index = 0;
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    Kernel[index++] = multiplier * kernel[i, j];
        }
    }
}
