﻿using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Jobs;
using BenchmarkDotNet.Engines;
using ImageProcessingLib;
using ImageProcessingLib.Old;
using PerformanceTests.BenchmarkLauncher;
using System.Drawing;

namespace PerformanceTests.Benchmarks
{
    [BenchmarkSet("VsOld_GrayscaleImagesCreation")]
    public class GrayscaleImagesCreation
    {
        private const string createNewCategory = "CreateNew";
        private const string createFromBitmapCategory = "CreateFromBitmap";
        private const string createFromRGBImageCategory = "CreateFromRGBImageCategory";
        private const string valueChanging = "ValueChanging";

        private int width = 1000;
        private int height = 2000;

        private Bitmap bmp;
        private Img24 img24;
        private Image24 image24;

        [GlobalSetup]
        public void Setup()
        {
            bmp = new Bitmap(width, height);
            img24 = new Img24(width, height);
            image24 = new Image24(width, height);
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            image24.Dispose();
        }

        [Benchmark]
        [BenchmarkCategory(createNewCategory)]
        public void CreateNew()
        {
            var img8 = new Img8(width, height);
        }

        [Benchmark]
        [BenchmarkCategory(createNewCategory)]
        public void CreateNewWithOld()
        {
            var image8 = new Image8(width, height);
            image8.Dispose();
        }

        [Benchmark]
        [BenchmarkCategory(createFromBitmapCategory)]
        public void CreateFromBitmap()
        {
            var img8 = new Img8(bmp);
        }

        [Benchmark]
        [BenchmarkCategory(createFromBitmapCategory)]
        public void CreateFromBitmapWithOld()
        {
            var image8 = new Image8(bmp);
            image8.Dispose();
        }

        [Benchmark]
        [BenchmarkCategory(createFromRGBImageCategory)]
        public void CreateFromRGB()
        {
            var img8 = new Img8(img24);
        }

        [Benchmark]
        [BenchmarkCategory(createFromRGBImageCategory)]
        public void CreateFromRGBWithOld()
        {
            var image8 = new Image8(image24);
            image8.Dispose();
        }

        [Benchmark]
        [BenchmarkCategory(valueChanging)]
        public void ValueChanging()
        {
            var img8 = new Img8(width, height);
            img8.ForEach((x, y) =>
            {
                var value = img8.Get(x, y);
                value = 255;
                img8.Set(x, y, value);
            });
        }

        [Benchmark]
        [BenchmarkCategory(valueChanging)]
        public void ValueChangingWithOld()
        {
            var image8 = new Image8(image24);
            image8.ForEach((x, y) =>
            {
                var value = image8.Get(x, y);
                value = 255;
                image8.Set(x, y, value);
            });
            image8.Dispose();
        }
    }
}
