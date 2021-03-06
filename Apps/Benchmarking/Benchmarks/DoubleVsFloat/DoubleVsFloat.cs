﻿using BenchmarkDotNet.Attributes;
using Benchmarking.BenchmarkLauncher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmarking.Benchmarks
{
    /// <summary>
    /// Float vs double operations in color -> grayscale convertion
    /// </summary>
    [BenchmarkSet("DoubleVsFloat")]
    public class DoubleVsFloat
    {
        private int r = 10;
        private int g = 20;
        private int b = 30;

        [Benchmark]
        public void Double()
        {
            var result = (byte)(0.3d * r + 0.59d * g + 0.11d * b);
        }

        [Benchmark]
        public void Float()
        {
            var result = (byte)(0.3f * r + 0.59f * g + 0.11f * b);
        }
    }
}
