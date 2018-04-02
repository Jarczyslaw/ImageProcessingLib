using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Jobs;
using BenchmarkDotNet.Engines;
using PerformanceTests.BenchmarksLauncher;
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
    [AvailableBenchmark]
    [SimpleJob(RunStrategy.Throughput, launchCount: 0, warmupCount: 1, targetCount: 3)]
    public class BitmapAccess
    {
        public class DirectBitmap : IDisposable
        {
            public Bitmap Bitmap { get; private set; }
            public Int32[] Bits { get; private set; }
            public bool Disposed { get; private set; }
            public int Height { get; private set; }
            public int Width { get; private set; }

            protected GCHandle BitsHandle { get; private set; }

            public DirectBitmap(int width, int height)
            {
                Width = width;
                Height = height;
                Bits = new Int32[width * height];
                BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
                Bitmap = new Bitmap(width, height, width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
            }

            public void SetPixel(int x, int y, Color colour)
            {
                int index = x + (y * Width);
                int col = colour.ToArgb();

                Bits[index] = col;
            }

            public Color GetPixel(int x, int y)
            {
                int index = x + (y * Width);
                int col = Bits[index];
                Color result = Color.FromArgb(col);

                return result;
            }

            public void Dispose()
            {
                if (Disposed) return;
                Disposed = true;
                Bitmap.Dispose();
                BitsHandle.Free();
            }
        }

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
