using BenchmarkDotNet.Attributes;
using Benchmarking.BenchmarkLauncher;
using ImageProcessingLib;
using ImageProcessingLib.Utilities;
using System.Drawing;

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
            BytesUtils.GetArgbFromData(startColor, out byte a, out byte r, out byte g, out byte b);
            var pixel32 = new Pixel32(a, r, g, b);
        }
    }
}
