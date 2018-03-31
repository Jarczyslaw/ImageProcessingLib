using System.Drawing;

namespace ImageProcessingLib
{
    public class Image24 : ImageBase
    {
        public readonly int bytesPerPixel = 3;

        #region Constructors

        public Image24(int width, int height)
        {
            SetSizes(width, height);
            var dataLength = bytesPerPixel * Size;
            data = new byte[dataLength];
        }

        public Image24(Image8 img)
        {
            SetSizes(img.Width, img.Height);
            data = Data8To24(img.Data);
        }

        public Image24(Image24 img)
        {
            SetSizes(img.Width, img.Height);
            data = img.DataCopy();
        }

        public Image24(Bitmap bmp)
        {
            FromBitmap(bmp);
        }

        public Image24(string filePath)
        {
            using (var bmp = new Bitmap(filePath))
            {
                FromBitmap(bmp);
            }
        }

        #endregion

        #region ImageBase implementation

        protected override void FromBitmap(Bitmap bmp)
        {
            SetSizes(bmp.Width, bmp.Height);
            data = BmpMarshal.DataFromBmp(bmp);
        }

        protected override Bitmap ToBitmap()
        {
            return BmpMarshal.DataToBmp(data, width, height);
        }

        protected override int GetDataIndex(int x, int y)
        {
            return bytesPerPixel * (width * x + y);
        }

        #endregion

        #region Gets, sets and indexers

        public RGBValue Get(int x, int y)
        {
            int index = GetDataIndex(x, y);
            return new RGBValue(data[index + 2], data[index + 1], data[index]);
        }

        public void Set(int x, int y, RGBValue value)
        {
            int index = GetDataIndex(x, y);
            data[index + 2] = value.r;
            data[index + 1] = value.g;
            data[index] = value.b;
        }

        public RGBValue this[int x, int y]
        {
            get { return Get(x, y); }
            set { Set(x, y, value); }
        }

        #endregion

        #region Additionals

        public bool IsGrayscale()
        {
            int len = DataSize;
            for (int i = 0; i < len; i += bytesPerPixel)
            {
                if (data[i] != data[i + 1] || data[i + 1] != data[i + 2])
                    return false;
            }
            return true;
        }

        public bool IsBlackAndWhite()
        {
            int len = DataSize;
            for (int i = 0; i < len; i += bytesPerPixel)
            {
                if ((data[i] != 0 && data[i] != 255) ||
                    (data[i + 1] != 0 && data[i + 1] != 255) ||
                    (data[i + 2] != 0 && data[i + 2] != 255))
                    return false;
            }
            return true;
        }

        #endregion
    }
}
