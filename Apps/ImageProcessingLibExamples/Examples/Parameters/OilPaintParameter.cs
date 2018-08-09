using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLibExamples.Examples.Parameters
{
    public class OilPaintParameter
    {
        public int Size { get; set; }
        public int Levels { get; set; }

        public OilPaintParameter(int size, int levels)
        {
            Size = size;
            Levels = levels;
        }
    }
}
