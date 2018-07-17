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

        private static byte[,] Normalize(double[,] arr, Func<double, double, double> normalizeFunc)
        {
            var rows = arr.GetLength(0);
            var cols = arr.GetLength(1);
            var result = new byte[rows, cols];
            var max = Max(arr);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    var value = arr[i, j];
                    result[i, j] = MathUtils.ByteClamp(normalizeFunc(value, max));
                }
            }
            return result;
        }

        public static byte[,] Normalize(double[,] arr)
        {
            return Normalize(arr, (value, max) => MathUtils.Normalize(value, max));
        }

        public static byte[,] NormalizeLog10(double[,] arr)
        {
            return Normalize(arr, (value, max) => MathUtils.NormalizeLog10(value, max));
        }

        public static List<int> IndicesOf<T>(IList<T> arr, T value)
        {
            var result = new List<int>();
            for (int i = 0;i < arr.Count;i++)
            {
                if (arr[i].Equals(value))
                    result.Add(i);
            }
            return result;
        }
    }
}
