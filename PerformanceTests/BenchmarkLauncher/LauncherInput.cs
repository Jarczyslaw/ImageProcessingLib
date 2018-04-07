using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceTests.BenchmarkLauncher
{
    public class LauncherInput
    {
        public int GetListInput(int maxValue)
        {
            var result = -1;
            var input = Console.ReadLine();
            input = input.Trim();
            if (int.TryParse(input, out int inputValue))
            {
                if (inputValue > 0 && inputValue <= maxValue)
                    result = inputValue - 1;
            }
            return result;
        }

        public bool GetOpenLogInput()
        {
            var input = Console.ReadLine();
            input = input.Trim().ToLower();
            return input == "y";
        }
    }
}
