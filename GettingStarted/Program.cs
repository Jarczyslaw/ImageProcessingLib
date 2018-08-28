using ImageProcessingLib.Converter.WF;
using ImageProcessingLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingStarted
{
    class Program
    {
        static void Main(string[] args)
        {
            // create bitmap from file and convert it to Image<Pixel32>
            var inputImagePath = @"inputImage.bmp";
            var bitmap = new Bitmap(inputImagePath);
            var image = ImageProcessingLibConverter.CreateImageFromBitmap(bitmap);

            // resize it to desired size
            image.Resize(512, 512, ResizeMethod.BilinearInterpolation);

            // rotate it and flip horizontally
            image.RotationClockwise()
                .FlipHorizontal();

            // get image histogram
            var histogram = image.Histogram();

            // calculate discrete Fourier transform
            var dft = image.DFT();

            // create binary image 
            var binaryImage = image.CopyAs(p => p.ToPixel1());

            // perform closing and skeletonization operations
            binaryImage.Closing(3).
                Skeletonization();

            // return to Image<Pixel32>, create Bitmap from it and save it
            var resultImage = binaryImage.CopyAs(p => p.ToPixel32());
            var resultBitmap = ImageProcessingLibConverter.CreateBitmapFromImage(resultImage);
            var outputImagePath = @"outputImage.bmp";
            resultBitmap.Save(outputImagePath);
        }
    }
}
