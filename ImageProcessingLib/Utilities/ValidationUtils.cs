using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib.Utilities
{
    public static class ValidationUtils
    {
        public static bool IsMaskSize(int maskSize, bool throwException = true)
        {
            var result = maskSize >= 3 && maskSize % 2 != 0;
            if (!result && throwException)
                throw new ArgumentException("Mask size must be odd and not less than 3");
            return result;
        }

        public static bool IsSquare<T>(T[,] arr)
        {
            return arr.GetLength(0) == arr.GetLength(1);
        }

        public static bool IsFilterMask<T>(T[,] arr, bool throwException = true)
        {
            var rows = arr.GetLength(0);
            var result = IsSquare(arr) && rows >= 3 && rows % 2 == 1;
            if (!result && throwException)
                throw new ArgumentException("Filter masks must be square, with odd number of rows and columns. Rows and columns number must be at least equal 3");
            return result;
        }
    }
}
