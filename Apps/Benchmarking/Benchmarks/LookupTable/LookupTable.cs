using BenchmarkDotNet.Attributes;
using Benchmarking.BenchmarkLauncher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmarking.Benchmarks
{
    [BenchmarkSet("LookupTable")]
    public class LookupTable
    {
        private int width = 1000;
        private int height = 2000;
        private int[] data;

        private int[][] lookupTableJagged;
        private int[,] lookupTable;

        [GlobalSetup]
        public void Setup()
        {
            data = new int[width * height];

            lookupTableJagged = new int[width][];
            for (int i = 0; i < width; i++)
            {
                lookupTableJagged[i] = new int[height];
                for (int j = 0; j < height; j++)
                {
                    lookupTableJagged[i][j] = i + j * width;
                }
            }

            lookupTable = new int[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                    lookupTable[i, j] = i + j * width;
            }
        }

        [Benchmark]
        public void WithoutLookup()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    int index = i + j * width;
                    int value = data[index];
                    data[index] = value;
                }
            }
        }

        [Benchmark]
        public void WithLookupJagged()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    var index = lookupTableJagged[i][j];
                    int value = data[index];
                    data[index] = value;
                }
            }
        }

        [Benchmark]
        public void WithLookup()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    var index = lookupTable[i, j];
                    int value = data[index];
                    data[index] = value;
                }
            }
        }
    }
}
