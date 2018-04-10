using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Running;

namespace PerformanceTests.BenchmarkLauncher
{
    public class Launcher
    {
        private List<AvailableBenchmark> availableBenchmarks;
        private LauncherInput runnerInput;
        private LauncherOutput runnerOutput;
        private LauncherLog runnerLog;

        public Launcher(List<AvailableBenchmark> availableBenchmarks)
        {
            this.availableBenchmarks = availableBenchmarks;
            runnerInput = new LauncherInput();
            runnerOutput = new LauncherOutput();
            runnerLog = new LauncherLog();
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
                    try
                    {
                        BenchmarkRunner.Run(selectedBenchmark.BenchmarkSet);
                        runnerOutput.ShowOpenLogPrompt();
                        if (runnerInput.GetOpenLogInput())
                            runnerLog.OpenLog(selectedBenchmark.BenchmarkSet);
                    }
                    catch(Exception e)
                    {
                        runnerOutput.ShowException(e);
                    }
                }
                else
                    runnerOutput.ShowInvalidValue();

                runnerOutput.ShowEmptyLine();
            }
        }
    }
}
