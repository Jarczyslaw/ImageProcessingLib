using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceTests.BenchmarksLauncher
{
    public class BenchmarksCollector
    {
        private Assembly currentAssembly;

        public BenchmarksCollector()
        {
            currentAssembly = Assembly.GetExecutingAssembly();
        }

        public List<Type> GetAllBenchmarks()
        {
            var allTypes = currentAssembly.GetTypes();
            return allTypes.Where(t => t.GetCustomAttribute<AvailableBenchmarkAttribute>() != null)
                .OrderBy(t => t.Name)
                .ToList();
        }
    }
}
