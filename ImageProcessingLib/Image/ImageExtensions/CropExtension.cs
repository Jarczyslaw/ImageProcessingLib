using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class CropExtension
    {
        public static Image<TPixelType> Crop<TPixelType>(this Image<TPixelType> image, int x, int y, int width, int height)
            where TPixelType : struct, IPixel<TPixelType>
        {
            Validate(image, x, y, width, height);

            GeometricUtils.SectionsCommon(x, x + width, 0, image.Width, out int w0, out int w1);
            GeometricUtils.SectionsCommon(y, y + height, 0, image.Height, out int h0, out int h1);

            var newWidth = w1 - w0;
            var newHeight = h1 - h0;

            var originalImage = image.Copy();
            image.InitializeNew(newWidth, newHeight);
            image.ForEach((i, j) =>
            {
                var pixel = originalImage.Get(w0 + i, h0 + j);
                image.Set(i, j, pixel);
            });
            return image;
        }

        private static void Validate<TPixelType>(this Image<TPixelType> image, int x, int y, int width, int height)
            where TPixelType : struct, IPixel<TPixelType>
        {
            if (!GeometricUtils.SectionsCommon(x, x + width, 0, image.Width) || 
                !GeometricUtils.SectionsCommon(y, y + height, 0, image.Height))
                throw new ArgumentException("Cropped area has no common part with given image");
        }
    }
}
