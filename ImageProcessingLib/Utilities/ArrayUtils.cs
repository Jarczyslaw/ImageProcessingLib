using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib.Utilities
{
    public static class ArrayUtils
    {
        public static T[] Flatten<T>(T[,] arr)
        {
            var rows = arr.GetLength(0);
            var cols = arr.GetLength(1);
            var resultLength = rows * cols;
            var result = new T[resultLength];
            var index = 0;
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    result[index++] = arr[i, j];
            return result;
        }

        public static bool IsSquare<T>(T[,] arr)
        {
            return arr.GetLength(0) == arr.GetLength(1);
        }

        public static bool IsFilterMask<T>(T[,] arr)
        {
            var rows = arr.GetLength(0);
            return IsSquare(arr) && rows >= 3 && rows % 2 == 1;
        }
    }
}
