using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceTests.Benchmarks
{
    public class Array1D
    {
        private byte[] data;
        private int width;
        private int height;

        public Array1D(int width, int height)
        {
            this.width = width;
            this.height = height;
            data = new byte[width * height];
        }

        public byte this[int x, int y]
        {
            get { return data[width * x + y]; }
            set { data[width * x + y] = value; }
        }
    }
}
