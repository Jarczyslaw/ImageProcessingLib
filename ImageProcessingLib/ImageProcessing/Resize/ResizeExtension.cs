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
            for (int i = 0; i < image.Width;i++)
            {
                for (int j = 0;j < image.Height;j++)
                {
                    var x = i;
                    var y = j;

                    var xrw = x * rw;
                    var yrh = y * rh;

                    var m = MathUtils.RoundToInt(xrw);
                    var n = MathUtils.RoundToInt(yrh);

                    var x0 = imageCopy.ClampWidth(m);
                    var y0 = imageCopy.ClampHeight(n);
                    var x1 = imageCopy.ClampWidth(x0 + 1);
                    var y1 = imageCopy.ClampHeight(y0 + 1);

                    var a = xrw % m;
                    if (double.IsNaN(a))
                        a = 0;
                    var b = yrh % n;
                    if (double.IsNaN(b))
                        b = 0;

                    var p00 = imageCopy.Get(x0, y0);
                    var p01 = imageCopy.Get(x0, y1);
                    var p10 = imageCopy.Get(x1, y0);
                    var p11 = imageCopy.Get(x1, y1);

                    var red = Interpolate(p00.R, p01.R, p10.R, p11.R, a, b);
                    var green = Interpolate(p00.G, p01.G, p10.G, p11.G, a, b);
                    var blue = Interpolate(p00.B, p01.B, p10.B, p11.B, a, b);
                    image.Set(x, y, new Pixel32(p00.A, red, green, blue));
                }
            }
            image.InvokeResize();
        }

        private static byte Interpolate(byte c00, byte c01, byte c10, byte c11,
            double a, double b)
        {
            var h1 = (1 - a) * c00 + a * c10;
            var h2 = (1 - a) * c01 + a * c11;
            var h = (1 - b) * h1 + b * h2;
            return MathUtils.RoundToByte(h);
        }
    }
}
