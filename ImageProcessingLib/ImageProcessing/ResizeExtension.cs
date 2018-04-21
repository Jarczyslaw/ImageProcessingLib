using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib.ImageProcessing
{
    public static class ResizeExtension
    {
        public static Image<Pixel32> Resize(this Image<Pixel32> image, ResizeMethod method = ResizeMethod.NearestNeighbour)
        {
            switch(method)
            {
                case ResizeMethod.BilinearInterpolation:
                    break;
                case ResizeMethod.NearestNeighbour:
                    break;
            }
            return null;
        }

        private static Image<Pixel32> NearestNeighbour(Image<Pixel32> image)
        {
            return null;
        }

        private static Image<Pixel32> BilinearInterpolation(Image<Pixel32> image)
        {
            return null;
        }
    }
}
