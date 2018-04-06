using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Diagnostics;

namespace PerformanceTests.BenchmarkRunner
{
    public class RunnerLog
    {
        private string assemblyPath;
        private string artifactsPath;

        public RunnerLog()
        {
            var assemblyLocation = Assembly.GetEntryAssembly().Location;
            assemblyPath = Path.GetDirectoryName(assemblyLocation);
            artifactsPath = Path.Combine(assemblyPath, "BenchmarkDotNet.Artifacts");
        }

        public void OpenLog(Type selectedBenchmark)
        {
            var log = GetLogPath(selectedBenchmark);
            try
            {
                Process.Start(log);
            }
            catch {}
        }

        private string GetLogPath(Type selectedBenchmark)
        {
            var fileName = selectedBenchmark.Name + ".log";
            return Path.Combine(artifactsPath, fileName);
        }
    }
}
