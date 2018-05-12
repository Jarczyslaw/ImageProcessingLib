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
        public double[] Kernel { get; private set; }

        public LinearFilter(double multiplier, int[,] kernel)
        {
            Validate(kernel);

            Size = kernel.GetLength(0);
            Range = (int)Math.Ceiling(Size / 2d) - 1;
            KernelFlattening(multiplier, kernel);
        }

        public byte Apply(byte[] neighbourhood)
        {
            var result = 0d;
            for (int i = 0; i < Kernel.Length; i++)
                result += Kernel[i] * neighbourhood[i];
            return MathUtils.RoundToByte(result);
        }

        private void Validate(int[,] kernel)
        {
            if (kernel.GetLength(0) != kernel.GetLength(1))
                throw new ArgumentException("Kernel must to be a square matrix");
        }

        private void KernelFlattening(double multiplier, int[,] kernel)
        {
            Kernel = new double[Size * Size];
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    Kernel[j + i * Size] = multiplier * kernel[i, j];
        }
    }
}
