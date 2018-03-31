using System.Drawing;
using System.Drawing.Imaging;

namespace ImageProcessingLib
{
    public abstract class ImageBase
    {
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

        protected byte[] data;
        public byte[] Data
        {
            get { return data; }
        }

        public int DataSize
        {
            get { return Data.Length; }
        }

        public int Size
        {
            get { return width * height; }
        }

        protected void SetSizes(ImageBase img)
        {
            SetSizes(img.Width, img.Height);
        }

        protected void SetSizes(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        protected byte[] Data24To8(byte[] data24)
        {
            var size = data24.Length;
            var resultSize = size / 3;
            var result = new byte[resultSize];
            for(int i = 0;i < resultSize; i++)
            {
                int index = 3 * i;
                result[i] = (byte)(0.3d * data24[index + 2] + 0.59d * data24[index + 1] + 0.11d * data24[index]);
            }
            return result;
        }

        protected byte[] Data8To24(byte[] data8)
        {
            var size = data8.Length;
            var resultSize = size * 3;
            var result = new byte[resultSize];
            for(int i = 0;i < resultSize; i++)
            {
                int index = 3 * i;
                result[index + 2] = data8[i];
                result[index + 1] = data8[i];
                result[index] = data8[i];
            }
            return result;
        }

        public byte[] DataCopy()
        {
            return data.Clone() as byte[];
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

        public byte this[int index]
        {
            get { return data[index]; }
            set { data[index] = value; }
        }

        protected abstract void FromBitmap(Bitmap bmp);
        protected abstract Bitmap ToBitmap();
        protected abstract int GetDataIndex(int x, int y);
    }
}
