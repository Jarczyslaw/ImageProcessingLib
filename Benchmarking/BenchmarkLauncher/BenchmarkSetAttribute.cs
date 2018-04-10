using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceTests.BenchmarkLauncher
{
    public class BenchmarkSetAttribute : Attribute
    {
        public string Title { get; }
        public bool Hidden { get; }

        public BenchmarkSetAttribute(string title) : this(title, false) { }

        public BenchmarkSetAttribute(string title, bool hidden)
        {
            Title = title;
            Hidden = hidden;
        }
    }
}
