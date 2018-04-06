using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Jobs;
using BenchmarkDotNet.Engines;
using PerformanceTests.BenchmarkRunner;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceTests.Benchmarks
{ 
    /// <summary>
    /// Comparison between pixel accessing between classic Bitmap Set/GetPixel and DirectBitmap's wrapper
    /// </summary>
    [BenchmarkSet]
    [SimpleJob(RunStrategy.Throughput, launchCount: 0, warmupCount: 1, targetCount: 3)]
    public class BitmapAccess
    {
        private int width = 600;
        private int height = 800;
        private Bitmap bmp;
        private DirectBitmap dbmp;

        [GlobalSetup]
        public void Setup()
        {
            bmp = new Bitmap(width, height);
            dbmp = new DirectBitmap(width, height);
        }

        [Benchmark]
        public void BitmapInClassicWay()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    var color = bmp.GetPixel(i, j);
                    bmp.SetPixel(i, j, color);
                }
            }
        }

        [Benchmark]
        public void WithDirectBitmap()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    var color = dbmp.GetPixel(i, j);
                    dbmp.SetPixel(i, j, color);
                }
            }
        }
    }
}
