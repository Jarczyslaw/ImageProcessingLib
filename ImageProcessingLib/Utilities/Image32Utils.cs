using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib.Utilities
{
    public static class Image32Utils
    {
        public static Image<Pixel32> GetGrayscaleImageFromArray(byte[,] arr)
        {
            var width = arr.GetLength(1);
            var height = arr.GetLength(0);
            var result = new Image<Pixel32>(width, height);
            result.ForEach((x, y) =>
            {
                var value = arr[y, x];
                result.Set(x, y, new Pixel32(value));
            });
            return result;
        }
    }
}
