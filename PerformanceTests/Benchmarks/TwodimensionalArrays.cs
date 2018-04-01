using BenchmarkDotNet.Attributes;
using PerformanceTests.BenchmarksLauncher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceTests.Benchmarks
{
    [ActiveBenchmark]
    public class TwodimensionalArrays
    {
        public class Array1D
        {
            private byte[] data;
            private int width;
            private int height;

            public Array1D(int width, int height)
            {
                this.width = width;
                this.height = height;
                data = new byte[width * height];
            }

            public byte this[int x, int y]
            {
                get { return data[width * x + y]; }
                set { data[width * x + y] = value; }
            }
        }

        [Params(200, 1000)]
        public int size;

        private byte[][] jaggedArray;
        private byte[,] array2D;
        private Array1D array1D;

        [GlobalSetup]
        public void Setup()
        {
            array1D = new Array1D(size, size);
            jaggedArray = new byte[size][];
            for (int i = 0; i < size; i++)
                jaggedArray[i] = new byte[size];
            array2D = new byte[size, size];
        }

        [Benchmark]
        public void Array1DTest()
        {
            ForEach((i, j) =>
            {
                byte x = array1D[i, j];
                x++;
                array1D[i, j] = x;
            });
        }

        [Benchmark]
        public void JaggedArrayTest()
        {
            ForEach((i, j) =>
            {
                byte x = jaggedArray[i][j];
                x++;
                jaggedArray[i][j] = x;
            });
        }

        [Benchmark]
        public void Array2DTest()
        {
            ForEach((i, j) =>
            {
                byte x = array2D[i, j];
                x++;
                array2D[i, j] = x;
            });
        }

        private void ForEach(Action<int, int> action)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    action(i, j);
            }
        }
    }
}
