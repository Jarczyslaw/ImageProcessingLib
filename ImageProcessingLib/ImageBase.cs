using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLib
{
    public abstract class ImageBase<T>
    {
        protected T[][] data;
        public T[][] Data
        {
            get { return data; }
        }

        protected int width;
        public int Width
        {
            get { return width; }
        }

        protected int height;
        public int Height
        {
            get { return height; }
        }

        public int Size
        {
            get { return width * height; }
        }

        protected void SetSizes(ImageBase<T> img)
        {
            SetSizes(img.Width, img.Height);
        }

        protected void SetSizes(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        protected byte[][] RGBDataToBytes(RGBValue[][] data, int width, int height)
        {
            var result = JaggedArrayUtils.Create<byte>(width, height);
            for (int i = 0; i < width;i++)
            {
                for (int j = 0;j < height;j++)
                {
                    var p = data[i][j];
                    result[i][j] = (byte)(0.3d * p.r + 0.59d * p.g + 0.11d * p.b);
                } 
            }
            return result;
        }

        protected RGBValue[][] ByteDataToRGBValues(byte[][] data, int width, int height)
        {
            var result = JaggedArrayUtils.Create<RGBValue>(width, height);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    var val = data[i][j];
                    var p = new RGBValue(val, val, val);
                    result[i][j] = p;
                }
            }
            return result;
        }

        public void ToFile(string filePath)
        {
            ToFile(filePath, ImageFormat.Bmp);
        }

        public void ToFile(string filePath, ImageFormat imageFormat)
        {
            var bmp = ToBitmap();
            bmp.Save(filePath, imageFormat);
        }

        public T this[int index]
        {
            get
            {
                GetTwodimensionalIndexes(index, out int x, out int y);
                return data[x][y];
            }
            set
            {
                GetTwodimensionalIndexes(index, out int x, out int y);
                data[x][y] = value;
            }
        }

        public T this[int x, int y]
        {
            get { return data[x][y]; }
            set { data[x][y] = value; }
        }

        protected void GetTwodimensionalIndexes(int index, out int x, out int y)
        {
            y = index / width;
            x = index % width;
        }

        protected abstract void FromBitmap(Bitmap bmp);
        protected abstract Bitmap ToBitmap();
    }
}
