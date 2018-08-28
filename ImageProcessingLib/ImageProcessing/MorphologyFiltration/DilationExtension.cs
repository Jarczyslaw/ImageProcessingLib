using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class DilationExtension
    {
        public static Image<Pixel1> Dilation(this Image<Pixel1> image, int maskSize = 3)
        {
            ValidationUtils.IsMaskSize(maskSize);

            var range = maskSize / 2;
            var currentIndex = maskSize * maskSize / 2;
            var originalImage = image.Copy();
            originalImage.ForEachNeighbourhood(range, (x, y, neighbourhood) =>
            {
                var newValue = false;
                for (int i = 0; i < neighbourhood.Length; i++)
                {
                    if (i != currentIndex && neighbourhood[i].Value)
                    {
                        newValue = true;
                        break;
                    }
                }
                image.Set(x, y, new Pixel1(newValue));
            });
            return image;
        }
    }
}
