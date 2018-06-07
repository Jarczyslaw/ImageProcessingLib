using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Jobs;
using BenchmarkDotNet.Engines;
using Benchmarking.Benchmarks;
using ImageProcessingLib;
using ImageProcessingLib.Old;
using Benchmarking.BenchmarkLauncher;
using System.Drawing;

namespace Benchmarking.Benchmarks
{
    [BenchmarkSet("VsOld_GrayscaleImages")]
    public class GrayscaleImages : VsOldImplementationBase
    {
        [Benchmark]
        [BenchmarkCategory(createNewCategory)]
        public void CreateNew()
        {
            var image8 = new Image<Pixel8>(width, height);
        }

        [Benchmark]
        [BenchmarkCategory(createNewCategory)]
        public void Old_CreateNew()
        {
            var img8 = new Img8(width, height);
        }

        [Benchmark]
        [BenchmarkCategory(valueChangingCategory)]
        public void ValueChanging()
        {
            var image8 = new Image<Pixel8>(width, height);
            image8.ForEach((x, y) =>
            {
                var pixel = image8.Get(x, y);
                image8.Set(x, y, new Pixel8(pixel));
            });
        }

        [Benchmark]
        [BenchmarkCategory(valueChangingCategory)]
        public void Old_ValueChanging()
        {
            var img8 = new Img8(width, height);
            img8.ForEach((x, y) =>
            {
                var value = img8.Get(x, y);
                img8.Set(x, y, value);
            });
        }
    }
}
