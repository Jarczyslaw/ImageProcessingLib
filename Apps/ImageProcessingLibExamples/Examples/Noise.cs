using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;
using ImageProcessingLib.Wrappers.WF;

namespace ImageProcessingLibExamples.Examples
{
    public class Noise : ExampleBase
    {
        public override void AddExampleImages(Dictionary<string, ImageWrapper> images, Image<Pixel32> originalImage)
        {
            var saltAndPepperIntensities = new double[] { 0.1d, 1d, 5d, 10d };
            foreach (var intensity in saltAndPepperIntensities)
            {
                var image = originalImage.Copy();
                image.AddSaltAndPepper(intensity);
                images.Add("Noise_SaltAndPepper_Intensity" + intensity, new ImageWrapper(image));
            }

            var noiseIntensity = 5d;

            var noiseRanges = new int[] { 10, 25, 50 };
            foreach (var range in noiseRanges)
            {
                var image = originalImage.Copy();
                image.AddUniformNoise(noiseIntensity, range);
                images.Add("Noise_UniformNoise_Range" + range, new ImageWrapper(image));
            }

            var stdDevs = new double[] { 5d, 10d, 25d };
            foreach (var stdDev in stdDevs)
            {
                var image = originalImage.Copy();
                image.AddGaussianNoise(noiseIntensity, stdDev);
                images.Add("Noise_GaussianNoise_StdDev" + stdDev, new ImageWrapper(image));
            }
        }
    }
}
