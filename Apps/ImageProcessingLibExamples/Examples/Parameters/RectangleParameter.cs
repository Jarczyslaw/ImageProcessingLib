using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLibExamples.Examples.Parameters
{
    public class RectangleParameter
    {
        public string Title { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public RectangleParameter(string title, int x, int y, int width, int height)
        {
            Title = title;
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
    }
}
