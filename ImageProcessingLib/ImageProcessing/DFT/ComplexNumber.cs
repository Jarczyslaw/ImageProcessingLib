using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public struct ComplexNumber
    {
        public double Real { get; private set; }
        public double Imaginary { get; private set; }

        public double Magnitude
        {
            get
            {
                return Math.Sqrt(Real * Real + Imaginary * Imaginary);
            }
        }

        public double Argument
        {
            get
            {
                if (Real == 0d)
                    return 0d;
                return Math.Atan(Imaginary / Real);
            }
        }

        public ComplexNumber(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public static ComplexNumber Zero
        {
            get { return new ComplexNumber(0d, 0d); }
        }

        public static ComplexNumber One
        {
            get { return new ComplexNumber(1d, 0d); }
        }

        public static ComplexNumber ImaginaryOne
        {
            get { return new ComplexNumber(0d, 1d); }
        }

        public static ComplexNumber Exp(ComplexNumber complex)
        {
            var eReal = Math.Exp(complex.Real);
            var real = eReal * Math.Cos(complex.Imaginary);
            var imaginary = eReal * Math.Sin(complex.Imaginary);
            return new ComplexNumber(real, imaginary);
        }

        public static ComplexNumber Conjugate(ComplexNumber complex)
        {
            return new ComplexNumber(complex.Real, -complex.Imaginary);
        }

        public static ComplexNumber Negate(ComplexNumber complex)
        {
            return new ComplexNumber(-complex.Real, -complex.Imaginary);
        }

        public static ComplexNumber operator+(ComplexNumber left, ComplexNumber right)
        {
            return new ComplexNumber(left.Real + right.Real, left.Imaginary + right.Imaginary);
        }

        public static ComplexNumber operator-(ComplexNumber left, ComplexNumber right)
        {
            return new ComplexNumber(left.Real - right.Real, left.Imaginary - right.Imaginary);
        }

        public static ComplexNumber operator *(ComplexNumber left, ComplexNumber right)
        {
            var real = left.Real * right.Real - left.Imaginary * right.Imaginary;
            var imaginary = left.Imaginary * right.Real + left.Real * right.Imaginary;
            return new ComplexNumber(real, imaginary);
        }

        public static ComplexNumber operator /(ComplexNumber left, ComplexNumber right)
        {
            double q = right.Real * right.Real + right.Imaginary * right.Imaginary;
            if (q == 0d)
                throw new DivideByZeroException();
            double real = (left.Real * right.Real + left.Imaginary * right.Imaginary) / q;
            double imaginary = (left.Imaginary * right.Real - left.Real * right.Imaginary) / q;
            return new ComplexNumber(real, imaginary);
        }

        public static ComplexNumber operator -(ComplexNumber complex)
        {
            return new ComplexNumber(-complex.Real, -complex.Imaginary);
        }

        public static implicit operator ComplexNumber(double value)
        {
            return new ComplexNumber(value, 0d);
        }

        public override string ToString()
        {
            return string.Format("Re: {0}, Im: {1}", Real, Imaginary);
        }
    }
}
