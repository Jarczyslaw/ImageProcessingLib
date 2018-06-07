using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Diagnostics;

namespace Benchmarking.BenchmarkLauncher
{
    public class LauncherLog
    {
        private string assemblyPath;
        private string artifactsPath;

        public LauncherLog()
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
