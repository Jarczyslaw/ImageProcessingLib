using BenchmarkDotNet.Attributes;
using ImageProcessingLib;
using Benchmarking.BenchmarkLauncher;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmarking.Benchmarks
{
    /// <summary>
    /// Performance difference between default Color struct and Pixel32
    /// </summary>
    [BenchmarkSet("ColorVsPixel32")]
    public class ColorVsPixel32
    {
        private int startColor = -10185016; // #FF6496C8

        [Benchmark]
        public void ColorInitialization()
        {
            var color = Color.FromArgb(startColor);
        }

        [Benchmark]
        public void Pixel32Initialization()
        {
            var pixel32 = new Pixel32(startColor);
        }
    }
}
