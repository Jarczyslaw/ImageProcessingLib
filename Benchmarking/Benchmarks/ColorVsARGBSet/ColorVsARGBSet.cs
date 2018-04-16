using BenchmarkDotNet.Attributes;
using ImageProcessingLib;
using PerformanceTests.BenchmarkLauncher;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceTests.Benchmarks
{
    /// <summary>
    /// Performance difference between default Color struct and custom RGBSet
    /// </summary>
    [BenchmarkSet("ColorVsARGBSet")]
    public class ColorVsARGBSet
    {
        private int size = 1000000;
        private int startColor = -10185016; // #FF6496C8

        private Color[] colorArray;
        private Pixel32[] rgbSetArray;

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
        public Pixel32[] ARGBSetInitialization()
        {
            var arr = new Pixel32[size];
            for (int i = 0; i < size; i++)
                arr[i] = new Pixel32(startColor);
            return arr;
        }

        [GlobalSetup(Target = nameof(ColorIterating))]
        public void ColorIteratingSetup()
        {
            colorArray = ColorInitialization();
        }

        [GlobalSetup(Target = nameof(ARGBSetIteratingSetup))]
        public void ARGBSetIteratingSetup()
        {
            rgbSetArray = ARGBSetInitialization();
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
        public void ARGBSetIterating()
        {
            for (int i = 0; i < size; i++)
            {
                var rgb = rgbSetArray[i];
                var newRgb = new Pixel32(rgb.R, rgb.G, rgb.B);
                rgbSetArray[i] = newRgb;
            }
        }
    }
}
