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
    public class _Test
    {
        private int count = 1000000;
        private long counter;

        [Benchmark]
        public void Test1()
        {
            if (counter == 0)
                counter = int.MaxValue;
            for (int i = 0; i < count; i++)
                counter--;
        }

        [Benchmark]
        public void Test2()
        {
            if (counter == count)
                counter = 0;
            for (int i = 0; i < count; i++)
                counter++;
        }
    }
}
