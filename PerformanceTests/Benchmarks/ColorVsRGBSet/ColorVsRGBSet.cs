using BenchmarkDotNet.Attributes;
using ImageProcessingLib;
using PerformanceTests.BenchmarkRunner;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceTests.Benchmarks
{
    [BenchmarkSet]
    public class ColorVsRGBSet
    {
        private int size = 1000000;
        private int startColor = -10185016; // #FF6496C8

        private Color[] colorArray;
        private RGBSet[] rgbSetArray;

        [Benchmark]
        [BenchmarkCategory("Initialization")]
        public Color[] ColorInitialization()
        {
            var arr = new Color[size];
            for (int i = 0; i < size; i++)
                arr[i] = Color.FromArgb(startColor);
            return arr;
        }

        [Benchmark]
        [BenchmarkCategory("Initialization")]
        public RGBSet[] RGBSetInitialization()
        {
            var arr = new RGBSet[size];
            for (int i = 0; i < size; i++)
                arr[i] = new RGBSet(startColor);
            return arr;
        }

        [GlobalSetup(Target = nameof(ColorIterating))]
        public void ColorIteratingSetup()
        {
            colorArray = ColorInitialization();
        }

        [GlobalSetup(Target = nameof(RGBSetIterating))]
        public void RGBSetIteratingSetup()
        {
            rgbSetArray = RGBSetInitialization();
        }

        [Benchmark]
        [BenchmarkCategory("Iterating")]
        public void ColorIterating()
        {
            for (int i = 0;i < size;i++)
            {
                var c = colorArray[i];
                var newC = Color.FromArgb(c.R, c.G, c.B);
                colorArray[i] = newC;
            }
        }

        [Benchmark]
        [BenchmarkCategory("Iterating")]
        public void RGBSetIterating()
        {
            for (int i = 0; i < size; i++)
            {
                var rgb = rgbSetArray[i];
                var newRgb = new RGBSet(rgb.R, rgb.G, rgb.B);
                rgbSetArray[i] = newRgb;
            }
        }
    }
}
