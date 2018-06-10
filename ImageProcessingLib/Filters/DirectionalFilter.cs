using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public class DirectionalFilter : IFilter
    {
        public int[] HorizontalMask { get; private set; }
        public int[] VerticalMask { get; private set; }

        public int Range { get; private set; }
        public bool UseApproximation { get; private set; }

        private Func<int, int, double> ResultCalc;

        public DirectionalFilter(int[,] horizontalMask, int[,] verticalMask, bool useApproximation)
        {
            Validate(horizontalMask, verticalMask);

            HorizontalMask = ArrayUtils.Flatten(horizontalMask);
            VerticalMask = ArrayUtils.Flatten(verticalMask);
            UseApproximation = useApproximation;
            Range = horizontalMask.GetLength(0) / 2;

            if (useApproximation)
                ResultCalc = ApproximateResult;
            else
                ResultCalc = AccurateResult;
        }

        public byte Apply(byte[] neighbourhood)
        {
            var horizontalValue = ApplyDirectionMask(neighbourhood, HorizontalMask);
            var verticalValue = ApplyDirectionMask(neighbourhood, VerticalMask);
            return MathUtils.RoundToByte(ResultCalc(horizontalValue, verticalValue));
        }

        private double AccurateResult(int horizontalValue, int verticalValue)
        {
            return Math.Sqrt(horizontalValue * horizontalValue + verticalValue * verticalValue);
        }

        private double ApproximateResult(int horizontalValue, int verticalValue)
        {
            return Math.Abs(horizontalValue) + Math.Abs(verticalValue);
        }

        private int ApplyDirectionMask(byte[] neighbourhood, int[] mask)
        {
            var len = neighbourhood.Length;
            int result = 0;
            for (int i = 0; i < len; i++)
                result += neighbourhood[i] * mask[i];
            return result;
        }

        private void Validate(int[,] horizontalMask, int[,] verticalMask)
        {
            ValidationUtils.IsFilterMask(horizontalMask);
            ValidationUtils.IsFilterMask(verticalMask);

            if (horizontalMask.GetLength(0) != verticalMask.GetLength(1))
                throw new ArgumentException("Horizontal and vertical mask have same sizes");
        }
    }
}
