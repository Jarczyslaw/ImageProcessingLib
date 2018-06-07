using BenchmarkDotNet.Attributes;
using Benchmarking.BenchmarkLauncher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmarking.Benchmarks
{
    [BenchmarkSet("ClassVsStruct")]
    public class ClassVsStruct
    {
        private int len = 1000000;

        [Benchmark]
        public void Classes()
        {
            for (int i = 0; i < len; i++)
            {
                var pixel = new PixelClass(255, 255, 255, 255);
            }    
        }

        [Benchmark]
        public void Structs()
        {
            for (int i = 0; i < len; i++)
            {
                var pixel = new PixelStruct(255, 255, 255, 255);
            }
        }
    }
}
