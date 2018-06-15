using System;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImageProcessingLib.Tests
{
    [TestClass]
    public class ComplexNumberTests
    {
        private static ComplexNumber complexNumber1;
        private static ComplexNumber complexNumber2;
        private static Complex complex1;
        private static Complex complex2;

        private double epsilon = Math.Pow(10d, -6d);

        private bool ComplexEqual(Complex complex, ComplexNumber complexNumber)
        {
            return Math.Abs(complex.Real - complexNumber.Real) < epsilon &&
                Math.Abs(complex.Imaginary - complexNumber.Imaginary) < epsilon;
        }

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            complexNumber1 = new ComplexNumber(3d, -4d);
            complex1 = new Complex(complexNumber1.Real, complexNumber1.Imaginary);
            complexNumber2 = new ComplexNumber(-2d, 5d);
            complex2 = new Complex(complexNumber2.Real, complexNumber2.Imaginary);
        }

        [TestMethod]
        public void MagnitudeAndArgument()
        {
            Assert.IsTrue(ComplexEqual(complex1.Magnitude, complexNumber1.Magnitude));
            Assert.IsTrue(ComplexEqual(complex1.Phase, complexNumber1.Argument));
        }

        [TestMethod]
        public void ConjugateAndNegate()
        {
            Assert.IsTrue(ComplexEqual(Complex.Conjugate(complex1), ComplexNumber.Conjugate(complexNumber1)));
            Assert.IsTrue(ComplexEqual(Complex.Negate(complex1), ComplexNumber.Negate(complexNumber1)));
        }

        [TestMethod]
        public void Exp()
        {
            Assert.IsTrue(ComplexEqual(Complex.Exp(complex1), ComplexNumber.Exp(complexNumber1)));
        }

        [TestMethod]
        public void PlusOperator()
        {
            var complexResult = complex1 + complex2;
            var combplexNumberResult = complexNumber1 + complexNumber2;
            Assert.IsTrue(ComplexEqual(complexResult, combplexNumberResult));
        }

        [TestMethod]
        public void MinusOperator()
        {
            var complexResult = complex1 - complex2;
            var combplexNumberResult = complexNumber1 - complexNumber2;
            Assert.IsTrue(ComplexEqual(complexResult, combplexNumberResult));
        }

        [TestMethod]
        public void MultiplyOperator()
        {
            var complexResult = complex1 * complex2;
            var combplexNumberResult = complexNumber1 * complexNumber2;
            Assert.IsTrue(ComplexEqual(complexResult, combplexNumberResult));
        }

        [TestMethod]
        public void DivideOperator()
        {
            var complexResult = complex1 / complex2;
            var combplexNumberResult = complexNumber1 / complexNumber2;
            Assert.IsTrue(ComplexEqual(complexResult, combplexNumberResult));
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivisionByZero()
        {
            var c1 = new ComplexNumber(0d, 0d);
            var c2 = new ComplexNumber(0d, 0d);
            var result = c1 / c2;
        }
    }
}
