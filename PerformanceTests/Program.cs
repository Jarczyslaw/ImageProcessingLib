using BenchmarkDotNet.Running;
using PerformanceTests.BenchmarkLauncher;
using System;
using System.Collections.Generic;
using System.Drawing;
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
            var collector = new BenchmarkCollector();
            var runner = new Launcher(collector.GetAllBenchmarks());
            runner.Run();
        }
    }
}
