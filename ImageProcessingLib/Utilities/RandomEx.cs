using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLib.Utilities
{
    public class RandomEx : Random
    {
        public RandomEx() :
            base((int)(new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds()))
        { }

        public void RandomImagePoint(ImageBase image, out int x, out int y)
        {
            x = Next(image.Width);
            y = Next(image.Height);
        }

        public bool NextBool()
        {
            return Next(2) == 0;
        }

        public double NextDouble(double min, double max)
        {
            return min + NextDouble() * (max - min);
        }

        public double NextGaussian(double stdDev)
        {
            return NextGaussian(0d, stdDev);
        }

        public double NextGaussian(double mean, double stdDev)
        {
            double u1 = 1d - NextDouble();
            double u2 = 1d - NextDouble();
            double R = Math.Sqrt(-2d * Math.Log(u1));
            double theta = 2d * Math.PI * u2;
            double z0 = R * Math.Cos(theta);
            return mean + z0 * stdDev;
        }
    }
}
