using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLibExamples.Examples.Parameters
{
    public class MinMaxParameter
    {
        public byte Min { get; set; }
        public byte Max { get; set; }

        public MinMaxParameter(byte min, byte max)
        {
            Min = min;
            Max = max;
        }
    }
}
