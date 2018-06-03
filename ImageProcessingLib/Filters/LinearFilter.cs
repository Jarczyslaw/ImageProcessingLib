using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public abstract class LinearFilter : IFilter
    {
        public int Range { get; private set; }
        public int Size { get; private set; }
        public int KernelLength { get; private set; }
        public double[] Kernel { get; private set; }

        public LinearFilter(double multiplier, int[,] kernel)
        {
            Validate(kernel);

            Size = kernel.GetLength(0);
            Range = Size / 2;
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
            if (!ArrayUtils.IsFilterMask(kernel))
                throw new ArgumentException("Filter mask must be square, with odd number of rows and columns. Filter mask must be higher or equal than 3");
        }

        private void KernelFlattening(double multiplier, int[,] kernel)
        {
            var flat = ArrayUtils.Flatten(kernel);
            Kernel = new double[flat.Length];
            for (int i = 0; i < flat.Length; i++)
                Kernel[i] = multiplier * flat[i];
        }
    }
}
