﻿using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public static partial class ResizeExtension
    {
        public delegate TPixelType PixelInterpolationOperator<TPixelType>(TPixelType p00, TPixelType p01, TPixelType p10, TPixelType p11, double a, double b);

        public static Image<Pixel8> Resize(this Image<Pixel8> image, int width, int height, ResizeMethod method)
        {
            Pixel8 pixelInterpolationOperator(Pixel8 p00, Pixel8 p01, Pixel8 p10, Pixel8 p11, double a, double b)
            {
                var val = Interpolate(p00.Value, p01.Value, p10.Value, p11.Value, a, b);
                return new Pixel8(val);
            };
            return image.Resize(pixelInterpolationOperator, width, height, method);
        }

        public static Image<Pixel32> Resize(this Image<Pixel32> image, int width, int height, ResizeMethod method)
        {
            Pixel32 pixelInterpolationOperator(Pixel32 p00, Pixel32 p01, Pixel32 p10, Pixel32 p11, double a, double b)
            {
                var red = Interpolate(p00.R, p01.R, p10.R, p11.R, a, b);
                var green = Interpolate(p00.G, p01.G, p10.G, p11.G, a, b);
                var blue = Interpolate(p00.B, p01.B, p10.B, p11.B, a, b);
                return new Pixel32(p00.A, red, green, blue);
            };
            return image.Resize(pixelInterpolationOperator, width, height, method);
        }

        private static Image<TPixelType> Resize<TPixelType>(this Image<TPixelType> image, PixelInterpolationOperator<TPixelType> pixelOperator, int width, int height, ResizeMethod method)
        {
            switch (method)
            {
                case ResizeMethod.BilinearInterpolation:
                    BilinearInterpolation(image, pixelOperator, width, height);
                    break;
                case ResizeMethod.NearestNeighbour:
                    image.Resize(width, height);
                    break;
            }
            return image;
        }

        private static void BilinearInterpolation<TPixelType>(Image<TPixelType> image, PixelInterpolationOperator<TPixelType> pixelOperator, int width, int height)
        {
            var originalImage = image.Copy();
            image.Initialize(width, height);
            var rw = (double)originalImage.Width / image.Width;
            var rh = (double)originalImage.Height / image.Height;
            image.ForEach((x, y) =>
            {
                var xrw = x * rw;
                var yrh = y * rh;

                var m = originalImage.ClampWidth((int)xrw);
                var n = originalImage.ClampWidth((int)yrh);

                var x0 = originalImage.ClampWidth(m);
                var y0 = originalImage.ClampHeight(n);
                var x1 = originalImage.ClampWidth(x0 + 1);
                var y1 = originalImage.ClampHeight(y0 + 1);

                var a = xrw % m;
                if (double.IsNaN(a))
                    a = 0;
                var b = yrh % n;
                if (double.IsNaN(b))
                    b = 0;

                var p00 = originalImage.Get(x0, y0);
                var p01 = originalImage.Get(x0, y1);
                var p10 = originalImage.Get(x1, y0);
                var p11 = originalImage.Get(x1, y1);

                var newPixel = pixelOperator(p00, p01, p10, p11, a, b);
                image.Set(x, y, newPixel);
            });
        }

        private static byte Interpolate(byte c00, byte c01, byte c10, byte c11,
            double a, double b)
        {
            var h1 = (1d - a) * c00 + a * c10;
            var h2 = (1d - a) * c01 + a * c11;
            var h = (1d - b) * h1 + b * h2;
            return MathUtils.RoundToByte(h);
        }
    }
}
