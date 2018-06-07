using BenchmarkDotNet.Attributes;
using Benchmarking.BenchmarkLauncher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmarking.Benchmarks
{
    [BenchmarkSet("FieldsVsProperties")]
    public class FieldsVsProperties
    {
        private AccessorsTest test = new AccessorsTest(42);

        [Benchmark]
        public void Fields()
        {
            var x = test.widthField;
            test.widthField = x;
        }

        [Benchmark]
        public void Properties()
        {
            var x = test.WidthProperty;
            test.WidthProperty = x;
        }
    }
}
