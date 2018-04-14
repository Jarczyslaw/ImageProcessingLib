using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceTests.Benchmarks
{
    public class AccessorsTest
    {
        public int widthField;
        public int WidthProperty { get; set; }

        public AccessorsTest(int w)
        {
            widthField = w;
            WidthProperty = w;
        }
    }
}
