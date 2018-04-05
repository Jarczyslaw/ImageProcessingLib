using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Jobs;
using BenchmarkDotNet.Engines;
using PerformanceTests.BenchmarksLauncher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceTests.Benchmarks.Test
{
    [BenchmarkSet]
    [SimpleJob(RunStrategy.Monitoring, launchCount: 0, warmupCount: 0, targetCount: 1)]
    public class _Test
    {
        [Params(1, 2)]
        public int param;

        [GlobalSetup]
        public void Setup()
        {
            // runs once per param before all benchmarks
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            // runs once per param after all benchmarks
        }

        [IterationSetup]
        public void IterationSetup()
        {
            // runs before benchmarks for each warmup or target iteration
        }

        [IterationCleanup]
        public void IterationCleanup()
        {
            // runs after benchmarks for each warmup or target iteration
        }

        [Benchmark]
        public void BenchmarkA()
        {
            Dummy(1);
        }

        [Benchmark]
        public void BenchmarkB()
        {
            Dummy(2);
        }

        [Benchmark]
        public void BenchmarkC()
        {
            Dummy(3);
        }

        private void Dummy(int iters)
        {
            int cnt = iters * param * 10000000;
            int x = 0;
            for (int i = 0; i < cnt; i++)
                x++;
        }
    }
}
