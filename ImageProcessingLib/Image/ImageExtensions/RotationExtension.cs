using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static class RotationExtension
    {
        public static Image<TPixelType> RotationClockwise<TPixelType>(this Image<TPixelType> image)
            where TPixelType : struct, IPixel<TPixelType>
        {
            var originalImage = image.Copy();
            image.InitializeNew(image.Height, image.Width);
            image.ForEach((x, y) =>
            {
                var pixel = originalImage.Get(y, image.Width - 1 - x);
                image.Set(x, y, pixel);
            });
            image.InvokeResize();
            return image;
        }

        public static Image<TPixelType> RotationCounterClockwise<TPixelType>(this Image<TPixelType> image)
            where TPixelType : struct, IPixel<TPixelType>
        {
            var originalImage = image.Copy();
            image.InitializeNew(image.Height, image.Width);
            image.ForEach((x, y) =>
            {
                var pixel = originalImage.Get(image.Height - 1 - y, x);
                image.Set(x, y, pixel);
            });
            image.InvokeResize();
            return image;
        }

        public static Image<TPixelType> RotationWithSizePreserving<TPixelType>(this Image<TPixelType> image, double angle)
            where TPixelType : struct, IPixel<TPixelType>
        {
            GetAngles(angle, out double sAlpha, out double cAlpha);
            var originalImage = image.Copy();
            image.GetCenter(out int axisX, out int axisY);
            var blank = new TPixelType().Blank;
            image.ForEach((x, y) =>
            {
                var dx = x - axisX;
                var dy = y - axisY;
                int x1 = MathUtils.RoundToInt(cAlpha * dx - sAlpha * dy + axisX);
                int y1 = MathUtils.RoundToInt(sAlpha * dx + cAlpha * dy + axisY);

                TransformPixel(image, x, y, originalImage, x1, y1, blank);
            });
            return image;
        }

        public static Image<TPixelType> Rotation<TPixelType>(this Image<TPixelType> image, double angle)
            where TPixelType : struct, IPixel<TPixelType>
        {
            GetAngles(angle, out double sAlpha, out double cAlpha);
            var sAlphaAbs = Math.Abs(sAlpha);
            var cAlphaAbs = Math.Abs(cAlpha);
            var newWidth = (int)Math.Ceiling(image.Width * cAlphaAbs + image.Height * sAlphaAbs);
            var newHeight = (int)Math.Ceiling(image.Width * sAlphaAbs + image.Height * cAlphaAbs);

            var originalImage = image.Copy();
            image.InitializeNew(newWidth, newHeight);
            originalImage.GetCenter(out int originalAxisX, out int originalAxisY);
            image.GetCenter(out int axisX, out int axisY);

            var blank = new TPixelType().Blank;
            image.ForEach((x, y) =>
            {
                var dx = x - axisX;
                var dy = y - axisY;
                int x1 = MathUtils.RoundToInt(cAlpha * dx - sAlpha * dy + originalAxisX);
                int y1 = MathUtils.RoundToInt(sAlpha * dx + cAlpha * dy + originalAxisY);

                TransformPixel(image, x, y, originalImage, x1, y1, blank);
            });
            image.InvokeResize();
            return image;
        }

        private static void TransformPixel<TPixelType>(Image<TPixelType> image, int x, int y, Image<TPixelType> originalImage, int x1, int y1, TPixelType blank)
            where TPixelType : struct, IPixel<TPixelType>
        {
            if (originalImage.ExceedsWidth(x1) || originalImage.ExceedsHeight(y1))
                image.Set(x, y, blank);
            else
            {
                var pixel = originalImage.Get(x1, y1);
                image.Set(x, y, pixel);
            }
        }

        private static void GetAngles(double angle, out double sinAngle, out double cosAngle)
        {
            var alpha = MathUtils.DegToRad(-angle);
            sinAngle = Math.Sin(alpha);
            cosAngle = Math.Cos(alpha);
        }
    }
}
