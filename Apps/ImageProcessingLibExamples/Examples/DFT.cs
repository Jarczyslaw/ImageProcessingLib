using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingLib;
using ImageProcessingLib.Wrappers.WF;

namespace ImageProcessingLibExamples.Examples
{
    public class DFT : ExampleBase
    {
        public override void AddExampleImages(Dictionary<string, ImageWrapper> images, Image<Pixel32> originalImage)
        {
            var dft = originalImage.DFT().CopyAs(p => p.ToPixel32());
            images.Add("DFT", new ImageWrapper(dft));
            var sdft = originalImage.SDFT().CopyAs(p => p.ToPixel32());
            images.Add("SDFT", new ImageWrapper(sdft));
        }
    }
}
