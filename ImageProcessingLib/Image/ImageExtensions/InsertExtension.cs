﻿using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class InsertExtension
    {
        public static Image<TPixelType> Insert<TPixelType>(this Image<TPixelType> image, Image<TPixelType> imageToInsert, int x, int y)
        {
            Validate(image, imageToInsert, x, y);

            GeometricUtils.SectionsCommon(x, x + imageToInsert.Width, 0, image.Width, out int w0, out int w1);
            GeometricUtils.SectionsCommon(y, y + imageToInsert.Height, 0, image.Height, out int h0, out int h1);

            int commonWidth = w1 - w0;
            int commonHeight = h1 - h0;

            image.ForBlock(w0, h0, commonWidth, commonHeight, (i, j) =>
            {
                var pixel = imageToInsert.Get(i - x, j - y);
                image.Set(i, j, pixel);
            });
            return image;
        }

        private static void Validate<TPixelType>(Image<TPixelType> image,Image<TPixelType> imageToInsert, int x, int y)
        {
            if (!GeometricUtils.SectionsCommon(x, x + imageToInsert.Width, 0, image.Width) || 
                !GeometricUtils.SectionsCommon(y, y + imageToInsert.Height, 0, image.Height))
                throw new ArgumentException("Inserted image has no common part with given image");
        }
    }
}
