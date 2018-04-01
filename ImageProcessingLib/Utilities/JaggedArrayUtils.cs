using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLib.Utilities
{
    public class JaggedArrayUtils
    {
        public static T[][] Create<T>(int width, int height)
        {
            var result = new T[width][];
            for (int i = 0; i < width; i++)
                result[i] = new T[height];
            return result;
        }

        public static T[][] Copy<T>(T[][] source)
        {
            var len = source.Length;
            var result = new T[len][];
            for (int i = 0; i < len;i++)
            {
                var inner = source[i];
                var innerLen = inner.Length;
                var innerResult = new T[innerLen];
                Array.Copy(inner, innerResult, innerLen);
                result[i] = innerResult;
            }
            return result;
        }
    }
}
