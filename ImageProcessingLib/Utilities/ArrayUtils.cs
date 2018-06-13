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

        public static T[,] SubArray<T>(T[,] arr, int x, int y, int rows, int cols)
        {
            var result = new T[rows, cols];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    result[i, j] = arr[i + x, j + y];
            return result;
        }

        public static T[] SubArray<T>(T[] arr, int x, int width)
        {
            var result = new T[width];
            for (int i = 0; i < width; i++)
                result[i] = arr[i + x];
            return result;
        }

        public static T[,] Reshape<T>(T[] arr, int rows, int cols)
        {
            var result = new T[rows, cols];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    result[i, j] = arr[i * cols + j];
            return result;
        }

        public static double Max(double[,] arr)
        {
            var rows = arr.GetLength(0);
            var cols = arr.GetLength(1);
            var max = arr[0, 0];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    var value = arr[i, j];
                    if (value > max)
                        max = value;
                }
            }
            return max;
        }

        public static byte[,] NormalizeWithLog10(double[,] arr)
        {
            var rows = arr.GetLength(0);
            var cols = arr.GetLength(1);
            var max = Max(arr);
            if (max == 0d)
                throw new ArgumentException("Array can not be normalized because max value is equal to 0");

            var result = new byte[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    var value = arr[i, j];
                    result[i, j] = MathUtils.ByteClamp(255 * Math.Log10(1d + value) / Math.Log10(1d + max));
                }
            }
            return result;
        }
    }
}
