using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceTests.BenchmarkLauncher
{
    public class BenchmarkCollector
    {
        private Assembly currentAssembly;

        public BenchmarkCollector()
        {
            currentAssembly = Assembly.GetExecutingAssembly();
        }

        public List<AvailableBenchmark> GetAllBenchmarks()
        {
            var result = new List<AvailableBenchmark>();
            var types = currentAssembly.GetTypes();
            foreach(var type in types)
            {
                var attr = type.GetCustomAttribute<BenchmarkSetAttribute>();
                if (attr != null && !attr.Hidden)
                {
                    var benchmark = new AvailableBenchmark()
                    {
                        Title = attr.Title,
                        BenchmarkSet = type
                    };
                    result.Add(benchmark);
                }
            }
            return result.OrderBy(b => b.Title).ToList();
        }
    }
}
