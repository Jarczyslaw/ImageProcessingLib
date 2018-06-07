using BenchmarkDotNet.Attributes;
using Benchmarking.BenchmarkLauncher;
using ImageProcessingLib;
using ImageProcessingLib.Old;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmarking.Benchmarks
{
    [BenchmarkSet("VsOld_ColorImages")]
    public class ColorImages : VsOldImplementationBase
    {
        [Benchmark]
        [BenchmarkCategory(createNewCategory)]
        public void CreateNew()
        {
            var image32 = new Image<Pixel32>(width, height);
        }

        [Benchmark]
        [BenchmarkCategory(createNewCategory)]
        public void Old_CreateNew()
        {
            var img24 = new Img24(width, height);
        }

        [Benchmark]
        [BenchmarkCategory(valueChangingCategory)]
        public void ValueChanging()
        {
            var image32 = new Image<Pixel32>(width, height);
            image32.ForEach((x, y) =>
            {
                var pixel = image32.Get(x, y);
                image32.Set(x, y, new Pixel32(pixel));
            });
        }

        [Benchmark]
        [BenchmarkCategory(valueChangingCategory)]
        public void Old_ValueChanging()
        {
            var img24 = new Img24(width, height);
            img24.ForEach((x, y) =>
            {
                var value = img24.Get(x, y);
                img24.Set(x, y, value);
            });
        }
    }
}
