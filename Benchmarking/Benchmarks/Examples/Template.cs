using BenchmarkDotNet.Attributes;
using PerformanceTests.BenchmarkLauncher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceTests.Benchmarks
{
    [BenchmarkSet("Template", true)]
    public class Template
    {
        [GlobalSetup]
        public void Setup()
        {

        }

        [Benchmark]
        public void Benchmark1()
        {

        }

        [Benchmark]
        public void Benchmark2()
        {

        }
    }
}
