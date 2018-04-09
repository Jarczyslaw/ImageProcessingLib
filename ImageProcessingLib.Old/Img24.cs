using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLib.Old
{
    public class Img24 : BaseImg
    {
        private readonly int pixelLength = 3;

        public Img24(int width, int height)
        {
            rows = height;
            cols = width;
            var length = pixelLength * width * height;
            data = new byte[length];
            for (int i = 0; i < length; i++)
                data[i] = 255;
        }

        public Img24(string filePath)
        {
            using (var bmp = new Bitmap(filePath))
            {
                Init(bmp);
            }
        }

        public Img24(Bitmap bmp)
        {
            Init(bmp);
        }

        public Img24(Img24 img)
        {
            rows = img.rows;
            cols = img.cols;
            data = img.CopyData();
        }

        public Img24(Img8 img)
        {
            rows = img.GetRows();
            cols = img.GetCols();
            data = new byte[3 * cols * rows];
            DataGrayscaleToRgb(img.GetData(), data);
        }

        private void Init(Bitmap bmp)
        {
            rows = bmp.Height;
            cols = bmp.Width;

            data = ImgMashal.GetDataFromBmp(bmp);
        }

        public override Bitmap ToBitmap()
        {
            var bmp = new Bitmap(cols, rows, PixelFormat.Format24bppRgb);
            ImgMashal.SetDataToBmp(bmp, data);

            return bmp;
        }

        public bool IsGrayscale()
        {
            int len = GetSize();
            for (int i = 0; i < len; i += pixelLength)
            {
                if (data[i] != data[i + 1] || data[i + 1] != data[i + 2])
                    return false;
            }
            return true;
        }

        public bool IsBlackAndWhite()
        {
            int len = GetSize();
            for (int i = 0; i < len; i += pixelLength)
            {
                if ((data[i] != 0 && data[i] != 255) ||
                    (data[i + 1] != 0 && data[i + 1] != 255) ||
                    (data[i + 2] != 0 && data[i + 2] != 255))
                    return false;
            }
            return true;
        }

        public bool EqualsTo(Img24 img)
        {
            if (cols != img.cols || rows != img.rows)
                return false;

            int len = rows * cols * pixelLength;
            for (int i = 0; i < len; i += pixelLength)
            {
                if (data[i] != img.data[i] || data[i + 1] != img.data[i + 1] || data[i + 2] != img.data[i + 2])
                    return false;
            }
            return true;
        }

        public Pixel Get(int x, int y)
        {
            int index = pixelLength * (cols * x + y);
            Pixel pixel = new Pixel(data[index + 2], data[index + 1], data[index]);
            return pixel;
        }

        public byte GetR(int x, int y)
        {
            int index = pixelLength * (cols * x + y);
            return data[index + 2];
        }

        public byte GetG(int x, int y)
        {
            int index = pixelLength * (cols * x + y);
            return data[index + 1];
        }

        public byte GetB(int x, int y)
        {
            int index = pixelLength * (cols * x + y);
            return data[index];
        }

        public void Set(int x, int y, Pixel pixel)
        {
            int index = pixelLength * (cols * x + y);
            data[index + 2] = pixel.r;
            data[index + 1] = pixel.g;
            data[index] = pixel.b;
        }

        public void Set(int x, int y, byte r, byte g, byte b)
        {
            int index = pixelLength * (cols * x + y);
            data[index + 2] = r;
            data[index + 1] = g;
            data[index] = b;
        }

        public void SetGray(int x, int y, byte value)
        {
            int index = pixelLength * (cols * x + y);
            data[index + 2] = value;
            data[index + 1] = value;
            data[index] = value;
        }

        public void SetR(int x, int y, byte r)
        {
            int index = pixelLength * (cols * x + y);
            data[index + 2] = r;
        }

        public void SetG(int x, int y, byte g)
        {
            int index = pixelLength * (cols * x + y);
            data[index + 1] = g;
        }

        public void SetB(int x, int y, byte b)
        {
            int index = pixelLength * (cols * x + y);
            data[index] = b;
        }
    }
}
