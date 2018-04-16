using BenchmarkDotNet.Attributes;
using PerformanceTests.BenchmarkLauncher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceTests.Benchmarks
{
    [BenchmarkSet("ClassVsStruct")]
    public class ClassVsStruct
    {
        [Benchmark]
        public void Classes()
        {
            var pixel = new PixelClass(255, 255, 255, 255);
        }

        [Benchmark]
        public void Structs()
        {
            var pixel = new PixelStruct(255, 255, 255, 255);
        }
    }
}
