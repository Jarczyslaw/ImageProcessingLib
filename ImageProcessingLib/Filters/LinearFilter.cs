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
            ValidationUtils.IsFilterMask(kernel);

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
    }
}
