using BenchmarkDotNet.Attributes;
using Benchmarking.BenchmarkLauncher;
using ImageProcessingLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmarking.Benchmarks
{
    /// <summary>
    /// Comparison between using generic image operation and explicit operation (local functions overhead). Comparison between using image8 and image32
    /// </summary>
    [BenchmarkSet("PixelOperator32Vs8")]
    public class PixelOperator32Vs8
    {
        private const int size = 500;
        private Image<Pixel32> image32 = new Image<Pixel32>(size, size);
        private Image<Pixel8> image8 = new Image<Pixel8>(size, size);
        private double gamma = 0.5d;

        [Benchmark]
        [BenchmarkCategory("PixelOperatorOverhead")]
        public void WithPixelOperator()
        {
            image32.GammaCorrection(gamma);
        }

        [Benchmark]
        [BenchmarkCategory("PixelOperatorOverhead")]
        public void WithoutPixelOperator()
        {
            image32.ExplicitGammaCorrection(gamma);
        }

        [Benchmark]
        [BenchmarkCategory("PixelTypeOperation")]
        public void Pixel32Operation()
        {
            image32.GammaCorrection(gamma);
        }

        [Benchmark]
        [BenchmarkCategory("PixelTypeOperation")]
        public void Pixel8Operation()
        {
            image8.GammaCorrection(gamma);
        }
    }
}
