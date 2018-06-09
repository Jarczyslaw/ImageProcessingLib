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
        public double Multiplier { get; private set; }
        public int[] Kernel { get; private set; }

        public LinearFilter(double multiplier, int[,] kernel)
        {
            Validate(kernel);

            Size = kernel.GetLength(0);
            Range = Size / 2;
            Kernel = ArrayUtils.Flatten(kernel);
            KernelLength = Kernel.Length;
            Multiplier = multiplier;
        }

        public byte Apply(byte[] neighbourhood)
        {
            var result = 0;
            for (int i = 0; i < KernelLength; i++)
                result += Kernel[i] * neighbourhood[i];
            return MathUtils.RoundToByte(result * Multiplier);
        }

        private void Validate(int[,] kernel)
        {
            if (!ArrayUtils.IsFilterMask(kernel))
                throw new ArgumentException("Filter mask must be square, with odd number of rows and columns. Filter mask must be higher or equal than 3");
        }
    }
}
