﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLib
{
    public class RandomEx : Random
    {
        public class GaussianValuesSource
        {
            private double? nextValue = null;
            private Random random;

            public GaussianValuesSource(Random random)
            {
                this.random = random;
            }

            public double Next(double mean, double stdDev)
            {
                double result;
                if (!nextValue.HasValue)
                {
                    double u1 = 1d - random.NextDouble();
                    double u2 = 1d - random.NextDouble();
                    double R = Math.Sqrt(-2d * Math.Log(u1));
                    double theta = 2d * Math.PI * u2;
                    double z0 = R * Math.Cos(theta);
                    double z1 = R * Math.Sin(theta);

                    nextValue = z1;
                    result = mean + z0 * stdDev;
                }
                else
                {
                    result = mean + nextValue.Value * stdDev;
                    nextValue = null;
                }
                return result;
            }
        }

        private GaussianValuesSource gaussianSource;

        public RandomEx() : this((int)(new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds())) { }

        public RandomEx(int seed) : base(seed)
        {
            gaussianSource = new GaussianValuesSource(this);
        }

        public void RandomImagePoint(Image<Pixel32> image, out int x, out int y)
        {
            x = Next(image.Width);
            y = Next(image.Height);
        }

        public bool NextBool()
        {
            return Next(2) == 0;
        }

        public byte NextByte()
        {
            return (byte)Next(0, 256);
        }

        public double NextDouble(double min, double max)
        {
            return min + NextDouble() * (max - min);
        }

        public double NextGaussian(double stdDev)
        {
            return gaussianSource.Next(0d, stdDev);
        }

        public double NextGaussian(double mean, double stdDev)
        {
            return gaussianSource.Next(mean, stdDev);
        }

        public Pixel1 NextPixel1()
        {
            return new Pixel1(NextBool());
        }

        public Pixel8 NextPixel8()
        {
            return new Pixel8(NextByte());
        }

        public Pixel32 NextPixel32()
        {
            return NextPixel32(NextByte());
        }

        public Pixel32 NextPixel32(byte alpha)
        {
            var buf = new byte[3];
            NextBytes(buf);
            return new Pixel32(alpha, buf[0], buf[1], buf[2]);
        }
    }
}
