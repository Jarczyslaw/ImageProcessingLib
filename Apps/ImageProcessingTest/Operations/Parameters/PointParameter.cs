using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingTest.Operations.Parameters
{
    public class PointParameter
    {
        public string Title { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public PointParameter(int x, int y)
            : this(string.Empty, x, y) { }

        public PointParameter(string title, int x, int y)
        {
            Title = title;
            X = x;
            Y = y;
        }
    }
}
