using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class RotateExtension
    {
        public static Image<TPixelType> RotateClockwise<TPixelType>(this Image<TPixelType> image)
            where TPixelType : struct, IPixel<TPixelType>
        {
            var originalImage = new Image<TPixelType>(image);
            image.InitializeNew(image.Height, image.Width);
            for (int i = 0; i < originalImage.Height; i++)
            {
                for (int j = 0; j < originalImage.Width; j++)
                {
                    var pixel = originalImage.Get(j, i);
                    image.Set(originalImage.Height - 1 - i, j, pixel);
                }
            }
            return image;
        }

        public static Image<TPixelType> RotateCounterClockwise<TPixelType>(this Image<TPixelType> image)
            where TPixelType : struct, IPixel<TPixelType>
        {
            var originalImage = new Image<TPixelType>(image);
            image.InitializeNew(image.Height, image.Width);
            for (int i = 0; i < originalImage.Height; i++)
            {
                for (int j = 0; j < originalImage.Width; j++)
                {
                    var pixel = originalImage.Get(j, i);
                    image.Set(i, originalImage.Width - 1 - j, pixel);
                }
            }
            return image;
        }

        public static Image<TPixelType> Rotate<TPixelType>(this Image<TPixelType> image, double angle, int axisX, int axisY)
            where TPixelType : struct, IPixel<TPixelType>
        {
            var originalImage = image.Copy();
            var radAngle = MathUtils.DegToRad(-angle);
            var sinAngle = Math.Sin(radAngle);
            var cosAngle = Math.Cos(radAngle);
            var blank = new TPixelType().Blank;
            image.ForEach((x, y) =>
            {
                var dx = x - axisX;
                var dy = y - axisY;
                int x1 = MathUtils.RoundToInt(cosAngle * dx - sinAngle * dy + axisX);
                int y1 = MathUtils.RoundToInt(sinAngle * dx + cosAngle * dy + axisY);

                if (image.ExceedsWidth(x1) || image.ExceedsHeight(y1))
                    image.Set(x, y, blank);
                else
                {
                    var pixel = originalImage.Get(x1, y1);
                    image.Set(x, y, pixel);
                }
            });
            return image;
        }

        public static Image<TPixelType> Rotate<TPixelType>(this Image<TPixelType> image, double angle)
            where TPixelType : struct, IPixel<TPixelType>
        {
            return image.Rotate(angle, image.Width / 2, image.Height / 2);
        }
    }
}
