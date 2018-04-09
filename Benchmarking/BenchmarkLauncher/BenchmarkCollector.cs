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

        public List<Type> GetAllBenchmarks()
        {
            var allTypes = currentAssembly.GetTypes();
            return allTypes.Where(t => t.GetCustomAttribute<BenchmarkSetAttribute>() != null)
                .OrderBy(t => t.Name)
                .ToList();
        }
    }
}
