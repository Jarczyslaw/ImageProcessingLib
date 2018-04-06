using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceTests.BenchmarkRunner
{
    public class Runner
    {
        private List<Type> availableBenchmarks;
        private RunnerInput runnerInput;
        private RunnerOutput runnerOutput;
        private RunnerLog runnerLog;

        public Runner(List<Type> availableBenchmarks)
        {
            this.availableBenchmarks = availableBenchmarks;
            runnerInput = new RunnerInput();
            runnerOutput = new RunnerOutput();
            runnerLog = new RunnerLog();
        }

        public void Run()
        {
            while (true)
            {
                runnerOutput.ShowList(availableBenchmarks);
                runnerOutput.ShowListPrompt();

                int inputValue = runnerInput.GetListInput(availableBenchmarks.Count);
                if (inputValue != -1)
                {
                    var selectedBenchmark = availableBenchmarks[inputValue];
                    BenchmarkDotNet.Running.BenchmarkRunner.Run(selectedBenchmark);

                    runnerOutput.ShowOpenLogPrompt();
                    if (runnerInput.GetOpenLogInput())
                        runnerLog.OpenLog(selectedBenchmark);
                }
                else
                    runnerOutput.ShowInvalidValue();

                runnerOutput.ShowEmptyLine();
            }
        }
    }
}
