﻿using BenchmarkDotNet.Attributes;
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
    /// Comparison between accessing byte and int array
    /// </summary>
    [BenchmarkSet("ByteArrayVsIntArray")]
    public class ByteArrayVsIntArray
    {
        private int size = 1000000;
        private int[] ints;
        private byte[] bytes;

        private int intValue = 0;
        private byte r = 0;
        private byte g = 0;
        private byte b = 0;

        [GlobalSetup]
        public void Setup()
        {
            ints = new int[size];
            bytes = new byte[3 * size];
        }

        [Benchmark]
        public void IntsSet()
        {
            for (int i = 0; i < size; i++)
                ints[i] = intValue;
        }

        [Benchmark]
        public void BytesSet()
        {
            for (int i = 0;i < size; i++)
            {
                var index = i * 3;
                bytes[index + 2] = r;
                bytes[index + 1] = g;
                bytes[index] = b;
            }
        }
    }
}
