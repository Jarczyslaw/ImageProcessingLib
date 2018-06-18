using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLibExamples.Examples.Parameters
{
    public class SizeParameter
    {
        public string Title { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public SizeParameter(int width, int height)
            : this(string.Empty, width, height) { }

        public SizeParameter(string title, int width, int height)
        {
            Title = title;
            Width = width;
            Height = height;
        }
    }
}
