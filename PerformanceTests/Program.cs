using BenchmarkDotNet.Running;
using PerformanceTests.BenchmarksLauncher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceTests
{
    class Program
    {
        static void Main(string[] args)
        {
            var collector = new BenchmarksCollector();
            var runner = new Runner(collector.GetAllBenchmarks());
            runner.Run();
        }
    }
}
