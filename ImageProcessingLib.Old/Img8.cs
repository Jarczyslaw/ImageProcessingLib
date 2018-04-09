using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLib.Old
{
    public class Img8 : BaseImg
    {
        public Img8(int width, int height)
        {
            rows = height;
            cols = width;
            var length = GetSize();
            data = new byte[length];
            for (int i = 0; i < length; i++)
                data[i] = 255;
        }

        public Img8(Img8 img)
        {
            cols = img.cols;
            rows = img.rows;
            data = img.CopyData();
        }

        public Img8(Img24 img)
        {
            cols = img.GetCols();
            rows = img.GetRows();
            data = new byte[cols * rows];
            DataRgbToGrayscale(img.GetData(), data);
        }

        public Img8(string filePath)
        {
            using (var bmp = new Bitmap(filePath))
            {
                Init(bmp);
            }
        }

        public Img8(Bitmap bmp)
        {
            Init(bmp);
        }

        private void Init(Bitmap bmp)
        {
            cols = bmp.Width;
            rows = bmp.Height;

            var bmpData = ImgMashal.GetDataFromBmp(bmp);
            data = new byte[cols * rows];
            DataRgbToGrayscale(bmpData, data);
        }

        public override Bitmap ToBitmap()
        {
            var rgbLength = 3 * GetSize();
            var rgbData = new byte[rgbLength];
            DataGrayscaleToRgb(data, rgbData);

            var bmp = new Bitmap(cols, rows, PixelFormat.Format24bppRgb);
            ImgMashal.SetDataToBmp(bmp, rgbData);

            return bmp;
        }

        public bool EqualsTo(Img8 img)
        {
            if (cols != img.cols || rows != img.rows)
                return false;

            int len = GetSize();
            for (int i = 0; i < len; i++)
            {
                if (data[i] != img.data[i])
                    return false;
            }
            return true;
        }

        public bool IsBlackAndWhite()
        {
            int len = GetSize();
            for (int i = 0; i < len; i++)
            {
                if (data[i] != 0 && data[i] != 255)
                    return false;
            }
            return true;
        }

        public byte Get(int x, int y)
        {
            return data[cols * x + y];
        }

        public void Set(int x, int y, byte value)
        {
            data[cols * x + y] = value;
        }
    }
}
