using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;

namespace ImageProcessingLibExamples.Examples
{
    public class GammaCorrection : ExampleBase
    {
        public override void AddExampleImages(Dictionary<string, ImageWrapper> images, Image<Pixel32> originalImage)
        {
            var gammas = new double[] { 0.25d, 0.5d, 0.75d, 1.5d, 2d };
            foreach(var gamma in gammas)
            {
                var image = originalImage.Copy();
                image.GammaCorrection(gamma);
                images.Add("GammaCorrection_Gamma" + gamma, new ImageWrapper(image));
            }
        }
    }
}
