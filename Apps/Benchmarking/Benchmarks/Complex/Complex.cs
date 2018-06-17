using BenchmarkDotNet.Attributes;
using Benchmarking.BenchmarkLauncher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmarking.Benchmarks
{
    [BenchmarkSet("Complex")]
    public class Complex
    {
        private System.Numerics.Complex complex;
        private ImageProcessingLib.ComplexNumber complexNumber;

        [GlobalSetup]
        public void Setup()
        {
            complex = new System.Numerics.Complex(1d, 2d);
            complexNumber = new ImageProcessingLib.ComplexNumber(complex.Real, complex.Imaginary);
        }

        [Benchmark]
        [BenchmarkCategory("Exponential")]
        public void ComplexExp()
        {
            System.Numerics.Complex.Exp(complex);
        }

        [Benchmark]
        [BenchmarkCategory("Exponential")]
        public void ComplexNumberExp()
        {
            ImageProcessingLib.ComplexNumber.Exp(complexNumber);
        }

        [Benchmark]
        [BenchmarkCategory("Multiplication")]
        public void ComplexMul()
        {
            var x = complex * complex;
        }

        [Benchmark]
        [BenchmarkCategory("Multiplication")]
        public void ComplexNumberMul()
        {
            var x = complexNumber * complexNumber;
        }

        [Benchmark]
        [BenchmarkCategory("Division")]
        public void ComplexDiv()
        {
            var x = complex / complex;
        }

        [Benchmark]
        [BenchmarkCategory("Division")]
        public void ComplexNumberDiv()
        {
            var x = complexNumber / complexNumber;
        }
    }
}
