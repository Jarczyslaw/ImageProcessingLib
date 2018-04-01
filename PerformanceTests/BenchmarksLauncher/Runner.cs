using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceTests.BenchmarksLauncher
{
    public class Runner
    {
        public enum InputStatus
        {
            BenchmarkSelected,
            QuitSelect,
            InvalidValue
        }

        private List<Type> availableBenchmarks;

        public Runner(List<Type> availableBenchmarks)
        {
            this.availableBenchmarks = availableBenchmarks;
        }

        private void ShowBenchmarksList()
        {
            if (availableBenchmarks == null || availableBenchmarks.Count == 0)
                throw new Exception("No available benchmarks here");

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Select benchmark from list or enter q for exit:");
            for (int i = 0; i < availableBenchmarks.Count; i++)
            {
                var benchmark = availableBenchmarks[i];
                sb.AppendFormat("   {0}. {1}", i + 1, benchmark.Name);
                sb.AppendLine(string.Empty);
            }
            Console.Write(sb.ToString());
        }

        private void ShowPrompt()
        {
            Console.Write(Environment.NewLine);
            Console.Write("Benchmark number: ");
        }

        private InputStatus GetUserInput(ref int value)
        {
            var input = Console.ReadLine();
            input = input.ToLower().Trim();
            if (input == "q")
                return InputStatus.QuitSelect;
            else
            {
                if (int.TryParse(input, out int result))
                {
                    if (result > 0 && result <= availableBenchmarks.Count)
                    {
                        value = result;
                        return InputStatus.BenchmarkSelected;
                    }
                    else
                        return InputStatus.InvalidValue;
                }
                else
                    return InputStatus.InvalidValue;
            }
        }

        private bool ProcessInput(InputStatus status, int value)
        {
            var repeat = true;
            if (status == InputStatus.BenchmarkSelected)
            {
                var benchmark = availableBenchmarks[value - 1];
                BenchmarkRunner.Run(benchmark);
                Console.WriteLine(string.Empty);
                ShowBenchmarksList();
            }
            else if (status == InputStatus.InvalidValue)
                Console.WriteLine("Invalid value");
            else
                repeat = false;
            return repeat;
        }

        public void Run()
        {
            bool repeat = true;
            ShowBenchmarksList();
            while (repeat)
            {
                ShowPrompt();

                int selectedBenchmark = 0;
                var status = GetUserInput(ref selectedBenchmark);
                repeat = ProcessInput(status, selectedBenchmark); 
            }
        }
    }
}
