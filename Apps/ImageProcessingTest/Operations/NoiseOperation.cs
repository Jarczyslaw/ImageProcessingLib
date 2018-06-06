using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;
using ImageProcessingLib.GDI;
using ImageProcessingLib.ImageProcessing;

namespace ImageProcessingTest.Operations
{
    public class NoiseOperation : OperationBase
    {
        public override void AddImages(Dictionary<string, GDImage32> images, Image<Pixel32> originalImage)
        {
            var saltAndPepperIntensities = new double[] { 0.1d, 1d, 5d, 10d };
            foreach (var intensity in saltAndPepperIntensities)
            {
                var image = originalImage.Copy();
                image.AddSaltAndPepper(intensity);
                images.Add("SaltAndPepper" + intensity, new GDImage32(image));
            }

            var noiseIntensity = 5d;

            var noiseRanges = new int[] { 10, 25, 50 };
            foreach (var range in noiseRanges)
            {
                var image = originalImage.Copy();
                image.AddUniformNoise(noiseIntensity, range);
                images.Add("UniformNoise" + range, new GDImage32(image));
            }

            var stdDevs = new double[] { 5d, 10d, 25d };
            foreach (var stdDev in stdDevs)
            {
                var image = originalImage.Copy();
                image.AddGaussianNoise(noiseIntensity, stdDev);
                images.Add("GaussianNoise" + stdDev, new GDImage32(image));
            }
        }
    }
}
