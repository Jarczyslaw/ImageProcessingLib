using BenchmarkDotNet.Attributes;
using PerformanceTests.BenchmarkLauncher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceTests.Benchmarks
{
    [BenchmarkSet]
    public class ForEachPixel
    {
        private int width = 1000;
        private int height = 2000;
        private int[] array;

        private int GetIndex(int x, int y)
        {
            return x + (y * width);
        }

        private void ForEach(Action<int, int> action)
        {
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    action(j, i);
        }

        [GlobalSetup]
        public void Setup()
        {
            array = new int[width * height];
        }

        [Benchmark]
        public void ClassicFor()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    var index = GetIndex(j, i);
                    array[index]++;
                }
            } 
        }

        [Benchmark]
        public void ForEach()
        {
            ForEach((x, y) =>
            {
                var index = GetIndex(x, y);
                array[index]++;
            });
        }
    }
}
