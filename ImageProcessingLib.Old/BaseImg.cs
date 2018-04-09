using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLib.Old
{
    public abstract class BaseImg
    {
        protected byte[] data;
        protected int rows;
        protected int cols;

        public void ToFile(string filePath)
        {
            ToFile(filePath, ImageFormat.Bmp);
        }

        public void ToFile(string filePath, ImageFormat format)
        {
            var bmp = ToBitmap();
            bmp.Save(filePath, format);
        }

        public abstract Bitmap ToBitmap();

        protected void DataGrayscaleToRgb(byte[] grayData, byte[] rgbData)
        {
            var length = grayData.Length;
            for (int i = 0; i < length; i++)
            {
                int index = 3 * i;
                rgbData[index + 2] = grayData[i];
                rgbData[index + 1] = grayData[i];
                rgbData[index] = grayData[i];
            }
        }

        protected void DataRgbToGrayscale(byte[] rgbData, byte[] grayData)
        {
            var length = grayData.Length;
            for (int i = 0; i < length; i++)
            {
                int index = 3 * i;
                data[i] = (byte)(0.3d * rgbData[index + 2] + 0.59d * rgbData[index + 1] + 0.11d * rgbData[index]);
            }
        }

        public void ForEach(Action<int, int> pixelAction)
        {
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    pixelAction(i, j);
        }

        public void ForSegment(int segmentNumber, int segmentsCount, Action<int, int> pixelAction)
        {
            int segmentWidth = cols / segmentsCount;
            int lastSegmentWidth = cols - (segmentsCount - 1) * segmentWidth;

            int width;
            if (segmentNumber == segmentsCount - 1)
                width = lastSegmentWidth;
            else
                width = segmentWidth;

            int startPos = segmentNumber * segmentWidth;
            int endPos = startPos + width;
            for (int i = 0; i < rows; i++)
                for (int j = startPos; j < endPos; j++)
                    pixelAction(i, j);
        }

        public int GetRows()
        {
            return rows;
        }

        public int GetCols()
        {
            return cols;
        }

        public int GetSize()
        {
            return rows * cols;
        }

        public byte[] GetData()
        {
            return data;
        }

        public Rectangle BitmapRectangle(Bitmap bmp)
        {
            return new Rectangle(Point.Empty, new Size(bmp.Width, bmp.Height));
        }

        public byte[] CopyData()
        {
            return data.Clone() as byte[];
        }
    }
}
