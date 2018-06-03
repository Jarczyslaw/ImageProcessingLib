﻿using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public abstract class DirectionalFilter : IFilter
    {
        public int[] HorizontalMask { get; private set; }
        public int[] VerticalMask { get; private set; }

        public int Range { get; private set; }
        public bool UseApproximation { get; private set; }

        private Func<byte, byte, double> ResultCalc;

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

        private double AccurateResult(byte horizontalValue, byte verticalValue)
        {
            return Math.Sqrt(horizontalValue * horizontalValue + verticalValue * verticalValue);
        }

        private double ApproximateResult(byte horizontalValue, byte verticalValue)
        {
            return Math.Abs(horizontalValue) + Math.Abs(verticalValue);
        }

        private byte ApplyDirectionMask(byte[] neighbourhood, int[] mask)
        {
            var len = neighbourhood.Length;
            int result = 0;
            for (int i = 0; i < len; i++)
                result += neighbourhood[i] * mask[i];
            return MathUtils.RoundToByte(result);
        }

        private void Validate(int[,] horizontalMask, int[,] verticalMask)
        {
            if (!ArrayUtils.IsFilterMask(horizontalMask) || !ArrayUtils.IsFilterMask(verticalMask))
                throw new ArgumentException("Filter masks must be square, with odd number of rows and columns. Filter mask must be higher or equal than 3");

            if (horizontalMask.GetLength(0) != verticalMask.GetLength(1))
                throw new ArgumentException("Horizontal and vertical mask have different sizes");
        }
    }
}
