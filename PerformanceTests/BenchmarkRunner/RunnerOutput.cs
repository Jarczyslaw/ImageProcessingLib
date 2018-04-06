using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceTests.BenchmarkRunner
{
    public class RunnerOutput
    {
        public void ShowList(List<Type> availableBenchmarks)
        {
            if (availableBenchmarks == null || availableBenchmarks.Count == 0)
                throw new Exception("No available benchmarks here");

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Select benchmark from list:");
            for (int i = 0; i < availableBenchmarks.Count; i++)
            {
                var benchmark = availableBenchmarks[i];
                sb.AppendFormat("   {0}. {1}", i + 1, benchmark.Name);
                sb.AppendLine(string.Empty);
            }
            Console.Write(sb.ToString());
        }

        public void ShowListPrompt()
        {
            ShowEmptyLine();
            Console.Write("Benchmark number: ");
        }

        public void ShowOpenLogPrompt()
        {
            ShowEmptyLine();
            Console.Write("Open log? [Y/N]: ");
        }

        public void ShowInvalidValue()
        {
            Console.WriteLine("Invalid value");
        }

        public void ShowEmptyLine()
        {
            Console.Write(Environment.NewLine);
        }
    }
}
