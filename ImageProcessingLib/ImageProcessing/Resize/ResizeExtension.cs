using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib.ImageProcessing
{
    public static partial class ResizeExtension
    {
        public static Image<Pixel32> Resize(this Image<Pixel32> image, int width, int height, ResizeMethod method)
        {
            switch(method)
            {
                case ResizeMethod.BilinearInterpolation:
                    BilinearInterpolation(image, width, height);
                    break;
                case ResizeMethod.NearestNeighbour:
                    image.Resize(width, height);
                    break;
            }
            return image;
        }

        private static void BilinearInterpolation(Image<Pixel32> image, int width, int height)
        {
            // TODO refactor
            var imageCopy = new Image<Pixel32>(image);
            image.InitializeNew(width, height);
            var rw = (double)imageCopy.Width / image.Width;
            var rh = (double)imageCopy.Height / image.Height;
            image.ForEach((x, y) =>
            {
                var x0 = MathUtils.RoundToInt(x * rw);
                x0 = MathUtils.Clamp(x0, 0, imageCopy.Width - 1);
                var y0 = MathUtils.RoundToInt(y * rh);
                y0 = MathUtils.Clamp(y0, 0, imageCopy.Height - 1);
                var x1 = MathUtils.Clamp(x0 + 1, 0, imageCopy.Width - 1);
                var y1 = MathUtils.Clamp(y0 + 1, 0, imageCopy.Height - 1);

                var a = (x * rw) % x0;
                var b = (y * rh) % y0;

                var pixels = new Pixel32[2, 2];
                pixels[0, 0] = imageCopy.Get(x0, y0);
                pixels[0, 1] = imageCopy.Get(x0, y1);
                pixels[1, 0] = imageCopy.Get(x1, y0);
                pixels[1, 1] = imageCopy.Get(x1, y1);

                var pixel = Interpolate(pixels, a, b);
                image.Set(x, y, pixel);
            });
            image.InvokeResize();
        }

        private static Pixel32 Interpolate(Pixel32[,] pixels, double a, double b)
        {
            var h1 = (1 - a) * pixels[0, 0].R + a * pixels[1, 0].R;
            var h2 = (1 - a) * pixels[0, 1].R + a * pixels[1, 1].R;
            var h = (1 - b) * h1 + b * h2;
            var red = MathUtils.RoundToByte(h);

            h1 = (1 - a) * pixels[0, 0].G + a * pixels[1, 0].G;
            h2 = (1 - a) * pixels[0, 1].G + a * pixels[1, 1].G;
            h = (1 - b) * h1 + b * h2;
            var green = MathUtils.RoundToByte(h);

            h1 = (1 - a) * pixels[0, 0].B + a * pixels[1, 0].B;
            h2 = (1 - a) * pixels[0, 1].B + a * pixels[1, 1].B;
            h = (1 - b) * h1 + b * h2;
            var blue = MathUtils.RoundToByte(h);

            return new Pixel32(pixels[0, 0].A, red, green, blue);
        }
    }
}
